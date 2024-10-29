using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DeliveryApp
{
    public class OrderLoader
    {
        public static List<Order> LoadOrdersFromFile(string filePath)
        {
            var orders = new List<Order>();
            var logger = new Logger(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "deliveryLog.txt"));

            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(';');
                if (parts.Length != 4)
                {
                    logger.Log($"Ошибка: некорректный формат строки - {line}");
                    continue;
                }

                if (!int.TryParse(parts[0], out int orderId))
                {
                    logger.Log($"Ошибка: некорректный идентификатор заказа - {parts[0]}");
                    continue;
                }

                if (!double.TryParse(parts[1], out double weight) || weight <= 0)
                {
                    logger.Log($"Ошибка: некорректный вес заказа - {parts[1]}");
                    continue;
                }

                string cityDistrict = parts[2];
                if (string.IsNullOrWhiteSpace(cityDistrict))
                {
                    logger.Log("Ошибка: район города не может быть пустым");
                    continue;
                }

                if (!DateTime.TryParseExact(parts[3], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryDateTime))
                {
                    logger.Log($"Ошибка: некорректный формат даты и времени - {parts[3]}");
                    continue;
                }

                var order = new Order(orderId, weight, cityDistrict, deliveryDateTime);
                orders.Add(order);
            }

            return orders;
        }
    }
}
