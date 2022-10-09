using Calculator.Web.Services.IServices;

namespace Calculator.Web.Services
{
    public class MultiplyService : BaseService, IMultiplyService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MultiplyService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetMultiplyResultAsync<T>(string firstValue, string secondValue)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.MultiplyAPIBase + "/api/multiply/" + firstValue + " " + secondValue
            });
        }
    }
}
