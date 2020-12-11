using ECommerce.Data.Domain.Entities;
using Message.Api.Models.Response;

namespace ECommerce.Api.Models.Response
{
    public class BookResponse : BaseResponse
    {
        public Book Book{ get; set; }
    }
}
