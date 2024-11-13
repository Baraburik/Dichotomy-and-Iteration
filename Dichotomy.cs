using NCalc;

namespace ApproximateSolution
{
    class DichotomyMethod
    {
        public static void DichotomyMain()
        {
            // Вводим данные
            // a, b - интервал, на котором будет находться предполагаемый корень
            Console.WriteLine("Введите начало интервала a:");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите конец интервала b:");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите требуемую точность (например, 1e-6 (чем меньше число, тем выше точность: 1e-7 -> точность выше)):");
            double tolerance = double.Parse(Console.ReadLine());

            // Определяем функцию
            Console.WriteLine("Введите выражение (например, x * x - 2):");
            string equation = Console.ReadLine();
            Func<double, double> function = CreateFunction(equation);

            // Вызываем метод дихотомии
            double root = Bisection(a, b, tolerance, function);

            // Выводим результат
            Console.WriteLine($"Приближенное значение корня: {root}");
        }

        // Метод дихотомии
        static double Bisection(double a, double b, double tolerance, Func<double, double> function)
        {
            double middle = 0.0;

            while ((b - a) / 2.0 > tolerance)
            {
                middle = (a + b) / 2.0;
                if (function(middle) == 0.0)
                    break;
                else if (function(a) * function(middle) < 0)
                    b = middle;
                else
                    a = middle;
            }

            return middle;
        }

        // Создаем функцию из строки
        static Func<double, double> CreateFunction(string equation)
        {
            return x =>
            {
                Expression expression = new Expression(equation);
                expression.Parameters["x"] = x;
                object result = expression.Evaluate();
                return Convert.ToDouble(result);
            };

        }
    }
}