using System.Threading.Tasks;
using Abp.Application.Services;
using Fooww.Research.Authorization.Accounts.Dto;

namespace Fooww.Research.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
