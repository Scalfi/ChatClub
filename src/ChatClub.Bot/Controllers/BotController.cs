using ChatClub.Bot.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatClub.Bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly ICsvService _csv;

        public BotController(ICsvService csv)
        {
            _csv = csv;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string param)
        {
            await _csv.ParseCsv(param);

            return Ok();
        }
    }
}
