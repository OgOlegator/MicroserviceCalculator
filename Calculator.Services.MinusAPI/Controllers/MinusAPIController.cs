using Calculator.Services.MinusAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Services.MinusAPI.Controllers
{
    [ApiController]
    [Route("api/minus")]
    public class MinusAPIController : ControllerBase
    {
        protected ResponseDto _response;

        public MinusAPIController()
        {
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{firstValue} {secondValue}")]
        public ResponseDto Get(string firstValue, string secondValue)
        {
            try
            {
                var result = double.Parse(firstValue) - double.Parse(secondValue);
                _response.Result = new MinusResultDto { Result = result.ToString() };
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
