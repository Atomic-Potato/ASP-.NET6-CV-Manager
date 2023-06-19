using System.Net.Mail;
using System.Security.Policy;

namespace CV_Manager.Data {
    public class CV {
        [Key]
        public int cvId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDay { get; set; }
        public string nationality { get; set; }
        public string gender { get; set; }

        public bool java { get; set; }
        public bool cs { get; set; }
        public bool python { get; set; }
        public bool beef { get; set; }

        public string email { get; set; }
        public string photo { get; set; }

        public int grade { get; set; }
    }
}
