using System.Collections.Generic;

namespace MyMart.DAL.Entities
{
    public class Product : BaseEntity
    {
        public long RackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Rack Rack { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Product()
        {
            Orders = new List<Order>();
        }
    }
}