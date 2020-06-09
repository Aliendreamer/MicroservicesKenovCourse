using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int Pages { get; set; }
        public DateTime YearOfPublish { get; set; }
    }
}
