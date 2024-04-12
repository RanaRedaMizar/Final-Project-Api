using Final_Project_Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Interfaces.Services
{
    public interface IDiseaseService
    {
        Task<IActionResult> GetAll();
        Task<Disease> AddNewDisease(Disease disease);
       bool DeleteDisease(int diseaseId);
    }
}
