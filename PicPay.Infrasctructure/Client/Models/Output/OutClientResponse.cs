using Newtonsoft.Json;

namespace PicPay.Infrasctructure.Client.Models.Output
{
    public class OutClientResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
    }
}
