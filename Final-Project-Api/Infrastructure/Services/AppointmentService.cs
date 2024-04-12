using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;

namespace Final_Project_Api.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public Appointment AddNewAppointment(AppointmentDTO newAppointment)
        {
            return appointmentRepository.AddNewAppointment(newAppointment);
        }

        public void DeleteAppointment(int id)
        {
            appointmentRepository.DeleteAppointment(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentRepository.GetAllAppointments();
        }


        public async Task<AppointmentDTO> GetAppoinmentById(int id)
        {
            return await appointmentRepository.GetAppoinment(id);
        }

        public async Task<AppointmentDTO> GetAppointment(int id)
        {
            return await appointmentRepository.GetAppoinment(id);
        }

        public Appointment SearchAppoinments()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> SearchAppointments(WeekDaysEnum day)
        {
            return appointmentRepository.SearchAppoinments(day);
        }

        public Appointment UpdateAppointment(int id, AppointmentDTO updatedAppointment)
        {
            return appointmentRepository.UpdateAppointment(id, updatedAppointment);
        }

        Task<AppointmentDTO> IAppointmentService.GetAppoinment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
