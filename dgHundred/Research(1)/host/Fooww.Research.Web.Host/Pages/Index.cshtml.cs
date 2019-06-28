using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Fooww.Research.Pages
{
    public class IndexModel : ResearchPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}