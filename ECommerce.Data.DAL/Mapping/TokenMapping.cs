using ECommerce.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.DAL.Mapping
{
    public class TokenMapping : IEntityTypeConfiguration<Token>
    {
        public TokenMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(b => b.Id); 
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}
