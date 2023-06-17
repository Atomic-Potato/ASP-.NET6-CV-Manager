using CV_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CV_Manager.Pages
{
    public class SendModel : PageModel
    {
        [BindProperty]
        public CVModel cv {get; set;}

        readonly CVService service;
        
        public SendModel(CVService service) {
            this.service = service;
        }

        public void OnGet(){
            cv = new CVModel();
        }

        public async Task<IActionResult> OnPost() {
            try {
                int cvId = await service.CreateCV(cv);
                return RedirectToPage("Summary", new { id = cvId});
            }
            catch (Exception ex) {
                Console.WriteLine("CV could not be added to the databse");
                throw;
            }
        }
    }
}
