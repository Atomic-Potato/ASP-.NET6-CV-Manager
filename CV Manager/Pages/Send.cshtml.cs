using CV_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CV_Manager.Pages
{
    public class SendModel : PageModel
    {
        [BindProperty]
        public BaseCV cv {get; set;}
        
        public void OnGet(){
            cv = new BaseCV();
        }

        // TODO: Convert to async Task once database stuff is implemented
        public IActionResult OnPost() {
            return RedirectToPage("Summary", new { id = "Insert_ID" });
        }
    }
}
