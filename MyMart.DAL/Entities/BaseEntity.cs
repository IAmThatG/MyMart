using System;
namespace MyMart.DAL.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}