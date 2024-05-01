using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Person
    {
        public int PersonId {  get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name ="First Name: ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name ="Last Name: ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email: ")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password: ")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{10,}$", ErrorMessage = "Password must be at least 10 characters long and contain at least one number, one lowercase letter, and one uppercase letter.")]
        public string Password {  get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        [Display(Name = "Telephone: ")]
        public string Telephone { get; set; }
        public int RoleId {  get; set; }
        public DateTime LastLoginTime { get; set; }
        public int prescriptionId {  get; set; }

    }
}
