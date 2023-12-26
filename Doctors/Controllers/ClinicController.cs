using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/clinics")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpGet]
        public IActionResult GetClinics()
        {
            var clinics = _clinicService.GetClinics();
            return Ok(clinics);
        }

        [HttpGet("{id}")]
        public IActionResult GetClinicById(int id)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound();
            }

            return Ok(clinic);
        }

        [HttpPost]
        public IActionResult AddClinic([FromBody] Clinic clinic)
        {
            _clinicService.AddClinic(clinic);
            return CreatedAtAction(nameof(GetClinicById), new { id = clinic.ClinicId }, clinic);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClinic(int id, [FromBody] Clinic updatedClinic)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound();
            }

            _clinicService.UpdateClinic(updatedClinic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClinic(int id)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound();
            }

            _clinicService.DeleteClinic(id);
            return NoContent();
        }
    }

}
