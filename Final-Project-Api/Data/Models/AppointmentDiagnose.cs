using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public class AppointmentDiagnose
    {
       
        public string DiagnosesReport { get; set; } = null!;

        public int AppointmentId { get; set; }

        public int DiseaseId { get; set; }

        public Appointment Appointment { get; set; }

        public Disease Disease { get; set; }


    }
}
