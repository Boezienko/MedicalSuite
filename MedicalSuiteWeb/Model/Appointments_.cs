using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Appointments_
    {
        public int AppointmentId {  get; set; }
        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Display(Name = "Appointment Time")]
        public TimeSpan AppointmentTime { get; set;}
        public string AppointmentNotes { get; set;}
        public string DoctorsName { get; set; }
        public int PersonId { get; set; }
    }
}
