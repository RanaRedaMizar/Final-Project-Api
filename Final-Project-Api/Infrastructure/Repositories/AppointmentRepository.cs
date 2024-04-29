using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Helpers;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Appointment AddNewAppointment(AppointmentDTO newAppointment)
        {
            if (newAppointment != null)
            {
                var appointment = new Appointment
                {
                    booked = newAppointment.booked,
                    DoctorId = newAppointment.DoctorId,
                    Day = newAppointment.Day,
                    Price = newAppointment.Price,
                    Date = newAppointment.Date,
                };

                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                return appointment;
            }

            throw new ArgumentNullException(nameof(newAppointment), "New appointment data cannot be null.");
        }


        public Appointment UpdateAppointment(int id, AppointmentDTO updatedAppointment)
        {
            var existingAppointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);

            if (existingAppointment != null)
            {
                if (existingAppointment.booked == false)
                {
                    existingAppointment.Price = updatedAppointment.Price;
                    existingAppointment.booked = updatedAppointment.booked;
                    existingAppointment.Day = updatedAppointment.Day;
                    existingAppointment.Date = updatedAppointment.Date;
                    _context.SaveChanges();


                    var appointment = new Appointment
                    {
                        AppointmentId = existingAppointment.AppointmentId,
                        booked = existingAppointment.booked,
                        Day = existingAppointment.Day,
                        Price = updatedAppointment.Price,
                        Date = updatedAppointment.Date,
                    };
                    return appointment;
                }
                else
                {
                    Console.WriteLine("It Can't be updated");
                }
            }
            return null;
        }



        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            if (appointment != null)
            {
                if (appointment.booked == false)
                {
                    _context.Appointments.Remove(appointment);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("It Can't be removed");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }


        public List<Appointment> GetAllAppointments()
        {
            var appointments = _context.Appointments.ToList();
            return appointments;
        }



        public async Task<AppointmentDTO> GetAppoinment(int id)
        {

            try
            {
                var appointment = await _context.Appointments.FirstOrDefaultAsync(p => p.AppointmentId == id);

                if (appointment == null)
                {
                    return null;
                }

                var appointmentDto = new AppointmentDTO
                {
                    booked = appointment.booked,
                    Day = appointment.Day,
                    DoctorId = appointment.DoctorId,
                    Price = appointment.Price,
                    Date = appointment.Date
                };

                return appointmentDto;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Appointment> SearchAppoinments(WeekDaysEnum day)
        {
            var appointments = _context.Appointments.Where(a => a.Day == day).ToList();
            return appointments;
        }



    }
}

