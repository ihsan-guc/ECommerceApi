using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain.Entities
{
    public class ApplicationUser : BaseGuidEntity
    {
        public int TokenId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public Token Token { get; set; }
    }
}
