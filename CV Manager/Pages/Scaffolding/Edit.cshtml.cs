using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CV_Manager.Data;

namespace CV_Manager.Pages.Scaffolding
{
    public class EditModel : PageModel
    {
        private readonly CV_Manager.Data.AppDbContext _context;

        public EditModel(CV_Manager.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CV CV { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CVs == null)
            {
                return NotFound();
            }

            var cv =  await _context.CVs.FirstOrDefaultAsync(m => m.cvId == id);
            if (cv == null)
            {
                return NotFound();
            }
            CV = cv;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVExists(CV.cvId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CVExists(int id)
        {
          return _context.CVs.Any(e => e.cvId == id);
        }
    }
}
