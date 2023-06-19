using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV_Manager.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public CVModel cv { get; set; }

        CVService service { get; set; }

        int originalId { get; set; }

        public EditModel(CVService service) {
            this.service = service;
        }

        public async void OnGet(int id){
            cv = CVModel.ToCVModel(await service.GetCV(id));
            originalId = id;
        }

        public async Task<IActionResult> OnPost(int id, string submit) {
            if (!ValidateForm(cv))
                return Page();

            if(submit == "Cancel")
                return CancelChanges();
            if(submit == "Save")
                return await SaveChanges(id);

            return Page();

            /// <summary>
            /// Applies the modified changes to CV entity
            /// </summary>
            /// <returns>The summary page of the modfied CV</returns>
            async Task<IActionResult> SaveChanges(int id) {
                try {
                    int cvId = await service.EditCV(id, cv.ToCV());
                    return RedirectToPage("Summary", new { id = cvId });
                }
                catch (Exception) {
                    Console.WriteLine("CV could not be updated");
                    throw;
                }
            }

            IActionResult CancelChanges() {
                return RedirectToPage("Browse");
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
            if (input == null)
                return false;

            return input.x + input.y == input.sum;
        }
    }
}
