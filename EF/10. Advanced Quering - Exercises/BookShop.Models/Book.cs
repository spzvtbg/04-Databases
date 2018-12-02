﻿namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;

    public class Book
    {
        public Book()
        {
            this.BookCategories = new List<BookCategory>();
        }

        public ICollection<BookCategory> BookCategories { get; set; }

        public int BookId { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int Copies { get; set; }

        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Title { get; set; }
    }
}
