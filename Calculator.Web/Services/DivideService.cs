using Calculator.Web.Services.IServices;

namespace Calculator.Web.Services
{
    public class DivideService : BaseService, IDivideService
    {
        private readonly IHttpClientFactory _clientFactory;

        public DivideService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetDivideResultAsync<T>(string firstValue, string secondValue)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.DivideAPIBase + "/api/divide/" + firstValue + " " + secondValue 
            });
        }
    }
}
