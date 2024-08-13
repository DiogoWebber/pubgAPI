using Microsoft.AspNetCore.Mvc;
using PubgAPI.Interfaces;

namespace PubgAPI.Controllers {
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("by-names")]
        public async Task<IActionResult> GetPlayersByNames([FromQuery] List<string> playerNames)
        {
            var response = await _playerService.BuscarPlayerNames(playerNames);

            if (response.CodigoHttp == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
        
        
        [HttpGet("by-ids")]
        public async Task<IActionResult> GetPlayersByIds([FromQuery] List<string> playerIds)
        {
            var response = await _playerService.BuscarPlayersByIds(playerIds);

            if (response.CodigoHttp == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}