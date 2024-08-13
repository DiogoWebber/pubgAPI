using PubgAPI.Dtos;

namespace PubgAPI.Interfaces
{
    public interface IPlayerService
    {
        Task<ResponseGenerico<PlayerResponse>> BuscarPlayerNames(List<string> playerNames);
        Task<ResponseGenerico<PlayerResponse>> BuscarPlayersByIds(List<string> playerIds);
    }
}