using Calculator.Services.PlusAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Services.PlusAPI.Controllers
{
    [ApiController]
    [Route("api/plus")]
    public class PlusAPIController : ControllerBase
    {
        protected ResponseDto _response;

        public PlusAPIController()
        {
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("{firstValue} {secondValue}")]
        public ResponseDto Get(string firstValue, string secondValue)
        {
            try
            {
                var result = double.Parse(firstValue) + double.Parse(secondValue);
                _response.Result = new PlusResultDto { Result = result.ToString() };
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
