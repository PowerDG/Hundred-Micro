using System.Threading.Tasks;
using Abp.Application.Services;
using Research.Roles.Dto;

namespace Research.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
