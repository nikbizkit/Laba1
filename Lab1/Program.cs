using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = GetNumber("A");
            var b = GetNumber("B");
            var c = GetNumber("C");
            
            var d = b * b - 4 * a * c;
            if (d < 0)
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 не имеет действительных корней");
                return;
            }

            var sqrtD = Math.Sqrt(d);
            var twoA = a + a;

            if (d > 0)
            {
                var x1 = (-b - sqrtD) / twoA;
                var x2 = (-b + sqrtD) / twoA;
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет 2 действительных корня: " +
                                  $"x1 = {x1}, x2 = {x2}");
                return;
            }

            var x = -b / twoA;
            Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет 2 совпадающих действительных корня: x = {x}");        
	} 

        static double GetNumber(string coef)
        {
            do
            {
                Console.WriteLine($"Введите коэффициент {coef}: ");
                var success = double.TryParse(Console.ReadLine(), out var num);
                if (success)
                {
                    return num;
                }
                Console.WriteLine("Ошибка. Введите действительное число.\n");
            } while (true);
        }
    }
}
