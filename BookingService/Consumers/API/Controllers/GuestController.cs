using Application;
using Application.Guest.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _manager;

        public GuestController(
            ILogger<GuestController> logger, 
            IGuestManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO dto)
        {
            var request = new CreateGuestRequest()
            {
                Data = dto
            };

            var res = await _manager.CreateGuest(request);

            if (res.IsSuccess) return Created("", res.Data);

            if (res.ErrorCode == ErrorCodes.NOT_FOUND) return BadRequest(res);

            _logger.LogError("Response with unknown ErrorCode Returned");
            return BadRequest(500);

        }
    }
}
