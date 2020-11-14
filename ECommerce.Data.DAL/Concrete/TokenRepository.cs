using ECommerce.Data.DAL.Abstract;
using ECommerce.Data.Domain.Entities;

namespace ECommerce.Data.DAL.Concrete
{
    public interface ITokenRepository : IEfRespository<Token>
    {

    }
    public class TokenRepository : EfRepository<Token>, ITokenRepository
    {
        public TokenRepository(ECommerceContext context):base(context)
        {

        }

    }

}
