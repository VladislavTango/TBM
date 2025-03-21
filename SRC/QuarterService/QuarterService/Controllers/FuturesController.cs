using CommonShared;
using Microsoft.AspNetCore.Mvc;
using QuarterService.Application.Futures.Requests;

namespace QuarterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuturesController : ControllerBaseApi
    {
        [HttpPost("GetDifferenseFutures")]
        public async Task<IActionResult> GetDifferenseFutures(GetDifferenseFuturesRequest request)
        {
            var responce = await Mediator.Send(request);
            return Ok(responce);
        }
        [HttpGet("GatewayTest")]
        public async Task<IActionResult> GatewayTest()
        {
            return Ok("ОК");
        }
    }

}
