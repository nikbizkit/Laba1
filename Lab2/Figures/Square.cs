using System;

namespace Lab_2
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) {}

        public override string ToString()
        {
            return $"Квадрат со стороной {Height} имеет площадь {Area()}";
        }   
    }
}