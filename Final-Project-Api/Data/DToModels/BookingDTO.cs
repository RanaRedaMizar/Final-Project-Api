using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using System.Text.Json.Serialization;

namespace Final_Project_Api.Data.DToModels
{
    public class BookingDTO
    {

        public BookingStatusEnum Status { get; set; } = BookingStatusEnum.Pending;
        public int TotalBookings { get; set; }
        public string FinalPrice { get; set; }
        public Appointment Appointment { get; set; }
        public Patient Patient { get; set; }

    }
}
