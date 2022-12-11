using System.Text.RegularExpressions;

namespace Parsing
{
    public class UserInput
    {
        /// <summary>
        /// Проверка ввода цифр
        /// </summary>
        /// <param name="messageToUser">Сообщение пользователю</param>
        /// <returns>Пользовательский ввод</returns>
        public static int UserIntInput(string messageToUser)
        {
            bool isValidDigit = false;
            int userChoice = 0;
            do
            {
                Console.WriteLine(messageToUser);
                string? userInput = Console.ReadLine().ToString();
                isValidDigit = int.TryParse(userInput, out userChoice);

            } while (!isValidDigit);

            return userChoice;
        }


        /// <summary>
        /// Проверка ввода текста
        /// </summary>
        /// <param name="messageToUser">Сообщение пользователю</param>
        /// <returns>Пользовательский текст</returns>
        public static string? UserTextInput(string messageToUser)
        {
            string? userValue;
            bool isValidText = false;

            do
            {
                Console.WriteLine(messageToUser);
                userValue = Console.ReadLine().ToString();
                isValidText = userValue.All(c => Char.IsLetter(c) || c == ' ');

            } while (!isValidText);

            return userValue;
        }

        /// <summary>
        /// Проверка ввода по маске
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="pattern">Маска для проверки</param>
        /// <returns>Пользовательский ввод</returns>
        public static string UserTextInput(string message, string pattern)
        {
            string userValue;
            bool isValidText;

            do
            {
                Console.WriteLine(message);
                userValue = Console.ReadLine().ToString();
                isValidText = Regex.IsMatch(userValue, pattern, RegexOptions.None, TimeSpan.FromMilliseconds(2000));

            } while (!isValidText);

            return userValue;
        }


    }
}