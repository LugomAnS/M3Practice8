namespace WorkWithList
{
    public class ListPractice
    {

        /// <summary>
        /// Задание 1. Работа с листом
        /// </summary>
        public static void ListTaskWorking()
        {
            Console.Clear();
            Console.WriteLine("1.Создаем List<int> из 100 значений в диапазоне от 0 до 100");

            List<int> practiceList = ListTasks.FillList();

            Console.WriteLine("\n2.Сгенерированые значения:\n");
            ListTasks.PrintListToConsole(practiceList);

            practiceList = ListTasks.DeleteDigits(practiceList);

            Console.WriteLine("\n\n3.Значения после удаления элементов:\n");
            ListTasks.PrintListToConsole(practiceList);

            Console.ReadKey(true);
        }


    }
}