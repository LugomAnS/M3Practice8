using Parsing;
using WorkWithList;
using PhoneBook;
using RepeatCheck;
using HandBook;

namespace Collections
{
    internal class Program
    {
        /// <summary>
        /// Практическая работа №8
        /// </summary>
        static void Main()
        {
            int userInput;

            do
            {
                ProgramMenu();

                userInput = UserInput.UserIntInput("Выберите пункт меню: ");

                switch (userInput)
                {
                    case 1:
                        ListPractice.ListTaskWorking();
                        break;
                    case 2:
                        PhoneDictionary.PhoneBookMenu();
                        break;
                    case 3:
                        Repeat.RepeatTaskStart();
                        break;
                    case 4:
                        XUserOutput.XMenu();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            } while (true);

        }

        /// <summary>
        /// Главное меню 
        /// </summary>
        private static void ProgramMenu()
        {
            Console.Clear();
            Console.WriteLine("Практическая работа №8");
            Console.WriteLine("1.Работа с листом");
            Console.WriteLine("2.Телефонная книга");
            Console.WriteLine("3.Проверка повторов");
            Console.WriteLine("4.Записная книжка ");
            Console.WriteLine("5.Выход из программы");
        }
    }
}