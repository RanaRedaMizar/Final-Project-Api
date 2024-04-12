using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Services;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        private readonly AppDbContext _dbContext;

        public SpecializationController(ISpecializationService specializationService, AppDbContext dbContext)
        {
            _specializationService = specializationService;
            _dbContext = dbContext;
        }


        [HttpGet("GetAllSpecialization")]
        public async Task<IActionResult> GetAll()
        {


            try
            {
                var result = await _specializationService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
            
        }

        [HttpGet("TopSpecilization")]
        public async Task<ActionResult> TopSpecilization()
        {
            try
            {
                var result = await _specializationService.TopSpecilization();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpPost("AddSpecialization")]
        public async Task<IActionResult> AddNewSpecilization([FromForm] SpecializeDto specialization)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var specializeToAdd = new Specialization
                {
                    //Id= specialization.Id,
                    
                    Title = specialization.Title,
                   
                };

                var result = _specializationService.AddNewSpecialization(specializeToAdd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpDelete("DeleteSpecilization")]

        public async Task<IActionResult> DeleteSpecilization(int id)
        {
            try
            {
                var result = _specializationService.DeleteSpecilization(id);

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
