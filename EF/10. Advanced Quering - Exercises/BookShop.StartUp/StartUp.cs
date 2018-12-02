namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    using BookShop.Data;
    using BookShop.Models;
    using BookShop.Initializer;
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BookShopContext context = new BookShopContext())
            {
                // Task1:
                Console.WriteLine(GetBooksByAgeRestriction(context, Console.ReadLine()));

                //// Task2:
                //Console.WriteLine(GetGoldenBooks(context));

                //// Task3:
                //Console.WriteLine(GetBooksByPrice(context));

                //// Task4:
                //Console.WriteLine(GetBooksNotRealeasedIn(context, Convert.ToInt32(Console.ReadLine())));

                //// Task5:
                //Console.WriteLine(GetBooksByCategory(context, Console.ReadLine()));

                //// Task6:
                //Console.WriteLine(GetBooksReleasedBefore(context, Console.ReadLine()));

                //// Task7:
                //Console.WriteLine(GetAuthorNamesEndingIn(context, Console.ReadLine()));

                //// Task8:
                //Console.WriteLine(GetBookTitlesContaining(context, Console.ReadLine()));

                //// Task9:
                //Console.WriteLine(GetBooksByAuthor(context, Console.ReadLine()));

                //// Task10:
                //Console.WriteLine(CountBooks(context, Convert.ToInt32(Console.ReadLine())));

                //// Task11:
                //Console.WriteLine(CountCopiesByAuthor(context));

                //// Task12:
                //Console.WriteLine(GetTotalProfitByCategory(context));

                //// Task13:
                //Console.WriteLine(GetMostRecentBooks(context));

                //// Task14:
                //IncreasePrices(context);

                //// Task15:
                //Console.WriteLine(RemoveBooks(context));
            }
        }


        /// <summary>
        /// Task15: Removes books with less than 4200 copies. Return count of affected rows.
        /// </summary>
        /// <param name="context"></param>
        public static int RemoveBooks(BookShopContext context)
        {
            var initialCount = context.Books.Count();
            var books = context.Books.Where(b => b.Copies < 4200).ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();
            var removedCount = initialCount - context.Books.Count();

            return removedCount;
        }


        /// <summary>
        /// Task14: Increase price for each book releaced befor 2010
        /// </summary>
        /// <param name="context"></param>
        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(x => x.ReleaseDate.GetValueOrDefault().Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }


        /// <summary>
        /// Task13: Return collection from categories with their top 3 most resent boks.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var collection = context.Categories
                .OrderBy(c => c.Name)
                .Select(x => new
                {
                    Categorie = $"--{x.Name}",
                    Books = string.Join(Environment.NewLine, x.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate).Take(3)
                        .Select(row => $"{row.Book.Title} ({row.Book.ReleaseDate.GetValueOrDefault().Year})"))
                });

            return string.Join(Environment.NewLine, collection
                .Select(x => $"{x.Categorie}{Environment.NewLine}{x.Books}"));
        }


        /// <summary>
        /// Task12: Get total profit by category.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Sum(c => c.Book.Price * c.Book.Copies)
                })
                .OrderByDescending(r => r.Profit)
                .ThenBy(r => r.Name);

            return string.Join(Environment.NewLine, result.Select(r => $"{r.Name} ${r.Profit:F2}"));
        }


        /// <summary>
        /// Task11: Get total copies sum for each author.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var countCopiesByAuthor = context.Authors
                .Select(x => new
                {
                    Author = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(x => x.Copies);

            return string.Join(Environment.NewLine, countCopiesByAuthor.Select(r => $"{r.Author} - {r.Copies}"));
        }


        /// <summary>
        /// Task10: Get Count of books where title length greater than check value.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="lengthCheck"></param>
        /// <returns></returns>
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(x => x.Title.Length > lengthCheck);
        }


        /// <summary>
        /// Task9: Get book titles with author hwo's last name start with given string.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input, true, null))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})");

            return string.Join(Environment.NewLine, booksByAuthor);
        }


        /// <summary>
        /// Task8: Search books hows titles contains given string.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        /// => string ageRestriction = input.Trim().ToLower();
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var authors = context.Books
                .Where(x => x.Title.ToLower().Contains(input.Trim()))
                .Select(t => t.Title)
                .OrderBy(t => t);

            return string.Join(Environment.NewLine, authors);
        }


        /// <summary>
        /// Task7: Search author hwo's first name ends with given string.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors =  context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(n => n.FirstName + " " + n.LastName)
                .OrderBy(fullName => fullName);

            return string.Join(Environment.NewLine, authors);
        }


        /// <summary>
        /// Task6: Get books releaced before given year.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var split = date.Split(new[] { "-", "\t", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var day = Convert.ToInt32(split[0]);
            var month = Convert.ToInt32(split[1]);
            var year = Convert.ToInt32(split[2]);
            var newDate = new DateTime(year, month, day);

            var result = context.Books
                .Where(b => b.ReleaseDate < newDate)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title);

            return string.Join(Environment.NewLine, result);
        }


        /// <summary>
        /// Task5: Get books by category.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var splitedInput = input.ToLower()
                .Split(new[] { " ", "\t", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var result = context.Books
                .Where(b => b.BookCategories.Any(c => splitedInput.Contains(c.Category.Name.ToLower())))
                .Select(t => t.Title)
                .OrderBy(t => t);

            return string.Join(Environment.NewLine, result);
        }


        /// <summary>
        /// Task4: Get books not releaced in given year.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var result = context.Books
                .Where(b => b.ReleaseDate.GetValueOrDefault().Year != year)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title);

            return string.Join(Environment.NewLine, result);
        }


        /// <summary>
        /// Task3: Get books by price higher than 40.
        /// </summary>
        /// <param name="context"></param>
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(x => new { Title = x.Title, Price = x.Price })
                .OrderByDescending(x =>x.Price);

            return string.Join(Environment.NewLine, booksByPrice.Select(x => $"{x.Title} - ${x.Price:0.00}"));
        }

        /// <summary>
        /// Task2: Get golden books: with more than 5000 copies.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == (EditionType)2 && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title);

            return string.Join(Environment.NewLine, goldenBooks);
        }


        /// <summary>
        /// Task1: Age restriction.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ageRestriction"></param>
        /// <returns></returns>
        /// => string ageRestriction = input.Trim().ToLower();
        public static string GetBooksByAgeRestriction(BookShopContext context, string ageRestriction)
        {
            int searchedRestriction = -1;
            if (ageRestriction.ToLower() == "minor")
            {
                searchedRestriction = 0;
            }
            else if (ageRestriction.ToLower() == "teen")
            {
                searchedRestriction = 1;
            }
            else if (ageRestriction.ToLower() == "adult")
            {
                searchedRestriction = 2;
            }

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction)searchedRestriction)
                .Select(t => t.Title)
                .OrderBy(t => t);

            return string.Join(Environment.NewLine, bookTitles);
        }
    }
}
