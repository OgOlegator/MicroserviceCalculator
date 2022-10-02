using System.Threading.Tasks;

namespace Calculator.Web.Services.IServices
{
    public interface IDivideService
    {

        Task<T> GetDivideResultAsync<T>(string firstValue, string secondValue);

    }
}
