using ECommerce.Data.Domain.Entities;
using Message.Api.Models.Response;
using System.Collections.Generic;

namespace ECommerce.Api.Models.Response
{
    public class BooksResponse : BaseResponse
    {
        public BooksResponse()
        {
            BookList = new List<Book>();
        }
        public List<Book> BookList{ get; set; }
    }
}
