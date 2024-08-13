using System.Dynamic;
using System.Text.Json;
using PubgAPI.Dtos;
using PubgAPI.Interfaces;
using PubgAPI.Errors;
using PubgAPI.Serialization;

namespace PubgAPI.Rest
{
    public class MatchRest : IMatchService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MatchRest(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["PUBG_API_KEY"];
        }

        public async Task<ResponseGenerico<MatchesResponse>> BuscarDataMatch(string matchId)
        {
            var requestUri = $"https://api.pubg.com/shards/steam/matches/{matchId}";

            var response = new ResponseGenerico<MatchesResponse>();

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
                        var objResponse = JsonSerializerHelper.Deserialize<MatchesResponse>(contentResp);
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
