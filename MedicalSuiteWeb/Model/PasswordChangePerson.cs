using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class PasswordChangePerson
    {
        public string Email { get; set; }
        [Display(Name = "Password: ")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{10,}$", ErrorMessage = "Password must be at least 10 characters long and contain at least one number, one lowercase letter, and one uppercase letter.")]
        public string Password { get; set; }
    }
}
