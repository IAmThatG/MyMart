using System.Collections.Generic;

namespace MyMart.DAL.Entities
{
    public class Rack : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public Rack()
        {
            Products = new List<Product>();
        }
    }
}