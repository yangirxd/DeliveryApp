using DeliveryApp;
using System;
using System.Collections.Generic;
using System.IO;

public class OrderSaver
{
    public static void SaveFilteredOrders(List<Order> filteredOrders, string outputPath)
    {

        using (StreamWriter writer = new StreamWriter(outputPath, false))
        {
            foreach (var order in filteredOrders)
            {
                string orderLine = $"{order.OrderId};{order.Weight};{order.CityDistrict};{order.DeliveryDateTime:yyyy-MM-dd HH:mm:ss}";
                writer.WriteLine(orderLine);
            }
        }
    }
}
