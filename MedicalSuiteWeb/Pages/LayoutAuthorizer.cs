using System.Security.Claims;

namespace MedicalSuiteWeb.Pages
{
    public class LayoutAuthorizer
    {
        static public string GetLayoutFromRole(HttpContext httpContext)
        {
            string layout = "_Layout";
            string userRole = httpContext.User.FindFirstValue(ClaimTypes.Role).ToString();
            if (userRole.Equals("Patient"))
            {
                layout = "_LayoutPatient"; // Layout for patients
            }
            else if (userRole.Equals("Nurse"))
            {
                layout = "_LayoutNurse"; // Layout for nurses
            }
            else if (userRole.Equals("Doctor"))
            {
                layout = "_LayoutDoctor"; // Layout for doctors
            }
            return layout;
        }
    }
}

