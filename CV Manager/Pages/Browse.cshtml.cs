using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV_Manager.Pages
{
    public class BrowseModel : PageModel
    {
        [BindProperty]
        public IEnumerable<CV> cvs { get; set; }

        CVService service;

        public BrowseModel(CVService service) { 
            this.service = service;
        }

        public async Task OnGet(){
            cvs = await service.LoadAllCVs();
        }

        public async Task<IActionResult> OnPost(string form, int cvId) {
            if (form.StartsWith("details-"))
                return RedirectToPage("Summary", new { id = cvId });
            if (form.StartsWith("edit-"))
                return RedirectToPage("Edit", new { id = cvId });
            if (form.StartsWith("delete-")) {
                return RedirectToPage("./Scaffolding/Delete", new { id = cvId });
            }

            return Page();
        }
    }
}
