namespace RepeatCheck
{
    public class Repeat
    {
        /// <summary>
        /// основлное меню проверки
        /// </summary>
        public static void RepeatTaskStart()
        {
            RepeatMenu();

            HashSet<int> repeatNumber = new HashSet<int>();
            string? userInput;
            int userChoice;
            do
            {
                bool isValidDigit;
                do
                {
                    Console.Write("Введите целое число: ");
                    userInput = Console.ReadLine().ToString();
                    isValidDigit = int.TryParse(userInput, out userChoice);

                } while (!(userInput.All(c => Char.IsDigit(c)) || String.IsNullOrEmpty(userInput)));

                //добавление
                if (!String.IsNullOrEmpty(userInput))
                {
                    if (!repeatNumber.Contains(userChoice))
                    {
                        repeatNumber.Add(userChoice);
                        Console.WriteLine("Число добавлено");
                    }
                    else
                    {
                        Console.WriteLine("Данное число вводилось ранее");
                    }

                }


            } while (!String.IsNullOrEmpty(userInput));

        }

        /// <summary>
        /// Заголовок
        /// </summary>
        private static void RepeatMenu()
        {
            Console.Clear();
            Console.WriteLine("Задание 3. Проверка повторов");
            Console.WriteLine("Вводите целые числа.");
            Console.WriteLine("При наличии повтора будет соответсвующее уведомление");
            Console.WriteLine("Для выхода из программы необходимо оставить строку пустой");
            
        }

    }
}