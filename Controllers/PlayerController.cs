using System.Net;
using Microsoft.AspNetCore.Mvc;
using PubgAPI.Interfaces;

namespace PubgAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost("by-names")]
    public async Task<IActionResult> GetPlayersByNames([FromBody] List<string> playerNames)
    {
        var response = await _playerService.BuscarPlayerNames(playerNames);

        if (response.CodigoHttp == HttpStatusCode.OK) return Ok(response.DadosRetorno);
        return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
    }


    [HttpPost("by-ids")]
    public async Task<IActionResult> GetPlayersByIds([FromBody] List<string> playerIds)
    {
        var response = await _playerService.BuscarPlayersByIds(playerIds);

        if (response.CodigoHttp == HttpStatusCode.OK) return Ok(response.DadosRetorno);
        return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
    }
}