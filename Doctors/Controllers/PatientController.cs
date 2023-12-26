using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = _patientService.GetPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] Patient patient)
        {
            _patientService.AddPatient(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Patient updatedPatient)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientService.UpdatePatient(updatedPatient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientService.DeletePatient(id);
            return NoContent();
        }
    }

}
