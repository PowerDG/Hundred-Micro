using System.Threading.Tasks;
using Research.Configuration.Dto;

namespace Research.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}