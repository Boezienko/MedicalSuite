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

        public ActionResult OnPost() 

        {
            if (ModelState.IsValid)
            {
                //Insert data into database
                //1. Creat a database connection string
                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=MedicalSuite;Trusted_Connection=true;";
                SqlConnection conn = new SqlConnection(connString);
                //2. Create a insert command
                string cmdText = "INSERT INTO Person(FirstName, LastName, Email, Password, Telephone,PrescriptionId, RoleId, LastLoginTime)" +
                    "VALUES(@firstName, @lastName, @email, @password, @telephone, 2,2,@lastLoginTime)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratrPasswordHash(NewPerson.Password));
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@telephone", NewPerson.Telephone);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now.ToString());
                //3. Open the database 
                conn.Open();
                //4.Execute the command 
                cmd.ExecuteNonQuery();
                //5. Close the database
                conn.Close();
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
