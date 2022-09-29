using Calculator.Web.Models;

namespace Calculator.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {

        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);

    }
}
