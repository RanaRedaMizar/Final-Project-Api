using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Data;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Project_Api.Infrastructure.Services;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineService _medicineService;
        private readonly AppDbContext _dbContext;
        public MedicineController(IMedicineService medicineService, AppDbContext dbContext)
        {
            _medicineService = medicineService;
            _dbContext = dbContext;
        }

        [HttpGet("GetAllMedicine")]
        public async Task<IActionResult> GetAll()
        {


            try
            {
                var result = await _medicineService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

        }




        [HttpPost("AddMedicine")]
        public async Task<IActionResult> AddNewMedicine([FromForm] MedicineDTO medicine)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var medicineToAdd = new Medicine
                {
                    GenericName = medicine.GenericName,
                    BrandName = medicine.BrandName,
                    Type = medicine.Type,

                };

                var result = _medicineService.AddNewMedicine(medicineToAdd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteMedicine")]
       
         public async Task<IActionResult> DeleteMedicine(int id)
        {
            try
            {
                var result = _medicineService.DeleteMedicine(id);

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
