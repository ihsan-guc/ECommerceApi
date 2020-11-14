using ECommerce.Data.DAL.Abstract;
using ECommerce.Data.Domain.Entities;
using System.Linq;

namespace ECommerce.Data.DAL.Concrete
{
    public interface IApplicationUserRepository : IEfRespository<ApplicationUser>
    {
        int ApplicationUserCount();
    }
    public class ApplicationUserRepository : EfRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ECommerceContext context):base(context)
        {

        }

        public int ApplicationUserCount()
        {
            return DbSet.ToList().Count();
        }
    }

}
