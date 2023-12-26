using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult GetAppointments()
        {
            var appointments = _appointmentService.GetAppointments();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointment appointment)
        {
            _appointmentService.AddAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] Appointment updatedAppointment)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.UpdateAppointment(updatedAppointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.DeleteAppointment(id);
            return NoContent();
        }
    }


}
