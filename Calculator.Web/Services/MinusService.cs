using Calculator.Web.Services.IServices;

namespace Calculator.Web.Services
{
    public class MinusService : BaseService, IMinusService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MinusService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetMinusResultAsync<T>(string firstValue, string secondValue)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.MinusAPIBase + "/api/minus/" + firstValue + " " + secondValue 
            });
        }
    }
}
