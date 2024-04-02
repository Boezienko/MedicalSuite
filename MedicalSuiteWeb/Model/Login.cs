using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Login
    {
        [Required(ErrorMessage = "email is required.")]
        [Display(Name = "Email: ")]

        public string Email { get; set; }
        [Required(ErrorMessage = "password is required.")]
        [Display(Name = "Password: ")]

        public string Password { get; set; }
    }
}
