using System.Collections.Generic;

namespace MyMart.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PaymentDetail> PaymentDetails { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
            PaymentDetails = new List<PaymentDetail>();
        }
    }
}