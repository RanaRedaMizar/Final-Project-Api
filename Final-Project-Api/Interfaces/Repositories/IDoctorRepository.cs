using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        List<Doctor> GetDoctors(int page, int pageSize, string search);
        Doctor GetDoctor(string id);
        bool AddDoctor(DoctorDTO AddedDoctorDto);
        bool UpdateDoctor(string id, DoctorDTO Doctor);
        bool DeleteDoctor(string id);
        Doctor SearchDoctor(string name);
        List<Doctor> TopDoctors();
        int CountDoctors();
        void ConfirmCheckup();
    }
}
