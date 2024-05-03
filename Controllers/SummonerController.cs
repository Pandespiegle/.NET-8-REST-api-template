using LolAppWS.Service;
using LolAppWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LolAppWS.Interfaces;

namespace LolAppWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly ILogger<SummonerController> _logger;
        private ISummonerService _summonerService;

        public SummonerController(ILogger<SummonerController> logger, ISummonerService summonerService)
        {
            _logger = logger;
            _summonerService = summonerService;
        }

        [HttpGet(Name = "GetAccount")]
        public IActionResult GetAccount(string name, string tag)
        {
            Summoner? summoner = _summonerService.getAccount(name, tag);

            if (summoner != null)
            {
                return Ok(summoner);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
