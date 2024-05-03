using System.Diagnostics;
using System.Net.Http;

namespace LolAppWS.Services
{
    public class BaseService
    {
        public readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public BaseService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        public async Task<string> GetRequest(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url + "?api_key=" + _configuration.GetValue<string>("ApiKey"));
            Debug.WriteLine(_configuration.GetValue<string>("ApiKey"));
            return await response.Content.ReadAsStringAsync();
        }
    }
}
