using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email: ")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password: ")]

        public string Password { get; set; }
    }
}
