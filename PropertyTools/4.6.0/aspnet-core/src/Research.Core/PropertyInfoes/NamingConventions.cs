using System;
using System.Collections.Generic;
using System.Text;

namespace Research.PropertyInfoes
{
    public static class NamingConventions
    {
        public static bool IsPropertyName(string name)
        {
            string[] parts = name.Split(" ");
            if (string.IsNullOrWhiteSpace(name) || parts.Length < 3)
            {
                return false;
            }
            return true;
        }
        public static bool IsMigratorCodeLine(string name)
        {
            string[] parts = name.Split(" ");
            if (string.IsNullOrWhiteSpace(name) ||
               parts.Length < 3 || !parts[1].Equals("="))
            {
                return false;
            }
            return true;
        }

        #region Migrations

        public static string GetColumnFirstName(string m_propertyFullName)
        {
            if (m_propertyFullName.Contains("class"))
            {
                return m_propertyFullName;
            }
            String[] parts = m_propertyFullName.TrimStart().Split(" ");
            if ((string.IsNullOrWhiteSpace(m_propertyFullName) ||
                parts.Length < 3))
            {
                return m_propertyFullName;
            }
            else if (parts[1].Equals("="))
            {

                return GetSqlColumnRename(parts[0]);
            }
            else
            {
                return m_propertyFullName;
            }
        }
        public static string ReplaceMigrator(string m_migratorName, string m_columnName)
        {
            if (m_migratorName.Contains("class"))
            {
                return m_migratorName;
            }
            String[] parts = m_migratorName.TrimStart().Split(" ");
            if (IsMigratorCodeLine(m_migratorName))
            {
                return m_migratorName;
            }
            var m_newMigratorName = m_columnName;
            for (int i = 1; i < parts.Length; i++)
            {
                m_newMigratorName += " " + parts[i];
            }
            return m_newMigratorName;
        }

        #endregion


        #region Property
         
        public static string GetPropertyName(string m_propertyFullName)
        {
            if (m_propertyFullName.Contains("class"))
            {
                return m_propertyFullName;
            }
            String[] parts = m_propertyFullName.Split(" ");
            if (!IsPropertyName(m_propertyFullName))
            {
                return m_propertyFullName;
            }
            return parts[2];
        }

        /// <summary>
        /// override or new 之前的虚属性
        /// </summary>
        /// <param name="m_propertyFullName"></param>
        /// <returns></returns>
        public static string ReNewPropertyName(string m_propertyFullName)
        {
            if (m_propertyFullName.Contains("class"))
            {
                return m_propertyFullName;
            }
            String[] parts = m_propertyFullName.Split(" ");
            if (!IsPropertyName(m_propertyFullName))
            {
                return m_propertyFullName;
            }
            var m_newPropertyName = parts[0] + " new ";
            for (int i = 1; i < parts.Length; i++)
            {
                m_newPropertyName += " " + parts[i];
            }
            return m_newPropertyName;
        } 

        /// <summary>
        /// 属性名上注解  添加sql的Entity关系映射
        /// </summary>
        /// <param name="m_propertyFullName"></param>
        /// <param name="m_column_name"></param>
        /// <param name="isZeroModule"></param>
        /// <returns></returns>
        public static string GetPropertyNameWithColumn(string m_propertyFullName, string m_column_name, byte isZeroModule)
        {
            if (m_propertyFullName.Contains("class"))
            {
                return m_propertyFullName;
            }
            String[] parts = m_propertyFullName.Split(" ");
            if (!IsPropertyName(m_propertyFullName))
            {
                return m_propertyFullName;
            }
            if (isZeroModule == 1)
            {
                return "[Column(\"" + m_column_name + "\")]" + "\n" + ReNewPropertyName(m_propertyFullName);
            }
            return "[Column(\"" + m_column_name + "\")]" + "\n" + m_propertyFullName;
        }

        #endregion


        #region Column

        public static string GetSqlColumnRename (string name)
        {

            if (name.Contains("CreationTime"))
            {
                return "create_time";
            }
            if (name.Contains("LastModificationTime"))
            {
                return "modified_time";
            }
            if (name.Contains("DeletionTime"))
            {
                return "deleted_time";
            }
            return UnderscoreName(name);
        }  
        public static string UnderscoreName(string name)
        {
             
            StringBuilder result = new StringBuilder();
            char[] m_list = name.ToCharArray();
            if (name != null && m_list.Length > 0)
            {  // 将第一个字符处理成小写
                result.Append(name.Substring(0, 1).ToLowerInvariant());
                for (int i = 1; i < name.Length; i++)
                {
                    if (m_list[i].ToString().Equals(m_list[i].ToString().ToUpperInvariant()))
                    { // 在大写字母前添加下划线
                        result.Append("_");
                    } // 其他字符直接转成小写
                    result.Append(m_list[i].ToString().ToLowerInvariant());
                }
            }
            return result.ToString();
        }
         
        #endregion


        #region Generator-forsaken


        //private static string GetColumnFirstName(string m_propertyFullName)
        //{
        //    if (m_propertyFullName.Contains("class"))
        //    {
        //        return m_propertyFullName;
        //    }
        //    String[] parts = m_propertyFullName.TrimStart().Split(" ");
        //    if ((string.IsNullOrWhiteSpace(m_propertyFullName) ||
        //        parts.Length < 3) )
        //    {
        //        return m_propertyFullName;
        //    }
        //    else if (parts[1].Equals("="))
        //    {

        //        return UnderscoreName(parts[0]);
        //    }
        //    else
        //    { 
        //        return m_propertyFullName;
        //    }
        //}
        //private static string ReplaceMigrator(string m_migratorName, string m_columnName)
        //{
        //    if (m_migratorName.Contains("class"))
        //    {
        //        return m_migratorName;
        //    }
        //    String[] parts = m_migratorName.TrimStart().Split(" ");
        //    if (string.IsNullOrWhiteSpace(m_migratorName) ||
        //        parts.Length < 3 || !parts[1].Equals("="))
        //    {
        //        return m_migratorName;
        //    }
        //    var m_newMigratorName = m_columnName;
        //    for (int i = 1; i < parts.Length; i++)
        //    {
        //        m_newMigratorName += " " + parts[i];
        //    }
        //    return m_newMigratorName;
        //}

        //private static string GetPropertyName(string m_propertyFullName)
        //{
        //    if (m_propertyFullName.Contains("class"))
        //    {
        //        return m_propertyFullName;
        //    }
        //    String[] parts = m_propertyFullName.Split(" ");
        //    if (string.IsNullOrWhiteSpace(m_propertyFullName)||parts.Length<3)
        //    {
        //        return m_propertyFullName;
        //    }
        //    return parts[2];
        //}
        //private static string ReNewPropertyName(string m_propertyFullName)
        //{
        //    if (m_propertyFullName.Contains("class"))
        //    {
        //        return m_propertyFullName;
        //    }
        //    String[] parts = m_propertyFullName.Split(" ");
        //    if (string.IsNullOrWhiteSpace(m_propertyFullName)||parts.Length < 3)
        //    {
        //        return m_propertyFullName;
        //    }
        //    var m_newPropertyName = parts[0]+" new ";
        //    for (int i = 1; i < parts.Length; i++)
        //    {
        //        m_newPropertyName += " "+parts[i];
        //    }
        //    return m_newPropertyName;
        //}
        //public static string GetPropertyNameWithColumn(string m_propertyFullName, string m_column_name,byte isZeroModule)
        //{ 
        //    if (m_propertyFullName.Contains("class"))
        //    {
        //        return m_propertyFullName;
        //    }
        //    String[] parts = m_propertyFullName.Split(" ");
        //    if (string.IsNullOrWhiteSpace(m_propertyFullName)||parts.Length < 3)
        //    {
        //        return m_propertyFullName;
        //    }
        //    if (isZeroModule==1)
        //    { 
        //        return "[Column(\"" + m_column_name + "\")]" + "\n" + ReNewPropertyName(m_propertyFullName);
        //    }
        //    return "[Column(\"" + m_column_name + "\")]" + "\n" + m_propertyFullName; 
        //}

        //public static string UnderscoreName(string name)
        //{
        //    if (name.Contains("CreationTime"))
        //    {
        //        return "create_time";
        //    }
        //    if (name.Contains("LastModificationTime"))
        //    {
        //        return "modified_time";
        //    }
        //    if (name.Contains("DeletionTime"))
        //    {
        //        return "deleted_time";
        //    }
        //    StringBuilder result = new StringBuilder();
        //    char[] m_list = name.ToCharArray();
        //    if (name != null && m_list.Length > 0)
        //    {  // 将第一个字符处理成小写
        //        result.Append(name.Substring(0, 1).ToLowerInvariant()); 
        //        for (int i = 1; i < name.Length; i++)
        //        {
        //            if (m_list[i].ToString().Equals(m_list[i].ToString().ToUpperInvariant())  )
        //            { // 在大写字母前添加下划线
        //                result.Append("_");
        //            } // 其他字符直接转成小写
        //            result.Append(m_list[i].ToString().ToLowerInvariant());
        //        }
        //    }
        //    return result.ToString(); 
        //}

        #endregion

    }
}
