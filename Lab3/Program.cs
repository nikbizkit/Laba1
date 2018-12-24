using System;
using System.Collections;
using System.Collections.Generic;
using Lab_3.SparseMatrix;
using Lab_3.Stack;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList example
            Console.WriteLine("ArrayList:");
            var arrayList = new ArrayList
            {
                new Rectangle(5, 6.3),
                new Rectangle(6, 3.6),
                new Rectangle(9.1, 4.7),
                new Square(6.5),
                new Square(3.9),
                new Square(5.87),
                new Circle(2.3),
                new Circle(4.2),
                new Circle(6.543)
            };
            
            arrayList.Sort();

            foreach (Figure figure in arrayList)
            {
                figure.Print();
            }

            // Figure List example
            Console.WriteLine("\nFigure List:");
            var figureList = new List<Figure>
            {
                new Rectangle(5, 6.3),
                new Rectangle(6, 3.6),
                new Rectangle(9.1, 4.7),
                new Square(6.5),
                new Square(3.9),
                new Square(5.87),
                new Circle(2.3),
                new Circle(4.2),
                new Circle(6.543)
            };
            
            figureList.Sort();

            foreach (var figure in figureList)
            {
                figure.Print();
            }
            
            // Figure Matrix example
            Console.WriteLine("\nMatrix:");
            var matrix = new Matrix<Figure>(5, 5, 4, new FigureMatrixCheckEmpty());
            matrix[0, 0, 0] = figureList[0];
            matrix[0, 3, 2] = figureList[1];
            matrix[3, 3, 0] = figureList[2];
            matrix[2, 2, 2] = figureList[3];

            Console.WriteLine(matrix);
            
            // Simple Stack example
            Console.WriteLine("\nSimple Stack:");
            var figureStack = new SimpleStack<Figure>();
            foreach (var figure in figureList)
            {
                figureStack.Push(figure);
            }

            while (!figureStack.Empty())
            {
                Console.WriteLine(figureStack.Pop());
            }
        }
    }
}