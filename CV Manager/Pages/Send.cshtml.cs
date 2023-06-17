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
    }
}
