
using CaseBasedSchedule.Application.Contracts;
using CaseBasedSchedule.Application.Models;

using Microsoft.AspNetCore.Mvc;

namespace CaseBasedSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionersController : ControllerBase
    {

        private readonly IPractitionerService _practitionerService;

        public PractitionersController(IPractitionerService practitionerService)
        {
            _practitionerService = practitionerService;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPractitionersAsync()
        {
            try
            {
                return Ok(await _practitionerService.GetPractitonerModels());
            }catch (Exception ex) {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> AddPractitoner([FromBody] PractionerRequest practionerRequest)
        {
            try
            {
                return Ok(await _practitionerService.AddPractitionerAsync(practionerRequest));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpPut]
        public async Task<IActionResult> UpdatePractitoner([FromQuery] string id, [FromBody] PractionerRequest practionerRequest)
        {
            try
            {
                await _practitionerService.UpdatePractitionerAsync(id, practionerRequest);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePractitoner([FromQuery] string id)
        {
            try
            {
                await _practitionerService.DeletePractitionerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
    }
}
