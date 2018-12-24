using System;

namespace Lab_2
{
    public abstract class Figure : IPrint
    {
        public abstract double Area();
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}