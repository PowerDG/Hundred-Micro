using System;
using System.Text;

namespace CamelTo_under_score
{
    /// <summary>
    /// 
    /// C# 下划线转驼峰
    /// https://blog.csdn.net/qq_37214567/article/details/80885637
    /// 【转】C# String 与 Char[] 数组 相互转换
    /// https://www.cnblogs.com/haizine/p/8340588.html
    /// 驼峰与下划线之间的转换
    /// https://www.cnblogs.com/xiangpeng/p/10189390.html
    /// </summary>
    public static   class NamingConventions
    {
        public static string UnderscoreName(String name)
        {
            StringBuilder result = new StringBuilder();
            char[] m_list = name.ToCharArray();
            if (name != null && m_list.Length > 0)
            {
                // 将第一个字符处理成小写
                result.Append (name.Substring(0, 1).ToLowerInvariant());
                // 循环处理其余字符
                for (int i = 1; i < name.Length ; i++)
                {
                    //String s = m_list[i];
                    // 在大写字母前添加下划线
                    if (m_list[i].ToString().Equals(m_list[i].ToString().ToUpperInvariant()) 
                        //&& !s.charAt(0)
                        )
                    {
                        result.Append("_");
                    }
                    // 其他字符直接转成小写
                    result.Append(m_list[i].ToString().ToLowerInvariant());
                }
            }
            return result.ToString();
        }
    }
}
