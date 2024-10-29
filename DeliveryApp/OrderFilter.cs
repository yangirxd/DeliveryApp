using DeliveryApp;
using System;
using System.Collections.Generic;
using System.Linq;

class OrderFilter
{
    public static List<Order> FilterOrders(List<Order> orders, string cityDistrict, DateTime firstDeliveryDateTime)
    {
        // Время окончания фильтрации — полчаса после первой доставки
        DateTime endTime = firstDeliveryDateTime.AddMinutes(30);

        // Фильтруем заказы по району и времени доставки
        var filteredOrders = orders
            .Where(order => order.CityDistrict == cityDistrict)
            .Where(order => order.DeliveryDateTime >= firstDeliveryDateTime && order.DeliveryDateTime < endTime)
            .ToList();

        return filteredOrders;
    }
}
