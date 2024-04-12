using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAllAppointments();
        Task<AppointmentDTO> GetAppoinment(int id);
        Appointment AddNewAppointment(AppointmentDTO newAppointment);
        Appointment UpdateAppointment(int id, AppointmentDTO newAppointment);
        void DeleteAppointment(int id);
        List<Appointment> SearchAppoinments(WeekDaysEnum day);
    }
}

