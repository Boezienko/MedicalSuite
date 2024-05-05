using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalSuiteWeb.Pages.Users
{
    [Authorize(Roles = "Doctor, Nurse")]

    [BindProperties]
    public class ViewUsersModel : PageModel
    {
        public List<Person> Users { get; set; } = new List<Person>();
        public void OnGet()
        {
            populateUsers();
        }

        private void populateUsers()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Telephone, LastLoginTime FROM Person";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new Person();


                        user.FirstName = reader.GetString(0);
                        user.LastName = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Telephone = reader.GetString(3);
                        user.LastLoginTime = reader.GetDateTime(4);

                        Users.Add(user);


                    }
                }
            }
        }
    }
}
