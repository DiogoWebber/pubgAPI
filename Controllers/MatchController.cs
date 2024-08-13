using Microsoft.AspNetCore.Mvc;
using PubgAPI.Interfaces;
using PubgAPI.Dtos;
using System.Threading.Tasks;

namespace PubgAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetMatchById([FromQuery] string matchId)
        {
            var response = await _matchService.BuscarDataMatch(matchId);

            Console.WriteLine($"Controller Response Status Code: {response.CodigoHttp}");
            Console.WriteLine($"Controller Response Data: {response.DadosRetorno}");

            if (response.CodigoHttp == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }

    }
}