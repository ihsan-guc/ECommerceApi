using ECommerce.Data.DAL.Abstract;

namespace ECommerce.Data.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ECommerceContext eCommerceContext, IApplicationUserRepository applicationUserRepository,
            ITokenRepository tokenRepository, IBookCategoryRepository bookCategoryRepository, IBookRepository bookRepository)
        {
            ECommerceContext = eCommerceContext;
            ApplicationUserRepository = applicationUserRepository;
            TokenRepository = tokenRepository;
            BookCategoryRepository = bookCategoryRepository;
            BookRepository = bookRepository;
        }
        public ECommerceContext ECommerceContext { get; set; }
        public IApplicationUserRepository ApplicationUserRepository { get; set ;}
        public IBookRepository BookRepository{ get; set ;}
        public IBookCategoryRepository BookCategoryRepository{ get; set ;}
        public ITokenRepository TokenRepository{ get; set ;}

        public void Commit()
        {
            ECommerceContext.SaveChanges();
        }
    }
}
