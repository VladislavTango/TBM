using CommonShared;
using Microsoft.AspNetCore.Mvc;
using QuarterService.Application.Futures.Requests;

namespace QuarterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBaseApi
    {
        [HttpPost("FuturesDiff")]
        public async Task<IActionResult> RegistrationUser(GetDifferenseFuturesRequest request)
        {
            var responce = await Mediator.Send(request);
            return Ok(responce);
        }
    }
}
