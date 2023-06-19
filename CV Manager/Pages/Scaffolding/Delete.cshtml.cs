using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV_Manager.Pages.Scaffolding
{
    public class DeleteModel : PageModel
    {
        readonly AppDbContext _context;
        readonly CVService cvService;

        public DeleteModel(AppDbContext context, CVService cvService)
        {
            _context = context;
            this.cvService = cvService;
        }

        [BindProperty]
        public CV CV { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CVs == null)
                return NotFound();

            var cv = await _context.CVs.FirstOrDefaultAsync(m => m.cvId == id);

            if (cv == null)
                return NotFound();
            else 
                CV = cv;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id){
            if (id == null || _context.CVs == null)
                return NotFound();

            await cvService.DeleteCV((int)id);

            return RedirectToPage("./Index");
        }
    }
}
