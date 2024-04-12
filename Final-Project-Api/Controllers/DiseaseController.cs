using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Data;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Final_Project_Api.Infrastructure.Services;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;
        private readonly AppDbContext _dbContext;
        public DiseaseController(IDiseaseService diseaseService, AppDbContext dbContext)
        {
            _diseaseService = diseaseService;
            _dbContext = dbContext;
        }

        [HttpGet("GetAllDisease")]
        public async Task<IActionResult> GetAll()
        {


            try
            {
                var result = await _diseaseService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

        }




        [HttpPost("AddDisease")]
        public async Task<IActionResult> AddNewDisease([FromForm] DiseaseDTO disease)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var diseaseToAdd = new Disease
                { 
                     Name = disease.Name,
                    Description = disease.Description,
                    Type = disease.Type,



                };

                var result = _diseaseService.AddNewDisease(diseaseToAdd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDisease")]
        public async Task<IActionResult> DeleteDisease(int id)
        {
            try
            {
                var result = _diseaseService.DeleteDisease(id);

                if (!result)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



    }
}
