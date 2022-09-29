namespace Calculator.Web.Models
{
    public class ApiRequest
    {

        public SD.APIType APIType { get; set; } = SD.APIType.GET;

        public string Url { get; set; }

        public object Data { get; set; }

    }
}
