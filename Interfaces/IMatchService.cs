using PubgAPI.Dtos;

namespace PubgAPI.Interfaces;

public interface IMatchService
{
    Task<ResponseGenerico<MatchesResponse>> BuscarDataMatch(string matchId);
}