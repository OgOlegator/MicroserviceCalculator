using System.Threading.Tasks;

namespace Calculator.Web.Services.IServices
{
    public interface IMultiplyService
    {

        Task<T> GetMultiplyResultAsync<T>(string firstValue, string secondValue);

    }
}
