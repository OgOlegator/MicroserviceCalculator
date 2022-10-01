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

        public async Task<IActionResult> CalculatorIndex()
        {
            PlusResultDto result = new();
            var response = await _plusService.GetPlusResultAsync<ResponseDto>("1", "4");

            if(response != null && response.IsSuccess)
            {
                result = JsonConvert.DeserializeObject<PlusResultDto>(Convert.ToString(response.Result));
            }

            return View(result);
        }
    }
}
