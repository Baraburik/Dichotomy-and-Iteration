namespace ApproximateSolution
{
    class MainMenu
    {

        static void Main()
        {
            Console.WriteLine("1 - метод дихотомии");
            Console.WriteLine("2 - метод итераций");
            Console.WriteLine("3 - выход");
            Console.WriteLine("Выберите метод, который нужно запустить:");
            int choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                DichotomyMethod.DichotomyMain();
            }

            else if (choise == 2)
            {
                IterationMethod.IterMain();
            }

            else if (choise == 3)
            {
                Console.WriteLine("До свидания!");
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Ошибка: выбран некорректный номер");
                MainMenu.Main();
            }
        }
    }
}