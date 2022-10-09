using Calculator.Web.Models;
using Calculator.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IPlusService _plusService;
        private readonly IMinusService _minusService;
        private readonly IMultiplyService _multiplyService;
        private readonly IDivideService _divideService;

        public CalculatorController(IPlusService plusService, IMinusService minusService, IMultiplyService multiplyService, IDivideService divideService)
        {
            _plusService = plusService;
            _minusService = minusService;
            _multiplyService = multiplyService;
            _divideService = divideService;
        }

        public async Task<IActionResult> CalculatorIndex(string firstValue, string secondValue, CalculatorModel.Operations operation)
        {
            CalculatorModel calculator = new CalculatorModel()
            {
                FirstValue = firstValue,
                SecondValue = secondValue,
                Operation = operation
            };

            if (!decimal.TryParse(firstValue, out _) || !decimal.TryParse(secondValue, out _))
            {
                calculator.Result = "Введите данные";
                return View(calculator);
            }

            ResponseDto response = null;

            switch (operation)
            {
                case CalculatorModel.Operations.Plus: 
                    response = await GetPlusResult(firstValue, secondValue);
                    break;
                case CalculatorModel.Operations.Minus:
                    response = await GetMinusResult(firstValue, secondValue);
                    break;
                case CalculatorModel.Operations.Multiply:
                    response = await GetMultiplyResult(firstValue, secondValue);
                    break;
                case CalculatorModel.Operations.Divide:
                    response = await GetDivideResult(firstValue, secondValue);
                    break;
            }

            if(response != null && response.IsSuccess)
            {
                calculator.Result = JsonConvert.DeserializeObject<ResultDto>(Convert.ToString(response.Result)).Result;
            }
            else if (response == null)
            {
                calculator.Result = "Введите данные";
            }
            else if (!response.IsSuccess)
            {
                calculator.Result = string.IsNullOrEmpty(response.DisplayMessage) ? "Error" : response.DisplayMessage;
            }

            return View(calculator);
        }

        private async Task<ResponseDto> GetPlusResult(string firstValue, string secondValue)
        {
            ResultDto result = new();
            var response = await _plusService.GetPlusResultAsync<ResponseDto>(firstValue, secondValue);

            return response;
        }

        private async Task<ResponseDto> GetMinusResult(string firstValue, string secondValue)
        {
            ResultDto result = new();
            var response = await _minusService.GetMinusResultAsync<ResponseDto>(firstValue, secondValue);

            return response;
        }

        private async Task<ResponseDto> GetMultiplyResult(string firstValue, string secondValue)
        {
            ResultDto result = new();
            var response = await _multiplyService.GetMultiplyResultAsync<ResponseDto>(firstValue, secondValue);

            return response;
        }

        private async Task<ResponseDto> GetDivideResult(string firstValue, string secondValue)
        {
            ResultDto result = new();
            var response = await _divideService.GetDivideResultAsync<ResponseDto>(firstValue, secondValue);

            return response;
        }
    }
}
