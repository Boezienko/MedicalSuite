using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Prescription
    {
        [Display(Name = "Prescription ID: ")]
        public int PrescriptionId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Prescription Name: ")]
        public string PrescriptionName { get; set; }
        [Required(ErrorMessage = "Strength is required")]
        [Display(Name = "Prescription Strength: ")]
        public string PrescriptionStrength { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Prescription Quantity: ")]
        public string PrescriptionQuantity {  get; set; }
        [Required(ErrorMessage = "Direction are required")]
        [Display(Name = "Prescription Directions: ")]
        public string PrescriptionDirections { get; set; }
        [Required(ErrorMessage = "Written Date is required")]
        [Display(Name = "Written Date: ")]
        public DateTime WrittenDate { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        [Display(Name = "Expiration Date: ")]
        public DateTime ExpirationDate { get; set; }
        [Required(ErrorMessage = "Prescription Schedule is required")]
        [Display(Name = "Prescription Category: ")]
        public int PrescriptionScheduleId { get; set; }
        [Required(ErrorMessage = "PersonId is required")]
        [Display(Name = "Person ID: ")]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "DoctorsName is required")]
        [Display(Name = "Doctor: ")]
        public string DoctorsName { get; set; }

    }
}
