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

        //Generated a unique person id
        private int GeneratePersonId()
        {
            // Generate a unique PersonId
            Random random = new Random();
            return random.Next(3, 100);
        }

        public ActionResult OnPost() 

        {
            if (ModelState.IsValid)
            {
                int personId = GeneratePersonId();
                //Insert data into database
                //1. Creat a database connection string
                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=MedicalDB;Trusted_Connection=true;";
                SqlConnection conn = new SqlConnection(connString);
                //2. Create a insert command
                string cmdText = "INSERT INTO Person(PersonId, FirstName, LastName, Email, PasswordHash, Telephone, LasLoginTime, PrescriptionId, RoleId)" +
                    "VALUES(@personId, @firstName, @lastName, @email, @password, @telephone, @lastLoginTime, 1, 1)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.generatePasswordHash(NewPerson.Password));
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@telephone", NewPerson.Telephone);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@personId", personId);
                //3. Open the database 
                conn.Open();
                //4.Execute the command 
                cmd.ExecuteNonQuery();
                //5. Close the database
                conn.Close();
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }
    }
}
