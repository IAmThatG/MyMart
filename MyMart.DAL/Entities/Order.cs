using System.Collections.Generic;

namespace MyMart.DAL.Entities
{
    public class Order : BaseEntity
    {
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public long ProductQuantity { get; set; }
        public decimal OrderPrice { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}