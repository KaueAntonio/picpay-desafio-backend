using PicPay.Infrasctructure.Client.Interfaces.Services;
using PicPay.Infrasctructure.Client.Models.Output;
using Newtonsoft.Json;
using Azure;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace PicPay.Infrasctructure.Client.Services
{
    public class HttpClientService(IConfiguration configuration) : IHttpClientService
    {
        private readonly HttpClient _httpClient = new();
        private readonly IConfiguration _configuration = configuration;

        public void Configure(string serviceName)
        {
            var baseUrl = _configuration.GetSection(serviceName).ToString();

            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<OutClientResponse<T>> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            return await GetResponse<T>(response);
        }

        public async Task<OutClientResponse<T>> PostAsync<T, B>(string url, B body)
        {
            var response = await _httpClient.PostAsJsonAsync(url, body);

            return await GetResponse<T>(response);
        }

        private async static Task<OutClientResponse<T>> GetResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new Exception("HttpClient Error: " + response.Content);

            string content = await response.Content.ReadAsStringAsync();

            OutClientResponse<T> result = new()
            {
                Data = JsonConvert.DeserializeObject<T>(content),
                StatusCode = (int)response.StatusCode
            };
            ;
            return result;
        }
    }
}
