using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using DeliveryApp;

class Program
{
    static void Main(string[] args)
    {
        // Путь к файлам
        string orderFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Orders/Orders.txt");
        string logFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "deliveryLog.txt");
        string outputFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "deliveryOrder.txt");

        var logger = new Logger(logFilePath);

        try
        {
            logger.Log("Начало загрузки заказов из файла.");
            var orders = OrderLoader.LoadOrdersFromFile(orderFilePath);
            logger.Log("Заказы успешно загружены.");

            // Запрос района у пользователя
            Console.Write("Введите район доставки: ");
            string cityDistrict = Console.ReadLine();

            // Запрос времени первой доставки у пользователя
            Console.Write("Введите время первой доставки (в формате yyyy-MM-dd HH:mm:ss): ");
            string inputTime = Console.ReadLine();
            DateTime firstDeliveryDateTime = DateTime.ParseExact(inputTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            logger.Log($"Начало фильтрации заказов для района {cityDistrict} с первой доставкой в {firstDeliveryDateTime}.");
            var filteredOrders = OrderFilter.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);
            logger.Log($"Фильтрация завершена. Найдено {filteredOrders.Count} заказов.");

            OrderSaver.SaveFilteredOrders(filteredOrders, outputFilePath);
            logger.Log("Результаты фильтрации успешно сохранены.");

        }
        catch (Exception ex)
        {
            logger.Log($"Ошибка: {ex.Message}");
            Console.WriteLine("Произошла ошибка. Проверьте логи для получения дополнительной информации.");
        }
    }
}
