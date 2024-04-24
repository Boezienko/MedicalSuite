﻿using System.ComponentModel.DataAnnotations;

namespace MedicalSuiteWeb.Model
{
    public class Appointment // This is our model for the appointments - gage
    {
        [Required]
        [Display(Name = "Appointment ID: ")]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Appointment Date: ")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [Display(Name = "Appointment Time: ")]
        public TimeSpan AppointmentTime { get; set; }

        [Required]
        [Display(Name = "Person ID: ")]
        public int PersonId { get; set; }

    }
}
