using Calculator.Services.PlusAPI.Models.Dto;

namespace Calculator.Services.PlusAPI.Repository
{
    public interface IPlusRepository
    {

        PlusResultDto GetPlusResult(string firstArg, string secondArg);

    }
}
