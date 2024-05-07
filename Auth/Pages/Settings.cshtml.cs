using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{
    [Authorize(Policy = "MustBeAdmin")]
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
