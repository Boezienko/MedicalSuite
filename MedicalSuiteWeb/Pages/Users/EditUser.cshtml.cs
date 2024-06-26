using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace MedicalSuiteWeb.Pages.Users
{
    [BindProperties]

    [Authorize(Roles = "Doctor, Nurse")]
    public class EditUserModel : PageModel
    {
        public EditPerson user { get; set; } = new EditPerson();
        public void OnGet(int id)
        {
            PopulateUser(id);
        }

        public IActionResult OnPost(int id) {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE PERSON SET FirstName = @firstName, LastName = @lastName, Email = @email, Telephone = @telephone WHERE PersonId = @personId ";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@telephone", user.Telephone);
                    cmd.Parameters.AddWithValue("@personId", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewUsers");
                }
            }
            else
            {
                return Page();
            }
        }

        private void PopulateUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Telephone FROM Person WHERE PersonId = @personId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@personId", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.FirstName = reader.GetString(0);
                        user.LastName = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Telephone = reader.GetString(3);
                    }
                }
            }
        }
    }
}
