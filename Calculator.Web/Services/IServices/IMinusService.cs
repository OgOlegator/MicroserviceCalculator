using System.Threading.Tasks;

namespace Calculator.Web.Services.IServices
{
    public interface IMinusService
    {

        Task<T> GetMinusResultAsync<T>(string firstValue, string secondValue);

    }
}
