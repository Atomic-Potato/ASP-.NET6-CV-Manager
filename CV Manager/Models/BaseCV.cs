namespace CV_Manager.Models {
    public class BaseCV {
        [Required]
        [StringLength(100)]
        [MinLength(3)]
        public string firstName { get; set; }
        [Required]
        [StringLength(100)]
        [MinLength(3)]
        public string lastName { get; set; }
        [Required]
        public DateTime birthDay { get; set; }

        // Dropdown List
        [Required]
        public string nationality { get; set; }

        // Radio Button
        [Required]
        public string gender { get; set; }

        #region PROGRAMMING SKILLS [CheckBoxes]
        public bool java { get; set; }
        public bool cs { get; set; }
        public bool python { get; set; }
        #endregion

        [Required]
        [EmailAddress]
        [Compare("emailConfirm")]
        public string email { get; set; }
        [Required]
        [EmailAddress]
        [Compare("email")]
        public string emailConfrim { get; set; }


        public string photo { get; set; }
    }
}
