using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{

        [Authorize(Policy = "MustBelongToHR")] // This attribute will make sure that only authenticated users can access this page  
        public class HRModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
