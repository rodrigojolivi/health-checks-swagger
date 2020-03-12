using System;

namespace HealthChecksSwagger.Model
{
    public class Order
    {
        public Guid IdOrder { get; set; }
        public DateTime Date { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
