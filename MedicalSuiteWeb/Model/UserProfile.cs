using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class UserProfile
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; } // Add a property for the last name 
        // make commit
    }
}
