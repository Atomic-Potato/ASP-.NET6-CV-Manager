using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace CV_Manager.Data {
    public class CVLists {

        public static IEnumerable<SelectListItem> nationalities = new List<SelectListItem>() {
            new SelectListItem{Value = "Lebanon", Text = "Lebanese"},
            new SelectListItem{Value = "Japan", Text = "Japanese"},
            new SelectListItem{Value = "France", Text = "French"},
            new SelectListItem{Value = "unkown country", Text = "Other"}
        };

        public static IEnumerable<SelectListItem> genders = new List<SelectListItem>() {
            new SelectListItem{Value = "Male", Text = "Male"},
            new SelectListItem{Value = "Female", Text = "Female"},
            new SelectListItem{Value = "Attack Helicopter", Text = "Attack Helicopter"},
            new SelectListItem{Value = "unkown gender", Text = "Other"}
        };


        public static IEnumerable<CheckModel> GetSkills() {
            return new List<CheckModel>() {
                new CheckModel(false, "C#"),
                new CheckModel(false, "Java"),
                new CheckModel(false, "Python"),
                new CheckModel(false, "Beef"),
            };
        }
    }
}
