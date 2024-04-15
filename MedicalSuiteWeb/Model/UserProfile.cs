using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class UserProfile : UserProfileBase
    {
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; } // Add a property for the last name
    }
}
