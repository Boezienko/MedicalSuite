using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;


namespace MedicalSuiteWeb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Person NewPerson { get; set; }
        public void OnGet()
        {
            //NewPerson.FirstName = "Please enter your first name";
        }      

        public IActionResult OnPost()

        {
            if (ModelState.IsValid)
            {
                // Check if email already exists in DB

                if (EmailDNE(NewPerson.Email)) //DNE - Does Not Exist
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "The email address already exists, please try another.");
                    return Page();
                }

            }
            else
            {
                return Page();
            }
        }

        private void RegisterUser()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                //2. Create a insert command
                string cmdText = "INSERT INTO Person(FirstName, LastName, Email, PasswordHash, Telephone, LastLoginTime, RoleId)" +
                    "VALUES(@firstName, @lastName, @email, @password, @telephone, @lastLoginTime, 3)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.generatePasswordHash(NewPerson.Password));               
                cmd.Parameters.AddWithValue("@telephone", NewPerson.Telephone);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now.ToString());
               
                //3. Open the database 
                conn.Open();
                //4.Execute the command 
                cmd.ExecuteNonQuery();
                //5. Close the database
                conn.Close();
            }
        }

        private bool EmailDNE(string email) // Check given email. If it already exists ret false. Otherwise ret true.
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
