using Microsoft.AspNetCore.Mvc;
using QuarterService.DataPersistance.AppContext;
using QuarterService.Domain.Entities;

namespace QuarterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDbContext db;

        public ValuesController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpPost("RegistrationCreater")]
        public async Task<IActionResult> RegistrationUser(int request)
        {
            var t = new FuturesDifference()
            {
                Difference = 1,
                BiQuarterFuturesPrice = 1,
                QuarterFuturesPrice = 1,
                Timestamp = DateTime.UtcNow,
            };
            db.FuturesDifference.Add(t);
            db.SaveChanges();
            return Ok(1);
        }
    }
}
