using System.Security.Claims;

namespace MedicalSuiteWeb.Pages
{
    public class LayoutAuthorizer
    {
        static public string GetLayoutFromRole(string userRole)
        {
            string layout = String.Empty;
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

