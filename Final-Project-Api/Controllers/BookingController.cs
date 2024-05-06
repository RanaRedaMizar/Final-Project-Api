using Final_Project_Api.Data;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly AppDbContext dbContext;

       

        public BookingController(IBookingService bookingService, AppDbContext dbContext)
        {
            _bookingService = bookingService;
            this.dbContext = dbContext;
        }



        [HttpGet("BookingCount")]
        public async Task<IActionResult> BookingCount(string patientId)
        {
            try
            {
                var count = await _bookingService.BookingCountAsync(patientId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("GetAllBookingsByDocId")]
        public async Task<IActionResult> GetAllBookingsByDocId(string doctorId)
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsByDocIdAsync(doctorId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("GetAllBookingsByPatientId")]
        public async Task<IActionResult> GetAllBookingsByPatientId(string patientId)
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsByPatientIdAsync(patientId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("SearchBookingsByDocId")]
        public async Task<IActionResult> SearchBookingsByDocId(string doctorId)
        {
            try
            {
                var bookings = await _bookingService.SearchBookingsByDocIdAsync(doctorId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("SearchBookingsByPatientId")]
        public async Task<IActionResult> SearchBookingsByPatientId(string patientId)
        {
            try
            {
                var bookings = await _bookingService.SearchBookingsByPatientIdAsync(patientId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpPost("AddBooking")]
        public async Task<IActionResult> AddBooking(string patientId, int appointmentId)
        {
            try
            {
                var patient = dbContext.Patients.Find(patientId);
                var appointment = dbContext.Appointments.Find(appointmentId);

                if (patient != null && appointment != null)
                {
                    var newBooking = new Booking
                    {
                        Status = BookingStatusEnum.Pending,
                        //TotalBookings = patient.Bookings.Count + 1,
                        Price =  appointment.Price,
                        AppointmentId = appointmentId,
                        PatientId = patientId,
                        Patient = patient,
                        Appointment = appointment,
                    };

                    dbContext.Bookings.Add(newBooking);
                    appointment.booked = true;

                    dbContext.SaveChanges();

                    return Ok(newBooking);
                }

                return NotFound("Patient or appointment not found");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost("AddAppointmentDiagnose")]
        public IActionResult AddAppointmentDiagnose(int bookingid, int diseaseid, string diagnosesReport)
        {
            try
            {
                var booking = dbContext.Bookings.FirstOrDefault(b => b.BookingId == bookingid);
            var diagnose = dbContext.Diseases.FirstOrDefault(a => a.DiseaseId == diseaseid);
           
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
                dbContext.AppointmentDiagnoses.Add(appointmentDiagnose);

                booking.Status = BookingStatusEnum.Completed;
                dbContext.SaveChanges();
                return Ok("Disease added to booking successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("AddAppointmentMedicine")]
        public IActionResult AddAppointmentMedicine(int bookingid, int medicineid, string description)
        {
            try
            {
                var booking = dbContext.Bookings.FirstOrDefault(b => b.BookingId == bookingid);
                var medicine = dbContext.Medicines.FirstOrDefault(m => m.MedicineId == medicineid);
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
                dbContext.AppointmentMedicines.Add(appointmentMedicine);


                dbContext.SaveChanges();
                return Ok("Medicine added to booking successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }
        [HttpPost("AddAppointmentAnalysis")]
        public IActionResult AddAppointmentAnalysis(int bookingid, int analysisTypeid)
        {
            try
            {
                var booking = dbContext.Bookings.FirstOrDefault(b => b.BookingId == bookingid);
                var analysis = dbContext.AnalysisTypes.FirstOrDefault(a => a.AnalysisTypeId == analysisTypeid);
                if (booking == null || analysis == null)
                {
                    throw new Exception("Booking or Analysis not found");
                }
                var appointmentAnalysis = new AppointmentAnalysis
                {
                    BookingId = bookingid,
                    AnalysisTypeId = analysisTypeid,

                };
                dbContext.AppointmentAnalyses.Add(appointmentAnalysis);

                booking.Status = BookingStatusEnum.Completed;

                dbContext.SaveChanges();
                return Ok("Analysis added to booking successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("CancelBooking")]
        public async Task<IActionResult> CancelBooking(int bookingId, string doctorId)
        {
            try
            {
                var result = await _bookingService.CancelBookingAsync(bookingId, doctorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpPut("ConfirmBooking")]
        public async Task<IActionResult> ConfirmBooking(int bookingId, string docID)
        {
            try
            {
                var result = await _bookingService.ConfirmBookingAsync(bookingId, docID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


       
    }
}

