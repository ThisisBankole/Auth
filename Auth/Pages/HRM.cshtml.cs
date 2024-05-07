using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{
    [Authorize(Policy = "HRManager")]
    public class HRMModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
