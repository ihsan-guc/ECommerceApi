using System;

namespace ECommerce.Data.Domain.Entities
{
    public class Token : BaseGuidEntity
    {
        public Guid ApplicationUserId { get; set; }
        public string TokenString { get; set; }
        public ApplicationUser  ApplicationUser{ get; set; }
    }
}
