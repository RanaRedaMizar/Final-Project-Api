using Final_Project_Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Final_Project_Api.Data.Models
{
    public class Appointment
    {
        [Key,Required]
        public int  Id { get; set; }
        public WeekDaysEnum Day { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public bool booked { get; set; } = false;
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public ICollection<AppointmentTime> AppointmentTimes { get; set; }
        public virtual ICollection<AnalysisType> AnalysisTypes { get; set; } 
        public virtual ICollection<Disease> Diseases { get; set; } 
        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual List<AppointmentMedicine> AppointmentMedicines { get; set; }
        public virtual List<AppointmentAnalysis> AppointmentAnalysiss { get; set; }
        public virtual List<AppointmentDiagnose> AppointmentDiagnoses { get; set; } 




    }

}
