using CommonShared;
using Microsoft.AspNetCore.Mvc;
using QuarterService.Application.Futures.Requests;

namespace QuarterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuturesController : ControllerBaseApi
    {
        [HttpPost]
        public async Task<IActionResult> RegistrationUser(GetDifferenseFuturesRequest request)
        {
            var responce = await Mediator.Send(request);
            return Ok(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GatewayTest()
        {
            return Ok("ОК");
        }
    }

}
