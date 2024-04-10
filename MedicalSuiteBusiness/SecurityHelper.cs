using BCrypt.Net;
namespace MedicalSuiteBusiness
{
    public class SecurityHelper
    {

        public static string generatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }
      
        public static bool verifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

        public static string GetDBConnectionString()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=MedicalDB;Trusted_Connection=true;";
            return connString;
        }
    }
}
