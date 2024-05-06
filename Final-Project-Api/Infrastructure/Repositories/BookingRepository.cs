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
                Appointment = bookingDto.Appointment,
                Patient = bookingDto.Patient,
              //  TotalBookings = bookingDto.TotalBookings,
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
        public void AddAppointmentMedicine(int bookingid, int medicineid, string description)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingid);
            var medicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == medicineid);
            if (booking == null || medicine == null) 
                {
                throw new Exception("Booking or Medicine not found");
                }
            var appointmentMedicine = new AppointmentMedicine
            {
                BookingId = bookingid,
                MedicineId = medicineid,
                Description = description
            };
            _context.AppointmentMedicines.Add(appointmentMedicine);

            booking.Status = BookingStatusEnum.Completed;

            _context.SaveChanges();

        }

        public void AddAppointmentAnalysis(int bookingid, int analysisTypeid) 
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingid);
            var analysis = _context.AnalysisTypes.FirstOrDefault(a => a.AnalysisTypeId == analysisTypeid);
            if (booking == null || analysis == null)
            {
                throw new Exception("Booking or Analysis not found");
            }
            var appointmentAnalysis = new AppointmentAnalysis
            {
                BookingId = bookingid,
                AnalysisTypeId = analysisTypeid,
                
            };
            _context.AppointmentAnalyses.Add(appointmentAnalysis);

            booking.Status = BookingStatusEnum.Completed;

            _context.SaveChanges();

        }
        public void AddAppointmentDiagnose(int bookingid, int diseaseid, string diagnosesReport)
        {

            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingid);
            var diagnose = _context.Diseases.FirstOrDefault(a => a.DiseaseId == diseaseid);
            if (booking == null || diagnose == null)
            {
                throw new Exception("Booking or Disease not found");
            }
            var appointmentDiagnose = new AppointmentDiagnose
            {
                BookingId = bookingid,
                DiseaseId = diseaseid,
                DiagnosesReport = diagnosesReport,

            };
            _context.AppointmentDiagnoses.Add(appointmentDiagnose);

            booking.Status = BookingStatusEnum.Completed;

            _context.SaveChanges();

        }
    }
}

