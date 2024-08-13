using System.Dynamic;
using System.Text.Json;
using PubgAPI.Dtos;
using PubgAPI.Interfaces;
using PubgAPI.Errors;
using PubgAPI.Serialization;

namespace PubgAPI.Rest
{
    public class PlayerRest : IPlayerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public PlayerRest(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["PUBG_API_KEY"];
        }
        //PLAYER POR NICKNAME
        public async Task<ResponseGenerico<PlayerResponse>> BuscarPlayerNames(List<string> playerNames)
        {
            var namesQuery = string.Join(",", playerNames.Select(name => Uri.EscapeDataString(name)));
            var requestUri = $"https://api.pubg.com/shards/steam/players?filter[playerNames]={namesQuery}";

            var response = new ResponseGenerico<PlayerResponse>();

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.api+json"));

            try
            {
                var responseApi = await _httpClient.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();

                if (responseApi.IsSuccessStatusCode)
                {
                    try
                    {
                        var objResponse = JsonSerializerHelper.Deserialize<PlayerResponse>(contentResp);
                        response.CodigoHttp = responseApi.StatusCode;
                        response.DadosRetorno = objResponse;
                    }
                    catch (JsonException)
                    {
                        dynamic erroRetorno = new ExpandoObject();
                        erroRetorno.message = ErrorMessages.JsonDeserializationError;
                        response.ErroRetorno = erroRetorno;
                    }
                }
                else
                {
                    dynamic erroRetorno = new ExpandoObject();
                    erroRetorno.message = string.Format(ErrorMessages.ApiError, contentResp);
                    response.CodigoHttp = responseApi.StatusCode;
                    response.ErroRetorno = erroRetorno;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine("HTTP Request error: " + httpEx.Message);
                response.CodigoHttp = System.Net.HttpStatusCode.ServiceUnavailable;
                dynamic erroRetorno = new ExpandoObject();
                erroRetorno.message = ErrorMessages.HttpRequestError;
                response.ErroRetorno = erroRetorno;
            }

            return response;
        }
        
        
        //PLAYER POR ID 
        public async Task<ResponseGenerico<PlayerResponse>> BuscarPlayersByIds(List<string> playerIds)
        {
            var idsQuery = string.Join(",", playerIds.Select(id => Uri.EscapeDataString(id)));
            var requestUri = $"https://api.pubg.com/shards/steam/players?filter[playerIds]={idsQuery}";

            return await SendRequest(requestUri);
        }

        private async Task<ResponseGenerico<PlayerResponse>> SendRequest(string requestUri)
        {
            var response = new ResponseGenerico<PlayerResponse>();

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.api+json"));

            try
            {
                var responseApi = await _httpClient.SendAsync(request);
                var contentResp = await responseApi.Content.ReadAsStringAsync();

                if (responseApi.IsSuccessStatusCode)
                {
                    try
                    {
                        var objResponse = JsonSerializerHelper.Deserialize<PlayerResponse>(contentResp);
                        response.CodigoHttp = responseApi.StatusCode;
                        response.DadosRetorno = objResponse;
                    }
                    catch (JsonException)
                    {
                        dynamic erroRetorno = new ExpandoObject();
                        erroRetorno.message = ErrorMessages.JsonDeserializationError;
                        response.ErroRetorno = erroRetorno;
                    }
                }
                else
                {
                    dynamic erroRetorno = new ExpandoObject();
                    erroRetorno.message = string.Format(ErrorMessages.ApiError, contentResp);
                    response.CodigoHttp = responseApi.StatusCode;
                    response.ErroRetorno = erroRetorno;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine("HTTP Request error: " + httpEx.Message);
                response.CodigoHttp = System.Net.HttpStatusCode.ServiceUnavailable;
                dynamic erroRetorno = new ExpandoObject();
                erroRetorno.message = ErrorMessages.HttpRequestError;
                response.ErroRetorno = erroRetorno;
            }

            return response;
        }
    }
}