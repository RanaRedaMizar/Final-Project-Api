using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface ISpecializationRepository
    {
        Task<List<Specialization>> GetAll();
        Task<Specialization> AddNewSpecialization(Specialization specialization);
       bool DeleteSpecilization(int specializationId);
        Task<List<Specialization>> TopSpecilization();
    }
}
