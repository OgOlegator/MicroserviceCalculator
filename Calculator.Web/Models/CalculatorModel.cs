using System.ComponentModel.DataAnnotations;

namespace Calculator.Web.Models
{
    public class CalculatorModel
    {
        public string FirstValue { get; set; }

        public string SecondValue { get; set; }

        public Operations Operation { get; set; }

        public string Result { get; set; }

        public enum Operations
        {
            [Display(Name = "")]
            Empty,
            [Display(Name = "+")]
            Plus,
            [Display(Name = "-")]
            Minus,
            [Display(Name = "*")]
            Multiply,
            [Display(Name = "/")]
            Divide
        }

    }
}
