using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMart.DAL.Entities;

namespace MyMart.DAL
{
    public class MyMartDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Rack> Racks { get; set; }

        public MyMartDbContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCustomerConstraints();
            modelBuilder.ConfigureOrderConstraints();
            modelBuilder.ConfigurePaymentDetailConstraints();
            modelBuilder.ConfigureProductConstraints();
            modelBuilder.ConfigureRackConstraints();
            modelBuilder.ConfigureApplicationUserConstraints();
            modelBuilder.ConfigureApplicationRoleConstraints();

            //modelBuilder.SeedCustomer();
            //modelBuilder.SeedPaymentDetail();
            modelBuilder.SeedProduct();
            modelBuilder.SeedRack();
        }
    }
}
