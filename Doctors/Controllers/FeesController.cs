using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/fees")]
    public class FeesController : ControllerBase
    {
        private readonly IFeesService _feesService;

        public FeesController(IFeesService feesService)
        {
            _feesService = feesService;
        }

        [HttpGet]
        public IActionResult GetFees()
        {
            var fees = _feesService.GetFees();
            return Ok(fees);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeesById(int id)
        {
            var fee = _feesService.GetFeesById(id);
            if (fee == null)
            {
                return NotFound();
            }

            return Ok(fee);
        }

        [HttpPost]
        public IActionResult AddFee([FromBody] Fees fee)
        {
            _feesService.AddFee(fee);
            return CreatedAtAction(nameof(GetFeesById), new { id = fee.DoctorFeeId }, fee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFee(int id, [FromBody] Fees updatedFee)
        {
            var fee = _feesService.GetFeesById(id);
            if (fee == null)
            {
                return NotFound();
            }

            _feesService.UpdateFee(updatedFee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFee(int id)
        {
            var fee = _feesService.GetFeesById(id);
            if (fee == null)
            {
                return NotFound();
            }

            _feesService.DeleteFee(id);
            return NoContent();
        }
    }

}
