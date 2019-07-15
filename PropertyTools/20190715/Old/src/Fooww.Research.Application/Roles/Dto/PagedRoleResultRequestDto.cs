using Abp.Application.Services.Dto;

namespace Fooww.Research.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

