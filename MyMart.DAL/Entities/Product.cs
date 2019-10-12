namespace MyMart.DAL.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long RackId { get; set; }
        public Rack Rack { get; set; }
    }
}