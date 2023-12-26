using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController:ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = _doctorService.GetDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            _doctorService.AddDoctor(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.DoctorId }, doctor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] Doctor updatedDoctor)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorService.UpdateDoctor(updatedDoctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorService.DeleteDoctor(id);
            return NoContent();
        }
    }
}
