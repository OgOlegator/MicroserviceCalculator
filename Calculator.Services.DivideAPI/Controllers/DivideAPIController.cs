using Calculator.Services.DivideAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Services.DivideAPI.Controllers
{
    //[Route("api/divide")]
    public class DivideApiController : Controller
    {
        protected ResponseDto _response;

        public DivideApiController()
        {
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{firstValue} {secondValue}")]
        public ResponseDto Get(string firstValue, string secondValue)
        {
            try
            {
                if(double.Parse(secondValue) == 0)
                {
                    _response.DisplayMessage = "Нельзя делить на 0";
                    throw new Exception();
                }

                var result = double.Parse(firstValue) / double.Parse(secondValue);
                _response.Result = new DivideResultDto { Result = result.ToString() };
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;
        }
    }
}
