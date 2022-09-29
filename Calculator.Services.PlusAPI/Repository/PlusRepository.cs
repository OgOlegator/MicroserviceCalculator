using Calculator.Services.PlusAPI.Models.Dto;

namespace Calculator.Services.PlusAPI.Repository
{
    public class PlusRepository : IPlusRepository
    {
        public PlusResultDto GetPlusResult(string firstArg, string secondArg)
        {
            return new PlusResultDto();
        }
    }
}
