using System.Net.Mail;
using System.Security.Policy;

namespace CV_Manager.Data {
    public class CV {
        [Key]
        public int cvId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDay { get; set; }

        // Dropdown List
        public string nationality { get; set; }
           
        // Radio Button
        public string gender { get; set; }

        #region PROGRAMMING SKILLS [CheckBoxes]
        public bool java { get; set; }
        public bool cs { get; set; }
        public bool python { get; set; }
        #endregion

        [EmailAddress]
        public string email { get; set; }

        public string photo { get; set; }
    }
}
