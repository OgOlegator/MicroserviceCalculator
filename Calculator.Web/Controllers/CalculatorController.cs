using Calculator.Web.Models;
using Calculator.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IPlusService _plusService;

        public CalculatorController(IPlusService plusService)
        {
            _plusService = plusService;
        }

        public async Task<IActionResult> CalculatorIndex(string firstValue, string secondValue, CalculatorModel.Operations operation)
        {
            CalculatorModel calculator = new CalculatorModel()
            {
                FirstValue = firstValue,
                SecondValue = secondValue,
                Operation = operation
            };

            if (!decimal.TryParse(firstValue, out var a) || !decimal.TryParse(secondValue, out var b))
            {
                calculator.Result = "Введите данные";
                return View(calculator);
            }

            ResponseDto response = null;
            string result = "";

            switch (operation)
            {
                case CalculatorModel.Operations.Plus: //"+":
                    response = await GetPlusResult(firstValue, secondValue);
                    break;
                case CalculatorModel.Operations.Minus: //"-":
                    result = (a - b).ToString();
                    break;
                case CalculatorModel.Operations.Multiply: //"*":
                    result = (a * b).ToString();
                    break;
                case CalculatorModel.Operations.Divide: //"/":
                    result = b != 0 ?
                    (a / b).ToString()
                    : "error";
                    break;
                default:
                    result = "Введите данные";
                    break;
            }

            if(response != null && response.IsSuccess)
            {
                calculator.Result = JsonConvert.DeserializeObject<PlusResultDto>(Convert.ToString(response.Result)).Result;
            }
            else
            {
                calculator.Result = result;
            }
            
            return View(calculator);
        }

        private async Task<ResponseDto> GetPlusResult(string firstValue, string secondValue)
        {
            PlusResultDto result = new();
            var response = await _plusService.GetPlusResultAsync<ResponseDto>(firstValue, secondValue);

            return response;
        }
    }
}
