using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CV_Manager.Data;

namespace CV_Manager.Pages.Scaffolding
{
    public class DeleteModel : PageModel
    {
        private readonly CV_Manager.Data.AppDbContext _context;

        public DeleteModel(CV_Manager.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CV CV { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CVs == null)
            {
                return NotFound();
            }

            var cv = await _context.CVs.FirstOrDefaultAsync(m => m.cvId == id);

            if (cv == null)
            {
                return NotFound();
            }
            else 
            {
                CV = cv;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CVs == null)
            {
                return NotFound();
            }
            var cv = await _context.CVs.FindAsync(id);

            if (cv != null)
            {
                CV = cv;
                _context.CVs.Remove(CV);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
