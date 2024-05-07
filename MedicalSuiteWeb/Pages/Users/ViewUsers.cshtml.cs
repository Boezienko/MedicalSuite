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
                string cmdText = "SELECT PersonId, FirstName, LastName, Email, Telephone, LastLoginTime FROM Person";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new Person();

                        user.PersonId = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.Telephone = reader.GetString(4);
                        user.LastLoginTime = reader.GetDateTime(5);

                        Users.Add(user);


                    }
                }
            }
        }
    }
}
