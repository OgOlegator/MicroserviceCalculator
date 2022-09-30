using Calculator.Web.Services.IServices;

namespace Calculator.Web.Services
{
    public class PlusService : BaseService, IPlusServices
    {
        private readonly IHttpClientFactory _clientFactory;

        public PlusService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetPlusResultAsync<T>(string firstValue, string secondValue)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                APIType = SD.APIType.GET,
                Url = SD.PlusAPIBase + "/api/plus/" + firstValue + "/" + secondValue,
            });
        }
    }
}
