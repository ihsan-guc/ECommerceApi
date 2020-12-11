using ECommerce.Data.DAL.Concrete;

namespace ECommerce.Data.DAL.Abstract
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUserRepository { get; set;}
        ITokenRepository TokenRepository{ get; set ;}
        IBookRepository BookRepository { get; set; }
        IBookCategoryRepository BookCategoryRepository { get; set; }
        void Commit();
    }
}
