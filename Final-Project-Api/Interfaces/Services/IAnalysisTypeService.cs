using Final_Project_Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Interfaces.Services
{
    public interface IAnalysisTypeService
    {
        Task<IActionResult> GetAll();
        Task<AnalysisType> AddNewAnalysisType(AnalysisType analysisType);
       bool DeleteAnalysisType(int analysisTypeId);
        
    }
}
