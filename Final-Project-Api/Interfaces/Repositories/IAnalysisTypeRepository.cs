using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IAnalysisTypeRepository
    {
        Task<List<AnalysisType>> GetAll();
        Task<AnalysisType> AddNewAnalysisType(AnalysisType analysisType);
       bool DeleteAnalysisType(int analysisTypeId);
    }
}
