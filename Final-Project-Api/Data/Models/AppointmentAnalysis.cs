using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{

   
    public class AppointmentAnalysis
    {
      
        
        public int AppointmentId { get; set; }
       
        public int AnalysisTypeId { get; set; }

        public Appointment Appointment { get; set; }

        public AnalysisType AnalysisType { get; set; }

       






    }
}
