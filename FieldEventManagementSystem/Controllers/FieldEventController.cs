using System.Numerics;
using System.Transactions;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FieldEventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldEventController : ControllerBase
    {
        private readonly ILogger<FieldEventController> _logger;
        private readonly IFieldEventService _fieldEventService;

        public FieldEventController(ILogger<FieldEventController> logger, IFieldEventService fieldEventService)
        {
            _logger = logger;
            _fieldEventService = fieldEventService;
        }

        [HttpPost, Route("send")]
        public async Task<IActionResult> SendFieldEvent([FromBody] FieldEventDetails request)
        {

            try
            {
                // send field event details
                var fieldEventId = await _fieldEventService.SaveFieldEvent(request);

                if (fieldEventId != null)
                {
                    return Ok(new { success = true, fieldEventId });
                }
                else 
                {
                    return Ok(new { success = false });
                }
            }

            catch (Exception ex)
            {
                await _fieldEventService.Log(ex.Message, request.UserId);
                return StatusCode(500, $"An error occurred while saved field event: {ex.Message}");
            }
           
         
        }
    }
}
