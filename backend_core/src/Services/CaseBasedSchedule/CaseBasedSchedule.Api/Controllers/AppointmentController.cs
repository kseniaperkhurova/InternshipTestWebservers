using CaseBasedSchedule.Application.Contracts;
using CaseBasedSchedule.Application.Models;


using Microsoft.AspNetCore.Mvc;


namespace CaseBasedSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        [Route("client")]
        public async Task<IActionResult> GetAllClientsAppointmentsForTimeRange([FromQuery] string id, [FromQuery] string startDate, [FromQuery] string endDate)
        {
            try
            {

                var list = await _appointmentService.GetClientAppointmentForTimeRangeAsync(_appointmentService.CreateAppointmentRequest(id, startDate, endDate));
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.StackTrace);
            }


        }
        [HttpGet]
        [Route("practitioner")]
        public async Task<IActionResult> GetAllPractotionerAppointmentsForTimeRange([FromQuery] string id, [FromQuery] string startDate, [FromQuery] string endDate )
        {
            try
            {
                
                var list = await _appointmentService.GetPractitionerAppointmentForTimeRangeAsync(_appointmentService.CreateAppointmentRequest(id, startDate, endDate));
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }


        }
       

    }
}
