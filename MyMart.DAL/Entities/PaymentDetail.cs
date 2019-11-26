using System;

namespace MyMart.DAL.Entities
{
    public class PaymentDetail : BaseEntity
    {
        public long CustomerId { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public CardType CardType { get; set; }
        public string Cvv { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Customer Customer { get; set; }
    }
}