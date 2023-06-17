using Microsoft.AspNetCore.Mvc.Rendering;

namespace CV_Manager.Data {
    public class CVLists {

        public static IEnumerable<SelectListItem> nationalities = new List<SelectListItem>() {
            new SelectListItem{Value = "LB", Text = "Lebanese"},
            new SelectListItem{Value = "JP", Text = "Japanese"},
            new SelectListItem{Value = "FR", Text = "French"},
            new SelectListItem{Value = "O", Text = "Other"}
        };

        public static IEnumerable<SelectListItem> genders = new List<SelectListItem>() {
            new SelectListItem{Value = "M", Text = "Male"},
            new SelectListItem{Value = "F", Text = "Female"},
            new SelectListItem{Value = "AH", Text = "Attack Helicopter"},
            new SelectListItem{Value = "O", Text = "Other"}
        };

        public static IEnumerable<SelectListItem> skills = new List<SelectListItem>() {
            new SelectListItem{Value = "cs", Text = "C#"},
            new SelectListItem{Value = "java", Text = "Java"},
            new SelectListItem{Value = "py", Text = "Python"},
            new SelectListItem{Value = "beef", Text = "Beef"}
        };
    }
}
