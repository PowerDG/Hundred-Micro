using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Fooww.Research.Configuration.Dto;

namespace Fooww.Research.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ResearchAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
