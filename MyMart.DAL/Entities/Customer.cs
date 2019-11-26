using System.Collections.Generic;

namespace MyMart.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long ApplicationUserId { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PaymentDetail> PaymentDetails { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
            PaymentDetails = new List<PaymentDetail>();
        }
    }
}