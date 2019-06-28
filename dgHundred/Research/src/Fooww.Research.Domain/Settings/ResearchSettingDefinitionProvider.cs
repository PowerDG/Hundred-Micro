using Volo.Abp.Settings;

namespace Fooww.Research.Settings
{
    public class ResearchSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ResearchSettings.MySetting1));
        }
    }
}
