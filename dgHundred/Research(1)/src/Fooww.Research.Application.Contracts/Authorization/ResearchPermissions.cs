using Volo.Abp.Reflection;

namespace Fooww.Research.Authorization
{
    public class ResearchPermissions
    {
        public const string GroupName = "Research";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ResearchPermissions));
        }
    }
}