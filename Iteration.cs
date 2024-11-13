using NCalc;

namespace ApproximateSolution
{
    class IterationMethod
    {
        // Преобразуем функцию для вычислений
        static double EvaluateFunction(string equation, double x)
        {
            try
            {
                Expression e = new Expression(equation);
                e.Parameters["x"] = x;

                return Convert.ToDouble(e.Evaluate());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в выражении: {ex.Message}");
                return double.NaN; // Возвращаем NaN при ошибке
            }
        }

        public static void IterMain()
        {
            // Вводим данные
            Console.WriteLine("Введите уравнение в виде f(x) = 0 (например, x * x - 0.6): ");
            string equation = Console.ReadLine();

            Console.WriteLine("Введите начало области значений (a): ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите конец области значений (b): ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите допустимую погрешность (например, 0,025): ");
            double eps = double.Parse(Console.ReadLine());

            // Проверяем, чтобы на концах отрезка значения функции имели разные знаки
            if (EvaluateFunction(equation, a) * EvaluateFunction(equation, b) >= 0)
            {
                Console.WriteLine("Ошибка: функция должна иметь разные знаки на концах отрезка [a, b]. Попробуйте другой интервал.");
                return;
            }

            double mid = 0;
            int iteration = 0;

            // Метод итерации
            while ((b - a) / 2 > eps)
            {
                mid = (a + b) / 2;
                double fMid = EvaluateFunction(equation, mid);
                Console.WriteLine($"Итерация {iteration + 1}: x = {mid}, f(x) = {fMid}");

                if (double.IsNaN(fMid))
                {
                    Console.WriteLine("Ошибка: вычисление функции вернуло некорректное значение.");
                    return;
                }

                if (Math.Abs(fMid) < eps)
                    break;

                // Выбираем половину отрезка, в которой есть корень
                if (EvaluateFunction(equation, a) * fMid < 0)
                    b = mid;
                else
                    a = mid;

                iteration++;
            }

            // Выводим конечный результат
            Console.WriteLine($"Решение найдено: x = {mid} с точностью {eps}");
        }
    }
}