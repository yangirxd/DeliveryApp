namespace DeliveryApp
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Weight { get; set; } 
        public string CityDistrict { get; set; }
        public DateTime DeliveryDateTime { get; set; } 

        public Order(int orderId, double weight, string cityDistrict, DateTime deliveryDateTime)
        {
            OrderId = orderId;
            Weight = weight;
            CityDistrict = cityDistrict;
            DeliveryDateTime = deliveryDateTime;
        }
    }
}
