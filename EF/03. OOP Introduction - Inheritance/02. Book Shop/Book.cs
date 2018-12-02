public class Book : Books
{
    public Book(string autor, string title, decimal price) : base()
    {
        base.Title = title;
        base.Autor = autor;
        base.Price = price;
    }

    public override string ToString()
    {
        return "Type: Book\n"
            + $"Title: {base.Title}\n"
            + $"Author: {base.Autor}\n"
            + $"Price: {base.Price:F2}\n";
    }
}
