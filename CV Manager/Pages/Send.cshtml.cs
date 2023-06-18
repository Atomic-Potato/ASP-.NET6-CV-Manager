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
            if (!ValidateForm(cv))
                return Page();

            try {
                int cvId = await service.CreateCV(cv);
                return RedirectToPage("Summary", new { id = cvId});
            }
            catch (Exception ex) {
                Console.WriteLine("CV could not be added to the databse");
                throw; 
            }
        }

        /// <summary>
        /// Checks if the form provided is valid
        /// </summary>
        /// <param name="input">The input binding model</param>
        /// <returns>true if the form is valid, and false otherwise</returns>
        bool ValidateForm(CVModel input) {
            if (!ModelState.IsValid)
                return false;

            if (!ValidateSum(cv)) {
                ModelState.AddModelError("cv.sum", "The sum of X & Y is incorrect!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the summation provided by the user is correct
        /// </summary>
        /// <param name="input">The input binding model</param>
        /// <returns>true if the sum is correct, and false otherwise</returns>
        bool ValidateSum(CVModel input) {
            if(input == null)
                return false;

            return input.x + input.y == input.sum;
        }
    }
}
