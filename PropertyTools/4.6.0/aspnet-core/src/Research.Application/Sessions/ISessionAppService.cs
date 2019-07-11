using System.Threading.Tasks;
using Abp.Application.Services;
using Research.Sessions.Dto;

namespace Research.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
