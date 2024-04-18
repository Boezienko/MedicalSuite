using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Microsoft.Data.SqlClient;



namespace MedicalSuiteWeb.Pages.Account
{
    [Authorize]
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
            // query the person table to populate "profile" object

            string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Telephone, LasLoginTime FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    profile.FirstName = reader.GetString(0);
                    profile.LastName = reader.GetString(1);
                    profile.Email = reader.GetString(2);
                    profile.Telephone = reader.GetString(3);
                    profile.LastLoginTime = reader.GetDateTime(4);
                }
            }
        }
    }
}
