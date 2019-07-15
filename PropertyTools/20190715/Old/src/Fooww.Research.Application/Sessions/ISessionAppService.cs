using System.Threading.Tasks;
using Abp.Application.Services;
using Fooww.Research.Sessions.Dto;

namespace Fooww.Research.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
