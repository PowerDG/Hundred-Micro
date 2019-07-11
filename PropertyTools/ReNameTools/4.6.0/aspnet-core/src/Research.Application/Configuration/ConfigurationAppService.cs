using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Research.Configuration.Dto;

namespace Research.Configuration
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
