using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Persistences
{
    public class NotificationContext : DbContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options) { }
        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<NotificationLogsModel> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotificationLogsModel>()
                        .HasOne(j => j.notification)
                        .WithMany()
                        .HasForeignKey(j => j.notification_id);
        }
    }
}
