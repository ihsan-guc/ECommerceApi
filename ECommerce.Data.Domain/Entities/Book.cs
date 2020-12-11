using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Domain.Entities
{
    public class Book : BaseGuidEntity
    {
        public int BookCategoryId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Publisher { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
