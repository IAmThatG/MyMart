using System;
using Microsoft.EntityFrameworkCore;
using MyMart.DAL.Entities;

namespace MyMart.DAL
{
    public static class MyMartDbContextRules
    {
        public static void ConfigureCustomerConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property<byte[]>(c => c.RowVersion).IsRowVersion();
                entity.Property<string>(c => c.Email).IsRequired();
                entity.Property<string>(c => c.Firstname).IsRequired();
                entity.Property<string>(c => c.Lastname).IsRequired();
                entity.HasMany<PaymentDetail>(c => c.PaymentDetails)
                      .WithOne(p => p.Customer)
                      .HasForeignKey(p => p.CustomerId);
                entity.Property<DateTime>(c => c.DateCreated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnAdd();
                entity.Property<DateTime?>(c => c.DateUpdated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnUpdate();
            });
        }

        public static void ConfigureOrderConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property<byte[]>(c => c.RowVersion).IsRowVersion();
                entity.Property<decimal>(o => o.OrderPrice)
                      .IsRequired()
                      .HasDefaultValue(0.00);
                entity.Property<long>(o => o.ProductQuantity)
                      .IsRequired()
                      .HasDefaultValue(1);
                entity.HasOne<Product>(o => o.Product)
                      .WithMany(p => p.Orders)
                      .HasForeignKey(o => o.ProductId);
                entity.Property<DateTime>(o => o.DateCreated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnAdd();
                entity.Property<DateTime?>(o => o.DateUpdated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnUpdate();
            });
        }

        public static void ConfigurePaymentDetailConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasKey(pd => pd.Id);
                entity.Property<byte[]>(pd => pd.RowVersion).IsRowVersion();
                entity.Property<string>(pd => pd.CardHolder).IsRequired();
                entity.Property<CardType>(pd => pd.CardType).IsRequired();
                entity.Property<string>(pd => pd.Cvv)
                      .IsRequired()
                      .HasMaxLength(3)
                      .IsFixedLength();
                entity.Property<DateTime>(pd => pd.ExpiryDate).IsRequired();
                entity.HasOne<Customer>(pd => pd.Customer)
                      .WithMany(c => c.PaymentDetails)
                      .HasForeignKey(pd => pd.CustomerId);
                entity.Property<DateTime>(pd => pd.DateCreated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnAdd();
                entity.Property<DateTime?>(pd => pd.DateUpdated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnUpdate();
            });
        }

        public static void ConfigureProductConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property<byte[]>(p => p.RowVersion).IsRowVersion();
                entity.Property<string>(p => p.Name).IsRequired();
                entity.Property<decimal>(p => p.Price).HasDefaultValue(0.00);
                entity.HasOne<Rack>(p => p.Rack)
                      .WithMany(r => r.Products)
                      .HasForeignKey(p => p.RackId);
                entity.HasMany<Order>(p => p.Orders)
                      .WithOne(o => o.Product)
                      .HasForeignKey(o => o.ProductId);
                entity.Property<DateTime>(o => o.DateCreated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnAdd();
                entity.Property<DateTime?>(o => o.DateUpdated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnUpdate();
            });
        }

        public static void ConfigureRackConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rack>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property<byte[]>(r => r.RowVersion).IsRowVersion();
                entity.Property<string>(r => r.Name).IsRequired();
                entity.HasMany<Product>(r => r.Products)
                      .WithOne(p => p.Rack)
                      .HasForeignKey(p => p.RackId);
                entity.Property<DateTime>(p => p.DateCreated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnAdd();
                entity.Property<DateTime>(p => p.DateUpdated)
                      .HasDefaultValue(DateTime.Now)
                      .ValueGeneratedOnUpdate();
            })
        }
    }
}