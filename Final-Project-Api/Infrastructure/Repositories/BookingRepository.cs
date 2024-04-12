using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddNewBookingAsync(BookingDTO bookingDto)
        {

            var booking = new Booking
            {
                Status = bookingDto.Status,
                Price = bookingDto.FinalPrice,
                Appointment = bookingDto.Appointment,
                Patient = bookingDto.Patient,
                TotalBookings = bookingDto.TotalBookings,
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<int> BookingCountAsync(string patientId)
        {
            return await _context.Bookings.CountAsync(b => b.PatientId == patientId);
        }

        public async Task<int> BookingCountByDoctorAsync(string doctorId)
        {
            return await _context.Bookings.CountAsync(d => d.PatientId == doctorId);
        }

        public async Task<Booking> CancelBookingAsync(int bookingId, string DoctorId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            var doctor = await _context.Doctors.FindAsync(DoctorId);
            if (booking != null && doctor != null)
            {
                booking.Status = BookingStatusEnum.Cancelled;
                await _context.SaveChangesAsync();
            }
            return booking;
        }

        public async Task<Booking> ConfirmBookingAsync(int bookingId, string DoctorId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            var doctor = await _context.Doctors.FindAsync(DoctorId);

            if (booking != null && doctor != null)
            {
                booking.Status = BookingStatusEnum.Completed;
                await _context.SaveChangesAsync();
            }
            return booking;
        }

        public async Task<List<Booking>> GetAllBookingsByDocIdAsync(string doctorId)
        {
            return await _context.Bookings.Where(b => b.Appointment.Doctor.Id == doctorId)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetAllBookingsByPatientIdAsync(string patientId)
        {
            return await _context.Bookings.Where(b => b.PatientId == patientId).ToListAsync();
        }

        public async Task<List<Booking>> SearchBookingsByDocIdAsync(string doctorId)
        {
            return await _context.Bookings.Where(b => b.Appointment.Doctor.Id == doctorId)
                .ToListAsync();
        }

        public async Task<List<Booking>> SearchBookingsByPatientIdAsync(string patientId)
        {

            return await _context.Bookings.Where(b => b.PatientId == patientId)
                .ToListAsync();
        }
    }
}

