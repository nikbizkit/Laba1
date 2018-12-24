namespace Lab_3.Stack
{
    public class SimpleStackElement<T>
    {
        public T Data { get; set; }
        public SimpleStackElement<T> Next { get; set; }

        public SimpleStackElement(T data)
        {
            Data = data;
        }
    }
}