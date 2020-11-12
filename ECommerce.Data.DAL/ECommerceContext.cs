using ECommerce.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.Data.DAL
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers{ get; set; }
        public DbSet<Token> Tokens{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasOne(navigationExpression: p => p.Token)
                .WithOne(navigationExpression: t => t.ApplicationUser)
                .HasForeignKey<Token>(p=>p.ApplicationUserId);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
