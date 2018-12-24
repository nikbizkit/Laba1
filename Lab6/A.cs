namespace Lab_6
{
    public class A
    {
        [My("Attributed")]
        public int PropertyInt { get; set; }
        public double PropertyDouble { get; set; }
        [My("Attributed")]
        public string PropertyString { get; set; }

        public A(int propertyInt, double propertyDouble, string propertyString)
        {
            PropertyInt = propertyInt;
            PropertyDouble = propertyDouble;
            PropertyString = propertyString;
        }

        public int MethodInt()
        {
            return 10;
        }

        public double MethodDouble()
        {
            return 10.10;
        }

        public string MethodString()
        {
            return "10";
        }
    }
}