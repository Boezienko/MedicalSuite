using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Person
    {
        public int PersonId {  get; set; }
        [Required(ErrorMessage = "The First Name is required.")]
        [Display(Name ="First Name: ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name is required.")]
        [Display(Name ="Last Name: ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email is required.")]
        [Display(Name = "Email: ")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "The Password is required.")]
        [Display(Name = "Password: ")]
        public string Password {  get; set; }
        [Required]
        public string Telephone { get; set; }
        public int RoleId {  get; set; }
        public DateTime LastLoginTime { get; set; }
        public int prescriptionId {  get; set; }

    }
}
