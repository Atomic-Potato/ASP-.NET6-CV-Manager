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
    public class IndexModel : PageModel
    {
        private readonly CV_Manager.Data.AppDbContext _context;

        public IndexModel(CV_Manager.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<CV> CV { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CVs != null)
            {
                CV = await _context.CVs.ToListAsync();
            }
        }
    }
}
