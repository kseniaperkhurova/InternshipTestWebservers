
using CaseBasedSchedule.Application.Contracts;

using Microsoft.AspNetCore.Mvc;


namespace CaseBasedSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClientsAsync()
        {
            try
            {
                return Ok(await _clientService.GetClientModels());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

      
        
     
        
    }
}
