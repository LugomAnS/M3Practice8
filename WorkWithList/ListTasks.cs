using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithList
{
    internal class ListTasks
    {

        /// <summary>
        /// Наполняем лист из 100 элементов случайными значениями от 0 до 100
        /// </summary>
        /// <returns></returns>
        public static List<int> FillList()
        {
            List<int> intValues = new List<int>();
            Random intGenerator = new Random();

            for (int i = 0; i < 100; i++)
            {
                intValues.Add(intGenerator.Next(0, 101));
            }

            return intValues;
        }

        /// <summary>
        /// Вывод в консоль
        /// </summary>
        /// <param name="valueToPrint"></param>
        public static void PrintListToConsole(List<int> valueToPrint)
        {
            foreach (int number in valueToPrint)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Удаление элементов что больше 25 но меньше 50
        /// </summary>
        /// <param name="valueList"></param>
        /// <returns></returns>
        public static List<int> DeleteDigits(List<int> valueList)
        {
            return (valueList.Where(num => num <= 25 || num >= 50)).ToList();
        }

    }
}
