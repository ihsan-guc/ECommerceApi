using ECommerce.Data.DAL.Abstract;
using ECommerce.Data.Domain.Entities;
using System.Linq;

namespace ECommerce.Data.DAL.Concrete
{
    public interface IBookRepository : IEfRespository<Book>
    {
        int BookRepositoryCount();
    }
    public class BookRepository: EfRepository<Book>, IBookRepository
    {
        public BookRepository(ECommerceContext context):base(context)
        {

        }

        public int BookRepositoryCount()
        {
            return DbSet.ToList().Count();
        }
    }

}
