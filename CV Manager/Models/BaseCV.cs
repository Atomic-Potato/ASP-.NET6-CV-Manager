using Microsoft.AspNetCore.Mvc;

namespace CV_Manager.Models {
    public class BaseCV {
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
        public List<string> selectedSkills { get; set; }

        [Required]
        [EmailAddress]
        [Compare("emailConfirm")]
        [Display(Name = "Email Adddress")]
        public string email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("email")]
        [Display(Name = "Confirm Email Address")]
        public string emailConfirm { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Invalid number!")]
        [Display(Name = "X value")]
        public int x { get; set; }

        [Required]
        [Range(20, 50, ErrorMessage = "Invalid number!")]
        [Display(Name = "Y value")]
        public int y { get; set; }

        [Required]
        [Display(Name = "Sum of X & Y")]
        public int sum { get; set; }

        [Display(Name = "Photus")]
        public IFormFile photo { get; set; }

        public List<bool> tests { get; set; }
    }
}
