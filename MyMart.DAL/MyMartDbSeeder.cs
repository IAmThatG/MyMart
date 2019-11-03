using System;
using Microsoft.EntityFrameworkCore;
using MyMart.DAL.Entities;

namespace MyMart.DAL
{
    public static class MyMartDbSeeder
    {
        public static void SeedCustomer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasData(
                    new Customer
                    {
                        Id = 1,
                        Firstname = "Austin",
                        Lastname = "Ovia",
                        Email = "austin_ovia@vatebra.com",
                        PhoneNumber = "08022334567",
                    }
                );
            });
        }

        public static void SeedRack(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rack>(entity =>
            {
                entity.HasData(
                    new Rack
                    {
                        Id = 1,
                        Name = "Phones and Accessories",
                        Description = "For mobile gadgets",
                    },
                    new Rack
                    {
                        Id = 2,
                        Name = "Laptops and Accessories",
                        Description = "Get your Laptops and accessories",
                    }
                );
            });
        }

        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Samsung Galaxy S10",
                        Description = "This is Samsung's latest phone",
                        Price = 300_000.00M,
                        RackId = 1,
                        
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "MacBook Pro 2019",
                        Description = "This is the latest macbook pro",
                        Price = 1_000_000M,
                        RackId = 2,
                        
                    }
                );
            });
        }

        public static void SeedPaymentDetail(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasData(
                    new PaymentDetail {
                        Id = 1,
                        CustomerId = 1,
                        CardHolder = "Austin Ovia",
                        CardType = CardType.MASTERCARD,
                        CardNumber = "123456789101112",
                        Cvv = "123",
                        ExpiryDate = DateTime.Now.AddYears(2),
                        
                    }
                );
            });
        }
    }
}