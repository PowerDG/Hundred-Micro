using Research.PropertyInfoes;
using System;

namespace ReplaceMigratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string testName = Console.ReadLine();
            //string testName= $"  columns: new[] {  "tenant_id ",  "execution_duration " });";
            Console.WriteLine(ReplaceMigrator(testName)) ;
        }

        public static string ReplaceMigrator(string columnName)
        {
            return NamingConventions.ReplaceMigrator(columnName ,""  );
        }
    }
}
