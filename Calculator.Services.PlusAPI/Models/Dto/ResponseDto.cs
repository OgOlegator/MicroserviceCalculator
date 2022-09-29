namespace Calculator.Services.PlusAPI.Models.Dto
{
    public class ResponseDto
    {

        public bool IsSuccess { get; set; } = true;

        public string? Result { get; set; }

        public string DisplayMessage { get; set; } = "";

        public List<string> ErrorMessage { get; set; }

    }
}
