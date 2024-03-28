namespace MedicalSuiteWeb.Model
{
    public class Person
    {
        public int PersonId {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Password {  get; set; }
        public string Telephone { get; set; }
        public int RoleId {  get; set; }
        public DateTime LastLoginTime { get; set; }
        public int prescriptionId {  get; set; }

    }
}
