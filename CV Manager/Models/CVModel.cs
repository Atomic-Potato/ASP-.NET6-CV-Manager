using Microsoft.AspNetCore.Mvc;

namespace CV_Manager.Models {
    public class CVModel {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime birthDay { get; set; }

        // Dropdown List
        [Required]
        [Display(Name = "Nationality")]
        public string nationality { get; set; }

        // Radio Button
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Skills")]
        public List<string> selectedSkills { get; set; } = new List<string>();

        [Required]
        [EmailAddress]
        [Display(Name = "Email Adddress")]
        public string email { get; set; }

        // [Required (ErrorMessage = "Please re-type the email address")]
        [EmailAddress]
        [Display(Name = "Re-type the email address")]
        [Compare("email", ErrorMessage = "Emails do not match!")]
        public string emailConfirm { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number must be between 1 & 20")]
        [Display(Name = "X value between 1 & 20")]
        public int x { get; set; }

        [Required]
        [Range(20, 50, ErrorMessage = "Number must be between 20 & 50")]
        [Display(Name = "Y value between 20 & 50")]
        public int y { get; set; }

        [Required]
        [Display(Name = "Sum of X & Y")]
        public int sum { get; set; }

        [Required]
        [Display(Name = "Photus")]
        public IFormFile photo { get; set; }

        /// <summary>
        /// Coverts the model into a CV record
        /// </summary>
        /// <returns>CV containing all the appropriate data from the model</returns>
        public CV ToCV() {
            string imagePath = SaveImage();

            return new CV {
                firstName = this.firstName,
                lastName = this.lastName,
                birthDay = this.birthDay,
                nationality = this.nationality,
                gender = this.gender,


                java = selectedSkills.Contains("java"),
                cs = selectedSkills.Contains("cs"),
                python = selectedSkills.Contains("py"),
                beef = selectedSkills.Contains("beef"),

                email = this.email,
                photo = imagePath
            };
        }

        /// <summary>
        /// Saves the submitted image to the following path:
        /// wwwroot/CVImages
        /// </summary>
        /// <returns>The new image path</returns>
        string SaveImage() {
            string folderPath = "wwwroot/CVImages";
            string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            string savePath = folderPath + "/" + fileName;
            string filePath = "~/CVImages/" + fileName;

            using (var fileStream = new FileStream(savePath, FileMode.Create)) {
                photo.CopyTo(fileStream);
            }

            return filePath;
        }
    }
}
