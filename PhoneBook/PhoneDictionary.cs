using Parsing;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook
{
    public class PhoneDictionary
    {
        /// <summary>
        /// Телефонная книга
        /// </summary>
        public static void PhoneBookMenu()
        {
           
            Dictionary<string, string> phoneDictionary = new Dictionary<string, string>();

            UserTaskFill();
            do
            {
                string? recordFio = UserInput.UserTextInput("Введите ФИО владельца:");
                if (String.IsNullOrEmpty(recordFio))
                {
                    break;
                }
                string message = "Введите телефон в формате ХХХ-ХХ-ХХ";
                string pattern = @"^[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]$";
                string phoneNumber = UserInput.UserTextInput(message, pattern);
                bool isSuccess = phoneDictionary.TryAdd(phoneNumber, recordFio);

                if (!isSuccess)
                {
                    Console.WriteLine("Пользователь с таким телефоном уже существует");
                }

            } while (true);

            bool repeatFinding;
            do
            {
                Console.Clear();
                FindRecordByPhone(phoneDictionary);
                repeatFinding = RepeatFind();

            } while (repeatFinding);
            

        }

        /// <summary>
        /// Проверяем надо ли продолжать поиск
        /// </summary>
        /// <returns>true если продолжаем, false если остановиться</returns>
        private static bool RepeatFind()
        {
            Console.Clear();
            do
            {
                string? userChoice = UserInput.UserTextInput("Повторить поиск \"да/нет\"?");
                if (string.IsNullOrEmpty(userChoice))
                {
                    continue;
                }
                if (userChoice.Equals("да"))
                {
                    return true;
                }
                if (userChoice.Equals("нет"))
                {
                    return false;
                }
            } while (true);

        }

        /// <summary>
        /// Поиск записи
        /// </summary>
        /// <param name="phoneDictionary"></param>
        private static void FindRecordByPhone(Dictionary<string, string> phoneDictionary)
        {
            string message = "Введите телефон для поиска в формате ХХХ-ХХ-ХХ";
            string pattern = @"^[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]$";

            string userInput = UserInput.UserTextInput(message, pattern);
            string? name;
            bool isFindRecord;
            isFindRecord = phoneDictionary.TryGetValue(userInput, out name);

            if (isFindRecord)
            {
                Console.WriteLine("Запись найдена: ");
                Console.WriteLine($"{name}");
            }
            else
            {
                Console.WriteLine("Нет записи с таким телефоным номером");
            }

            Console.ReadKey(true);
        }

        /// <summary>
        /// Инструкция для пользователя
        /// </summary>
        private static void UserTaskFill()
        {
            Console.Clear();
            Console.WriteLine("Задание 2. Телефонная книга");
            Console.WriteLine("Необходимо последовательно вводить ФИО и номер телефона");
            Console.WriteLine("Для завершения ввода поле ввода ФИО необходимо оставить пустым");

        }

        /// <summary>
        /// Инструкция для поиска
        /// </summary>
        private static void UserTaskFind()
        {
            Console.Clear();
            Console.WriteLine("Для поиска записи введите номер телефона");
        }

        
    }

    
}