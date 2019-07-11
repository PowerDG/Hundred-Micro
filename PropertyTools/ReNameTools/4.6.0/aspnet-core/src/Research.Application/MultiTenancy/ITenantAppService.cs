using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Research.MultiTenancy.Dto;

namespace Research.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

