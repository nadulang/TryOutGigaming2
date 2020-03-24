using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;

namespace PaymentService.Infrastructure.Persistences
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }
        public DbSet<PaymentModel> AllPayments { get; set; }
        public DbSet<UsersModel> AllUsers { get; set; }
        public DbSet<OrderModel> ALOrders { get; set; }
        public DbSet<OrderDetailsModel> AllOrderDetails { get; set; }
        public DbSet<ProductModel> ALlProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>()
                        .HasOne(j => j.user)
                        .WithMany()
                        .HasForeignKey(j => j.user_id);
            modelBuilder.Entity<OrderDetailsModel>()
                        .HasOne(p => p.product)
                        .WithMany()
                        .HasForeignKey(p => p.product_id);
            modelBuilder.Entity<OrderDetailsModel>()
                        .HasOne(p => p.order)
                        .WithMany()
                        .HasForeignKey(p => p.order_id);
        }
    }
  
}
