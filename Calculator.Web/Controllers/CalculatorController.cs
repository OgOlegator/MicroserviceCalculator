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

        public async Task<IActionResult> CalculatorIndex(string firstValue, string secondValue, string operation)
        {
            CalculatorModel calculator = new CalculatorModel()
            {
                FirstValue = firstValue,
                SecondValue = secondValue
            };

            decimal a = 0;
            decimal b = 0;
            string result = "";

            if (!decimal.TryParse(firstValue, out a) || !decimal.TryParse(secondValue, out b))
            {
                calculator.Result = "Введите данные";
                return View(calculator);
            }

            switch (operation)
            {
                case "+":
                    result = (a + b).ToString();//GetPlusResult(firstValue, secondValue);
                    break;
                case "-":
                    result = (a - b).ToString();
                    break;
                case "*":
                    result = (a * b).ToString();
                    break;
                case "/":
                    result = b != 0 ?
                    (a / b).ToString()
                    : "error";
                    break;
                default:
                    result = "Введите данные";
                    break;
            }

            calculator.Result = result;
            return View(calculator);
        }

        private async Task<PlusResultDto> GetPlusResult(string firstValue, string secondValue)
        {
            PlusResultDto result = new();
            var response = await _plusService.GetPlusResultAsync<ResponseDto>(firstValue, secondValue);

            if(response != null && response.IsSuccess)
            {
                result = JsonConvert.DeserializeObject<PlusResultDto>(Convert.ToString(response.Result));
            }

            return result;
        }
    }
}
