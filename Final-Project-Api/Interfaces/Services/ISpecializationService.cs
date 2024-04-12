using Final_Project_Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Interfaces.Services
{
    public interface ISpecializationService
    {
        Task<IActionResult> GetAll();
        Task<Specialization> AddNewSpecialization(Specialization specialization);
       bool DeleteSpecilization(int specializationId);
        Task<List<Specialization>> TopSpecilization();
    }

}
