using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Fooww.Research.MultiTenancy.Dto;

namespace Fooww.Research.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

