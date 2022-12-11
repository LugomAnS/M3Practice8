using Parsing;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace HandBook
{
    public class XUserOutput
    {

        /// <summary>
        /// Программая для ввода и сохранения информации на диске в виде XML файла
        /// </summary>
        public static void XMenu()
        {
            Title();
            UserInputMenu();
        }

        /// <summary>
        /// Заголовок
        /// </summary>
        private static void Title()
        {
            Console.Clear();
            Console.WriteLine("Задание 4. Записная книжка");
            Console.WriteLine("Ввод информации о контакте");
            Console.WriteLine("Сохранение информации в виде XML файла");
        }


        /// <summary>
        /// Ввод информации о контакте
        /// </summary>
        private static void UserInputMenu()
        {
            string fullName = UserInput.UserTextInput("Введите ФИО контакта");
            string street = UserInput.UserTextInput("Введи улицу проживания");
            int houseNUmber = UserInput.UserIntInput("Введите номер дома");
            int flatNumber = UserInput.UserIntInput("Введите номер квартиры");

            string patter = @"^[0-9]\([0-9][0-9][0-9]\)[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]$";
            string message = "Введите номер мобильного телефона в формате Х(ХХХ)ХХХ-ХХ-ХХ";
            string mobilePhone = UserInput.UserTextInput(message, patter);

            patter = @"^[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]$";
            message = "Введите домашний телефон в формате ХХХ-ХХ-ХХ";
            string flatPhone = UserInput.UserTextInput(message, patter);

            XElement contact = ConvertToXML(fullName,
                                          street,
                                          houseNUmber,
                                          flatNumber,
                                          mobilePhone,
                                          flatPhone);

            Console.Clear();
            Console.WriteLine("Информация сохранена на диск");
            Console.WriteLine(contact.ToString());

            Console.ReadKey(true);
        }

        
        /// <summary>
        /// Преобразование данных в формат XML
        /// </summary>
        /// <param name="name">Имя контакта</param>
        /// <param name="street">Улица проживания</param>
        /// <param name="house">Дом проживания</param>
        /// <param name="flat">Номер квартиры</param>
        /// <param name="mobilePhone">Мобильный телефон</param>
        /// <param name="flatPhone">Домашний телефон</param>
        /// <returns>"Элемент готовый для сериализации в XML</returns>
        private static XElement ConvertToXML(string name,
                                         string street,
                                         int house,
                                         int flat,
                                         string mobilePhone,
                                         string flatPhone)
        {
            

            // сборка адреса
            XElement adress = new XElement("Address");
            XElement streetAtr = new XElement("Street", street);
            XElement houseNumber = new XElement("HouseNumber", house);
            XElement flatNumber = new XElement("FlatNumber", flat);
            adress.Add(streetAtr);
            adress.Add(houseNumber);
            adress.Add(flatNumber);

            //сборка телефонов
            XElement phones = new XElement("Phones");
            XElement mobile = new XElement("MobilePhone", mobilePhone);
            XElement housePhone = new XElement("FlatPhone", flatPhone);
            phones.Add(mobile);
            phones.Add(housePhone);

            //верхний уровень
            XAttribute fullName = new XAttribute("name", $"{name}");
            XElement contact = new XElement("Person", fullName);

            //общая компоновка
            contact.Add(adress);
            contact.Add(phones);

            contact.Save($"{name}.xml");
            
            return contact;
        }

    }
}