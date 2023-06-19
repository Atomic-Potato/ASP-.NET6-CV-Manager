using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV_Manager.Pages.Scaffolding
{
    public class IndexModel : PageModel
    {
        readonly AppDbContext _context;
        readonly FileService fileService;
        readonly CVService cvService;

        public IndexModel(AppDbContext context, FileService fileService, CVService cvService)
        {
            _context = context;
            this.fileService = fileService;
            this.cvService = cvService;
        }

        public IList<CV> CV { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CVs != null)
            {
                CV = await _context.CVs.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPost(string form, int cvId) {
            if (form.StartsWith("download-")) {
                CV cv = await cvService.GetCV(cvId);
                byte[] pdf = fileService.ConvertToPDF(cv);
                return File(pdf, "application/pdf", cv.firstName + "_" + cv.lastName + "_CV.pdf");
            }

            return Page();
        }
    }
}
