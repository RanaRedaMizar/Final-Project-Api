using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IAppointmentMedicine
    {
        Task<AppointmentMedicine> AddAppointmentMedicine(Medicine medicine);
    }
}
