﻿using System;
using System.Collections.Generic;

namespace server.Models
{
    public class Author
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime YearOfBirth { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
