using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IDiseaseRepository
    {
        Task<List<Disease>> GetAll();
        Task<Disease> AddNewDisease(Disease disease);
       bool DeleteDisease(int diseaseId);
    }
}
