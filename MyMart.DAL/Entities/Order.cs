namespace MyMart.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Product ProductId { get; set; }
        public Customer CustomerId { get; set; }
        public string PaymentMethod { get; set; }
    }
}