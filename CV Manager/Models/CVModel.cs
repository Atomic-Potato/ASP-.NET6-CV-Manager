using Microsoft.AspNetCore.Mvc;

namespace CV_Manager.Models {
    public class CVModel {
        #region GENEARL INFORMATION
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
        #endregion

        #region SKILLS
        [Display(Name = "Java")]
        public bool java { get; set; }
        [Display(Name = "C#")]
        public bool cs { get; set; }
        [Display(Name = "Python")]
        public bool python { get; set; }
        [Display(Name = "Beef")]
        public bool beef { get; set; }
        #endregion

        #region EMAIL
        [Required]
        [EmailAddress]
        [Display(Name = "Email Adddress")]
        public string email { get; set; }

        [EmailAddress]
        [Display(Name = "Re-type the email address")]
        [Compare("email", ErrorMessage = "Emails do not match!")]
        public string emailConfirm { get; set; }
        #endregion

        #region VALIDATION
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
        #endregion

        #region OTHER INFORMATION
        [Required]
        [Display(Name = "Photus")]
        public IFormFile photo { get; set; }

        public string imagePath { get; set; }
        
        public int grade { get; set; }
        #endregion

        /// <summary>
        /// Coverts the model into a CV record
        /// </summary>
        /// <returns>CV containing all the appropriate data from the model</returns>
        public CV ToCV() {
            return new CV {
                firstName = this.firstName,
                lastName = this.lastName,
                birthDay = this.birthDay,
                nationality = this.nationality,
                gender = this.gender,

                java = this.java,
                cs = this.cs,
                python = this.python,
                beef = this.beef,

                email = this.email,
                photo = imagePath,

                grade = this.grade,
            };
        }

        /// <summary>
        /// Creates a CV model from a CV entity
        /// </summary>
        /// <param name="cv">CV entity</param>
        /// <returns>CVModel</returns>
        public static CVModel ToCVModel(CV cv) {
            return new CVModel { 
                firstName = cv.firstName,
                lastName = cv.lastName,
                birthDay = cv.birthDay,
                nationality = cv.nationality,
                gender = cv.gender,
                java = cv.java,
                cs = cv.cs,
                python = cv.python,
                beef = cv.beef,
                email = cv.email,
                grade = cv.grade,
            };
        }
    }
}
