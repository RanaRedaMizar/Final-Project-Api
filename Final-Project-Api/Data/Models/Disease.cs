﻿using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public class Disease
    {
        [Key,Required]
        public int DiseaseId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual List<AppointmentDiagnose> AppointmentDiagnoses { get; set; } 






    }
}
