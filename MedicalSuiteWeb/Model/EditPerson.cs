using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class EditPerson
    {
       
        //[Display(Name = "Password: ")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{10,}$", ErrorMessage = "Password must be at least 10 characters long and contain at least one number, one lowercase letter, and one uppercase letter.")]
        public string Password { get; set; }
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Telephone { get; set; }
        public int RoleId { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int prescriptionId { get; set; }
    }
}
