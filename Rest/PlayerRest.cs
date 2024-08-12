using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PubgAPI.Dtos;
using PubgAPI.Interfaces;

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
                        var objResponse = JsonSerializer.Deserialize<PlayerResponse>(contentResp,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        response.CodigoHttp = responseApi.StatusCode;
                        response.DadosRetorno = objResponse;
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine("JSON Deserialization error: " + jsonEx.Message);
                        dynamic erroRetorno = new ExpandoObject();
                        erroRetorno.message = "Erro ao desserializar a resposta.";
                        response.ErroRetorno = erroRetorno;
                    }
                }
                else
                {
                    dynamic erroRetorno = new ExpandoObject();
                    erroRetorno.message = "Erro na API: " + contentResp;
                    response.CodigoHttp = responseApi.StatusCode;
                    response.ErroRetorno = erroRetorno;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine("HTTP Request error: " + httpEx.Message);
                response.CodigoHttp = System.Net.HttpStatusCode.ServiceUnavailable;
                dynamic erroRetorno = new ExpandoObject();
                erroRetorno.message = "Erro na solicitação HTTP.";
                response.ErroRetorno = erroRetorno;
            }

            return response;
        }
    }
}
