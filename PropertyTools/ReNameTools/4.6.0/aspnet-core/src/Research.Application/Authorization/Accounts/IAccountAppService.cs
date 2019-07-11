using System.Threading.Tasks;
using Abp.Application.Services;
using Research.Authorization.Accounts.Dto;

namespace Research.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
