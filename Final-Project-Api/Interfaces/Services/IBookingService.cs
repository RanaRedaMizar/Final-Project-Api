using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBookingsByPatientIdAsync(string id);
        Task<List<Booking>> GetAllBookingsByDocIdAsync(string id);
        Task<List<Booking>> SearchBookingsByDocIdAsync(string id);
        Task<List<Booking>> SearchBookingsByPatientIdAsync(string id);
        Task<Booking> AddNewBookingAsync(BookingDTO booking);
        Task<Booking> ConfirmBookingAsync(int bookingid, string DoctorId);
        Task<Booking> CancelBookingAsync(int bookingid, string DoctorId);
        Task<int> BookingCountAsync(string patientId);
        Task<int> BookingCountByDoctorAsync(string doctorId);

    }
}
