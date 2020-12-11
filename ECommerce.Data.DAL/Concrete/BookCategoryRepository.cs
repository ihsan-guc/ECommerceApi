using ECommerce.Data.DAL.Abstract;
using ECommerce.Data.Domain.Entities;
using System.Linq;

namespace ECommerce.Data.DAL.Concrete
{
    public interface IBookCategoryRepository : IEfRespository<BookCategory>
    {
        int BookRepositoryCount();
    }
    public class BookCategoryRepository : EfRepository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(ECommerceContext context):base(context)
        {

        }

        public int BookRepositoryCount()
        {
            return DbSet.ToList().Count();
        }
    }

}
