using System.ComponentModel.DataAnnotations;

namespace Calculator.Web.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string FirstValue { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string SecondValue { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public Operations Operation { get; set; }

        public string Result { get; set; }

        public enum Operations
        {
            Plus,
            Minus,
            Multiply,
            Divide
        }
    }
}
