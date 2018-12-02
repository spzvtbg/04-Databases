using System;

public class GoldenEditionBook : Books
{
    public override decimal Price
    {
        get
        {
            return this.price * 1.3m;
        }
    }

    public GoldenEditionBook(string autor, string title, decimal price) : base()
    {
        base.Title = title;
        base.Autor = autor;
        base.Price = price;
    }

    public override string ToString()
    {
        return "Type: GoldenEditionBook\n"
            + $"Title: {base.Title}\n"
            + $"Author: {base.Autor}\n"
            + $"Price: {this.Price:F2}\n";
    }
}

