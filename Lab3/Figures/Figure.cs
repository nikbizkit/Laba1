using System;

namespace Lab_3
{
    public abstract class Figure : IComparable, IPrint
    {
        public abstract double Area();
        
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case Figure figure:
                    return Area().CompareTo(figure.Area());
                default:
                    throw new ArgumentException("Object is not a Figure");
            }
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}