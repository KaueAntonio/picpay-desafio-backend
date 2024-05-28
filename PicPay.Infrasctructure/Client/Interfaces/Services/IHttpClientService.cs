using PicPay.Infrasctructure.Client.Models.Output;

namespace PicPay.Infrasctructure.Client.Interfaces.Services
{
    public interface IHttpClientService
    {
        void Configure(string baseUrl);
        Task<OutClientResponse<T>> GetAsync<T>(string url);
        Task<OutClientResponse<T>> PostAsync<T, B>(string url, B body);
    }
}
