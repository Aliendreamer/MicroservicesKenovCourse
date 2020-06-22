namespace Server.Models
{
    using System;

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int Pages { get; set; }

        public DateTime YearOfPublish { get; set; }
    }
}
