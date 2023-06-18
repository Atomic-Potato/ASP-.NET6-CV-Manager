using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace CV_Manager.Pages
{
    public class SummaryModel : PageModel
    {
        [BindProperty]
        public CV cv { get; set; }
        [BindProperty]
        public int grade { get; set; }

        CVService service;

        public SummaryModel(CVService service) { 
            this.service = service;
        }

        public async Task OnGet(int id){
            cv = await service.GetCV(id);
            grade = service.CalculateGrade(cv);
        }
    }
}
