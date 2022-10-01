using System.Threading.Tasks;

namespace Calculator.Web.Services.IServices
{
    public interface IPlusService : IBaseService
    {
        Task<T> GetPlusResultAsync<T>(string firstValue, string secondValue);
        
    }
}
