using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
//using EPPlus.Core;
//using System.ComponentModel.Annotations;
//using OfficeOpenXml;

namespace Camel2mysqlTest
{
    public class EPPlusHepler
    {



    }
    public class ExcelReadServiceAccordingDisplayAttr<T> : IExcelReadService<T> where T : new()
    {
        ILogBase _logger;
        static Dictionary<string, PropertyInfo> _displayAttrDic;
        public ExcelReadServiceAccordingDisplayAttr(ILogBase logBase)
        {
            _logger = logBase;
        }




        private List<T> GetData(string excelPath, string sheetName = "", int sheetIndex = 0)
        {
            try
            {
                FileInfo existingFile = new FileInfo(excelPath);

                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet sheet = GetSheet(package, sheetName, sheetIndex);
                    if (sheet == null) return null;
                    //获取不需要读取的column
                    List<long> excluedeColumns = GetExcludeCloumns(sheet);
                    //根据excelheader来获取type T数据对象的列字典
                    Dictionary<int, PropertyInfo> columnIndexDic = GetColumnIndexDicFromExcelHeader(sheet, excluedeColumns);
                    //读取excel数据，填充List<T>
                    List<T> result = GetDatesFromContent(sheet, columnIndexDic, excluedeColumns);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"get data from excel exception :{ex.ToString()},excel:{excelPath},sheetIndex:{sheetIndex},entityType:{typeof(T).FullName}");
                throw ex;
            }
        }

 
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
29
30
31
32
33
34
35
36
37
38
39
40
41
42
43
44
45
46
47
48
49
50
51
52
53
54
55
56
57
58
59
60
61
62
63
64
65
66
67
68
69
70
71
72
73
74
75
76
77
78
79
80
81
82
83
84
85
86
87
88
89
90
91
92
93
94
95
96
97
98
99
100
101
102
103
104
105
106
107
108
109
110
111
112
113
114
115
116
117
118
119
120
121
122
123
124
125
126
127
128
129
130
131
132
133
134
135
136
137
138
139
140
	
private List<T> GetDateFromSheet(ExcelWorksheet sheet)
        {
            if (sheet == null) return null;
            List<long> excluedeColumns = GetExcludeCloumns(sheet);
            //根据excelheader来获取type T数据对象的列字典
            Dictionary<int, PropertyInfo> columnIndexDic = GetColumnIndexDicFromExcelHeader(sheet, excluedeColumns);
            //读取excel数据，填充List<T>
            List<T> result = GetDatesFromContent(sheet, columnIndexDic);
            return result;
        }

        private List<T> GetData(byte[] excelContent, string sheetName = "", int sheetIndex = 0)
        {
            try
            {
                using (Stream stream = new MemoryStream(excelContent))
                {
                    using (ExcelPackage package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet sheet = GetSheet(package, sheetName, sheetIndex);
                        return GetDateFromSheet(sheet);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"get data from excel exception :{ex.ToString()},excelContent:{excelContent},sheetIndex:{sheetIndex},entityType:{typeof(T).FullName}");
                throw ex;
            }
        }

        private ExcelCheckResult CheckDate(byte[] excelContent, string sheetName = "", int sheetIndex = 0)
        {
            try
            {
                using (Stream stream = new MemoryStream(excelContent))
                {
                    using (ExcelPackage package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet sheet = GetSheet(package, sheetName, sheetIndex);
                        if (sheet == null) return null;
                        List<long> excluedeColumns = GetExcludeCloumns(sheet);
                        //根据excelheader来获取type T数据对象的列字典
                        Dictionary<int, PropertyInfo> columnIndexDic = GetColumnIndexDicFromExcelHeader(sheet, excluedeColumns);
                        bool formatResult = FormatSheet(ref sheet, columnIndexDic);
                        package.Save();
                        if (!formatResult)
                        {
                            return new ExcelCheckResult() { CheckResult = false, CheckMsg = "format error!" };
                        }
                        return CheckExcel(ref sheet, columnIndexDic);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"get data from excel exception :{ex.ToString()},excelContent:{excelContent},sheetIndex:{sheetIndex},entityType:{typeof(T).FullName}");
                throw ex;
            }
        }

        /// <summary>
        /// 根据 DisplayAttribute 的 Description 来格式化sheet
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="columnIndexDic"></param>
        private bool FormatSheet(ref ExcelWorksheet sheet, Dictionary<int, PropertyInfo> columnIndexDic)
        {
            try
            {
                var typeOfObject = typeof(T);
                var columnIndexDicForDisplayAttr = new Dictionary<int, DisplayAttribute>();
                foreach (var columnInfo in columnIndexDic)
                {
                    int columnKey = columnInfo.Key;
                    PropertyInfo columnProperty = columnInfo.Value;
                    var attr = columnProperty.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                    if (attr != null && !string.IsNullOrEmpty(attr.Description))
                    {
                        var originalFormat = sheet.Column(columnKey).Style.Numberformat.Format;
                        sheet.Column(columnKey).Style.Numberformat.Format = attr.Description;
                        _logger.Warn($"change cloumn{columnKey} formate({ originalFormat}=>{attr.Description}):(class:{typeOfObject.FullName},property:{columnProperty.Name})");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"excel Format error. columnIndexDic:{JsonConvert.SerializeObject(columnIndexDic.Keys)}", ex);
                return false;
            }
        }

        private ExcelCheckResult CheckExcel(ref ExcelWorksheet sheet, Dictionary<int, PropertyInfo> columnIndexDic)
        {
            var excelCheckResult = new ExcelCheckResult()
            {
                CheckResult = true,
                CheckMsg = "Succeed!"
            };
            var columnPropertyDic = columnIndexDic.Values.ToLookup(p => p.Name).ToDictionary(kp => kp.Key, kp => kp.FirstOrDefault());

            Dictionary<string, PropertyInfo> requiredPropertyDic = GetRequireDicFromType();
            StringBuilder msg = new StringBuilder();
            foreach (var requiredProperty in requiredPropertyDic)
            {
                var properName = requiredProperty.Key;
                if (!columnPropertyDic.ContainsKey(properName))
                {
                    msg.AppendLine($"{properName} is required!");
                    _logger.Warn($"property:({properName}) is required ! columnIndexDic:{JsonConvert.SerializeObject(columnIndexDic.Keys)}");
                }
            }
            if (!string.IsNullOrEmpty(msg.ToString()))
            {
                excelCheckResult.CheckResult = false;
                excelCheckResult.CheckMsg = msg.ToString();
            }
            return excelCheckResult;
        }

        private Dictionary<string, PropertyInfo> GetRequireDicFromType()
        {
            Type typeOfObject = typeof(T);
            var pds = typeOfObject.GetProperties();
            if (pds == null) return null;
            var propertyDic = pds.ToLookup(p => {
                var attr = p.GetCustomAttribute(typeof(RequiredAttribute)) as RequiredAttribute;
                if (attr == null) return "";
                return p.Name;
            }).ToDictionary(kp => kp.Key, kp => kp.FirstOrDefault());
            if (propertyDic == null || propertyDic.Count() == 0)
            {
                _logger.Warn($"no RequireDic can get from class Type:{typeOfObject.FullName} ");
            }
            else
            {
                propertyDic.Remove("");
            }
            return propertyDic;
        }
        private List<long> GetExcludeCloumns(ExcelWorksheet sheet)
        {
            List<long> excludeCloumns = new List<long>();
            if (sheet.PivotTables == null) return excludeCloumns;
            //排除sheet中透视表的列
            foreach (var povotTable in sheet.PivotTables)
            {
                var startCloumn = povotTable.Address.Start.Column;
                var endColumn = povotTable.Address.End.Column;
                while (startCloumn <= endColumn)
                {
                    excludeCloumns.Add(startCloumn);
                    startCloumn++;
                }
            }
            return excludeCloumns;
        }
        private ExcelWorksheet GetSheet(ExcelPackage package, string sheetName, int sheetIndex)
        {
            if (package == null || package.Workbook == null || package.Workbook.Worksheets == null || package.Workbook.Worksheets.Count == 0) return null;

            ExcelWorksheets excelWorksheets = package.Workbook.Worksheets;
            if (!string.IsNullOrWhiteSpace(sheetName))
            {
                var targetSheet = excelWorksheets.Where(s => s.Name.ToLower().Trim() == sheetName.ToLower());
                if (targetSheet == null || targetSheet.Count() == 0) return null;
                return targetSheet.FirstOrDefault();
            }
            else if (sheetIndex > 0 && sheetIndex + 1 <= excelWorksheets.Count())
            {
                return excelWorksheets[sheetIndex + 1];
            }
            else
            {
                return excelWorksheets.FirstOrDefault();
            }
        }
        private Dictionary<int, PropertyInfo> GetColumnIndexDicFromExcelHeader(ExcelWorksheet sheet, List<long> excluedeColumns)
        {
            if (_displayAttrDic == null)
            {
                //获取 Dictionary<excel column Header text,DisplayAttribute>
                _displayAttrDic = GetDisplayDicFromType(typeof(T));
            }
            Dictionary<int, PropertyInfo> displayOrderDic = new Dictionary<int, PropertyInfo>();
            if (sheet == null) return displayOrderDic;
            if (_displayAttrDic == null || _displayAttrDic.Count == 0)
            {
                _logger.Warn($"no _displayAttrDic can get .");
                return displayOrderDic;
            }
            //获取 Dictionary<column index,PropertyInfo of class T>
            var query1 = (from cell in sheet.Cells[1, 1, 1, sheet.Dimension.Columns] where !excluedeColumns.Contains(cell.Start.Column) select cell);
            foreach (var cell in query1)
            {
                var columnName = cell.Value.ToString().ToLower().Trim();
                if (_displayAttrDic.ContainsKey(columnName))
                {
                    var propertyInfo = _displayAttrDic[columnName];
                    displayOrderDic.Add(cell.Start.Column, propertyInfo);
                }
            }
            if (displayOrderDic == null || displayOrderDic.Count() == 0)
            {
                _logger.Warn($"no ColumnIndexDic can get from ExcelHeader. sheet:{sheet.Name},_displayAttrDic got no data");
            }
            return displayOrderDic;
        }

        private Dictionary<string, PropertyInfo> GetDisplayDicFromType(Type typeOfObject)
        {
            var pds = typeOfObject.GetProperties();
            if (pds == null) return null;
            //DisplayAttribute 中的Name==excel column Header
            var propertyDic = pds.ToLookup(p => {
                var attr = p.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if (attr == null) return "";
                return attr.Name.ToLower().Trim();
            }).ToDictionary(kp => kp.Key, kp => kp.FirstOrDefault());
            if (propertyDic == null || propertyDic.Count() == 0)
            {
                _logger.Warn($"no DisplayDic can get from class Type:{typeOfObject.FullName} ");
            }
            return propertyDic;
        }

        private List<T> GetDatesFromContent(ExcelWorksheet sheet, Dictionary<int, PropertyInfo> columnIndexDic, List<long> excluedeColumns)
        {
            List<T> result = new List<T>();
            //fill list form excel
            Dictionary<string, Dictionary<string, object>> enumDic = new Dictionary<string, Dictionary<string, object>>();
            var query2 = (from cell in sheet.Cells[2, 1, sheet.Dimension.Rows, sheet.Dimension.Columns] where !excluedeColumns.Contains(cell.Start.Column) select cell);
            T temp = default(T);
            foreach (var cell in query2)
            {
                if (cell.Start.Column == 1)
                {
                    if (temp != null) result.Add(temp);
                    temp = (T)Activator.CreateInstance(typeof(T));
                }
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString())) continue;
                SetValueAccordingEachCell(cell, temp, columnIndexDic, ref enumDic);
            }
            if (temp != null) result.Add(temp);
            return result;
        }




        //according cell value to set T's property value
        private void SetValueAccordingEachCell(ExcelRangeBase cell, T temp, Dictionary<int, PropertyInfo> columnIndexDic, ref Dictionary<string, Dictionary<string, object>> enumDic)
        {
            try
            {
                var columnIndex = cell.Start.Column;
                if (columnIndexDic == null || columnIndexDic.Count() == 0)
                {
                    _logger.Warn($"no column Index can get from cell(address:{cell.Start.Address} ,value:{cell.Value})");
                    return;
                }
                if (!columnIndexDic.ContainsKey(columnIndex))
                {
                    _logger.Warn($"no column Index can get from cell(address:{cell.Start.Address} ,value:{cell.Value}),columnIndexDic:{JsonConvert.SerializeObject(columnIndexDic.Keys)}");
                    return;
                }
                var propertyInfo = columnIndexDic[columnIndex];
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsEnum)
                {
                    Dictionary<string, object> enumDicTemp;
                    if (enumDic.ContainsKey(propertyType.FullName))
                    {
                        enumDicTemp = enumDic[propertyType.FullName];
                    }
                    else
                    {
                        enumDicTemp = GetEnumDicFromType(propertyType);
                        enumDic.Add(propertyType.FullName, enumDicTemp);
                    }

                    object enumValue = null;
                    if (enumDicTemp != null)
                    {
                        if (enumDicTemp.ContainsKey(cell.Value.ToString()))
                        {
                            enumValue = enumDicTemp[cell.Value.ToString()];
                        }
                        else
                        {
                            _logger.Warn($"no enum value can get from enum dictionary:{JsonConvert.SerializeObject(enumDicTemp.Keys)} , enum Type:{propertyType.FullName},cell (address:{cell.Start.Address},value:{cell.Value.ToString()})");
                        }
                    }
                    else
                    {
                        _logger.Warn($"no enum dictionary can get from enum Type:{propertyType.FullName} ");
                    }

                    if (enumValue != null)
                    {
                        propertyInfo.SetValue(temp, enumValue);
                    }
                    else
                    {
                        _logger.Warn($"no enum value can get for cell:{cell.Value} ");
                    }
                    return;
                }
                if (propertyType == typeof(decimal))
                {
                    string cellV = cell.Value.ToString();
                    decimal multiply = 1;
                    if (cellV.Contains("%"))
                    {
                        multiply = 100;
                        cellV = cellV.Substring(0, cellV.IndexOf("%") + 1);
                    }
                    decimal tempV;
                    bool convertR = decimal.TryParse(cellV, out tempV);
                    if (convertR)
                    {
                        propertyInfo.SetValue(temp, tempV * multiply);
                    }
                    else
                    {
                        _logger.Warn($"no decimal value can get for cell:(address:{cell.Address},value:{cell.Value})");
                    }
                    return;
                }
                if (propertyType == typeof(int))
                {
                    propertyInfo.SetValue(temp, Convert.ToInt32(cell.Value));
                    return;
                }
                if (propertyType == typeof(long))
                {
                    propertyInfo.SetValue(temp, Convert.ToInt64(cell.Value));
                    return;
                }
                if (propertyType == typeof(DateTime))
                {
                    propertyInfo.SetValue(temp, Convert.ToDateTime(cell.Value));
                    return;
                }
                if (propertyType == typeof(string))
                {
                    propertyInfo.SetValue(temp, cell.Value.ToString());
                    return;
                }
                propertyInfo.SetValue(temp, cell.Value.ToString());
                return;
            }
            catch (Exception ex)
            {
                _logger.Error($"no property value can set from cell:(address:{cell.Address},value:{cell.Value})");
                throw ex;
            }
        }




        // get Dictionary<enumn's display name==excel cell value,emumn value>
        private Dictionary<string, object> GetEnumDicFromType(Type propertyType)
        {
            var result = new Dictionary<string, object>();
            if (propertyType.IsEnum)
            {
                var enumValues = propertyType.GetEnumValues();
                foreach (var value in enumValues)
                {
                    MemberInfo memberInfo =
                        propertyType.GetMember(value.ToString()).First();
                    var descriptionAttribute =
                        memberInfo.GetCustomAttribute<DisplayAttribute>();
                    if (descriptionAttribute != null)
                    {
                        result.Add(descriptionAttribute.Name, value);
                    }
                    else
                    {
                        var enumString = Enum.GetName(propertyType, value);
                        result.Add(enumString, value);
                    }
                }
                if (result == null || result.Count() == 0)
                {
                    _logger.Warn($"no EnumDic can get from enum Type:{propertyType.FullName} ");
                }
            }
            return result;
        }
    }

}
