using ECommerce.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.DAL.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public BookMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(p => p.BookCategory)
                .WithMany(p => p.Books)
                .HasForeignKey(t => t.BookCategoryId);
        }
    }
}
