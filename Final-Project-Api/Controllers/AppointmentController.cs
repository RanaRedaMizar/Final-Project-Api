using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Services;
using Final_Project_Api.Interfaces.Helpers;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IJwtHelpService jwtHelpService;

        public AppointmentController(
            IAppointmentService appointmentService,
            IHttpContextAccessor httpContextAccessor,
            IJwtHelpService jwtHelpService
        )
        {
            this.jwtHelpService = jwtHelpService;
            this.httpContextAccessor = httpContextAccessor;
            this.appointmentService = appointmentService;
        }

        [HttpGet("searchAppoinment")]
        public async Task<IActionResult> SearchAppointments(WeekDaysEnum day)
        {
            try
            {

                var appointments = appointmentService.SearchAppointments(day);

                if (appointments == null || !appointments.Any())
                {
                    return NotFound();
                }

                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments = appointmentService.GetAllAppointments();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpGet("GetAppointment/{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            try
            {
                var appointment = await appointmentService.GetAppoinmentById(id);

                if (appointment == null)
                    return NotFound();

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpPost]
        public async Task<IActionResult> AddNewAppointment([FromBody] AppointmentDTO newAppointment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var addedAppointment = appointmentService.AddNewAppointment(newAppointment);

                return Ok(addedAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDTO updatedAppointment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = appointmentService.UpdateAppointment(id, updatedAppointment);
                if (result is null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                appointmentService.DeleteAppointment(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
