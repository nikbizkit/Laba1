namespace Lab_6
{
    public class MyAttribute : System.Attribute
    {
        public string Role { get; set; }

        public MyAttribute(string role)
        {
            Role = role;
        }
    }
}