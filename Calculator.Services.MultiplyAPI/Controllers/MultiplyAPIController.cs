using Calculator.Services.MultiplyAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Services.MultiplyAPI.Controllers
{
    [ApiController]
    [Route("api/multiply")]
    public class MultiplyAPIController : ControllerBase
    {
        protected ResponseDto _response;

        public MultiplyAPIController()
        {
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{firstValue} {secondValue}")]
        public ResponseDto Get(string firstValue, string secondValue)
        {
            try
            {
                var result = double.Parse(firstValue) * double.Parse(secondValue);
                _response.Result = new MultiplyResultDto { Result = result.ToString() };
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
