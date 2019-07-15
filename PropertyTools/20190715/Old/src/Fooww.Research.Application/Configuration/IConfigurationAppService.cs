using System.Threading.Tasks;
using Fooww.Research.Configuration.Dto;

namespace Fooww.Research.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
