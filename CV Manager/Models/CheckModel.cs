namespace CV_Manager.Models {
    public class CheckModel {
        public bool value { get; set; }
        public string text { get; set; }

        public CheckModel(bool value, string text) {
            this.value = value;
            this.text = text;
        }
    }
}
