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
        
        public IEnumerable<SelectListItem> nationalities = new List<SelectListItem>() {
            new SelectListItem{Value = "LB", Text = "Lebanese"},
            new SelectListItem{Value = "JP", Text = "Japanese"},
            new SelectListItem{Value = "FR", Text = "French"},
            new SelectListItem{Value = "O", Text = "Other"}
        };

        public IEnumerable<SelectListItem> genders = new List<SelectListItem>() {
            new SelectListItem{Value = "M", Text = "Male"},
            new SelectListItem{Value = "F", Text = "Female"},
            new SelectListItem{Value = "AH", Text = "Attack Helicopter"},
            new SelectListItem{Value = "O", Text = "Other"}
        };

        public IEnumerable<SelectListItem> skills = new List<SelectListItem>() {
            new SelectListItem{Value = "cs", Text = "C#"},
            new SelectListItem{Value = "java", Text = "Java"},
            new SelectListItem{Value = "py", Text = "Python"},
            new SelectListItem{Value = "beef", Text = "Beef"}
        };

        public void OnGet(){
            cv = new BaseCV();
        }
    }
}
