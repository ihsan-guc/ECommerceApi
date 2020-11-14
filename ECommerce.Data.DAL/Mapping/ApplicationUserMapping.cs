using ECommerce.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.DAL.Mapping
{
    public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMapping()
        {
        }

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd(); 
            
            builder.HasOne(navigationExpression: m => m.Token)
                .WithOne(navigationExpression: g => g.ApplicationUser)
                .HasForeignKey<Token>(s => s.ApplicationUserId);
        }
    }
}
