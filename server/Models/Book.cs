using System;

namespace Server.Models
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
