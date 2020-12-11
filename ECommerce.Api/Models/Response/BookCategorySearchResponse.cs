using ECommerce.Data.Domain.Entities;
using Message.Api.Models.Response;
using System.Collections.Generic;

namespace ECommerce.Api.Models.Response
{
    public class BookCategorySearchResponse : BaseResponse
    {
        public List<BookCategory> BookCategories{ get; set; }
    }
}
