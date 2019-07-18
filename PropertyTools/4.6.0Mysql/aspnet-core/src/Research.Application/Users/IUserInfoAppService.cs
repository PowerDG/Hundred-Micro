using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Research.Roles.Dto;
using Research.Users.Dto;

namespace Research.Users
{
    public interface IUserInfoAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
