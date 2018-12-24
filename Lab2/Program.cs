using System;

namespace Lab_2
{
    class Program
    {
        static void PrintFigure(Figure figure)
        {
            var num = figure.Area();
            Console.WriteLine(num);
            figure.Print();
        }
        static void Main(string[] args)
        {
            var rect = new Rectangle(12, 34);
            var sqr = new Square(24);
            var crl = new Circle(3.5);
            
            rect.Print();
            sqr.Print();
            crl.Print();

            Console.WriteLine();
            
            PrintFigure(rect);
            PrintFigure(sqr);
            PrintFigure(crl);
        }
    }
}