using Microsoft.EntityFrameworkCore;
using SignalR_Chat_Demo.Models;

namespace SignalR_Chat_Demo.Contexts
{
    public class MSSQLDbContext : DbContext
    {
        public MSSQLDbContext(DbContextOptions<MSSQLDbContext> options) : base(options)  
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<OrderProduct>()
            //    .HasOne(bc => bc.Product)
            //    .WithMany(b => b.Orders);

        }

        public DbSet<ChatHistory> ChatHistories { get; set; }
    }
}
