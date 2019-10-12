namespace MyMart.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
    }
}