namespace Calculator.Web
{
    public static class SD
    {

        public static string PlusAPIBase { get; set; }

        public static string MinusAPIBase { get; set; }

        public static string MultiplyAPIBase { get; set; }

        public static string DivideAPIBase { get; set; }

        public enum APIType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

    }
}
