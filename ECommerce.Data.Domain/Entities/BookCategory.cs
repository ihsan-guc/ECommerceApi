using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Domain.Entities
{
    public class BookCategory : BaseGuidEntity
    {
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }
        public string CategoryName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
