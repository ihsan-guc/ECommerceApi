using ECommerce.Data.DAL.Abstract;
using System.Linq;

namespace ECommerce.Data.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ECommerceContext eCommerceContext, IApplicationUserRepository applicationUserRepository,
            ITokenRepository tokenRepository)
        {
            ECommerceContext = eCommerceContext;
            ApplicationUserRepository = applicationUserRepository;
            TokenRepository = tokenRepository;
        }
        public ECommerceContext ECommerceContext { get; set; }
        public IApplicationUserRepository ApplicationUserRepository { get; set ;}
        public ITokenRepository TokenRepository{ get; set ;}

        public void Commit()
        {
            ECommerceContext.SaveChanges();
        }
    }
}
