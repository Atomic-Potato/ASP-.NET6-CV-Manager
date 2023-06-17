namespace CV_Manager.Data {
    public class CV {
        public int id;
        public string firstName;
        public string lastName;
        public DateTime birthDay;

        // Dropdown List
        public string nationality;
           
        // Radio Button
        public string gender;

        #region PROGRAMMING SKILLS [CheckBoxes]
        public bool java;
        public bool cs;
        public bool python;
        #endregion

        public EmailAddressAttribute emailAddress;
        public EmailAddressAttribute confirmEmailAddress;

        public File photo;
    }
}
