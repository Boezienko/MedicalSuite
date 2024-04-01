using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Login
    {
        [Required(ErrorMessage = "email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required.")]
        public string Password { get; set; }
    }
}
