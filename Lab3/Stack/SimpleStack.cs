using System;

namespace Lab_3.Stack
{
    public class SimpleStack<T>
    {
        public SimpleStackElement<T> Head { get; set; }

        public SimpleStack()
        {
            Head = null;
        }

        public void Push(T data)
        {
            var element = new SimpleStackElement<T>(data);

            element.Next = Head;
            Head = element;
        }

        public T Pop()
        {
            if (Head == null)
            {
                throw new Exception("Стек пуст");
            }

            var returnElement = Head;
            Head = Head.Next;

            return returnElement.Data;
        }

        public bool Empty()
        {
            return Head == null;
        }
    }
}