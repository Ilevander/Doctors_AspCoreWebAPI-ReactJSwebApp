using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/schedules")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public IActionResult GetSchedules()
        {
            var schedules = _scheduleService.GetSchedules();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public IActionResult GetScheduleById(int id)
        {
            var schedule = _scheduleService.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [HttpPost]
        public IActionResult AddSchedule([FromBody] Schedule schedule)
        {
            _scheduleService.AddSchedule(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.DoctorScheduleId }, schedule);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchedule(int id, [FromBody] Schedule updatedSchedule)
        {
            var schedule = _scheduleService.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _scheduleService.UpdateSchedule(updatedSchedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(int id)
        {
            var schedule = _scheduleService.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _scheduleService.DeleteSchedule(id);
            return NoContent();
        }
    }

}
