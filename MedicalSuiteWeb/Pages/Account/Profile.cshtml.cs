using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Claims;

namespace MedicalSuiteWeb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UserProfile profile { get; set; }
        public void OnGet()
        {
            PopulateProfile();
        }


        private void PopulateProfile()
        {
            //Query the person table to populate "profile" object

            string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Phone, LastLoginTime FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    profile.FirstName = reader.GetString(0);
                }
            }
        }
    }
}
