using System;
using System.Linq;

public abstract class Books
{
    protected string title;

    protected string autor;

    protected decimal price;

    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Autor
    {
        get
        {
            return this.autor;
        }
        set
        {
            if (value.Substring(value.IndexOf(" ") + 1).ToCharArray().Any(c => c >= '0' && c <= '9'))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.autor = value;
        }
    }

    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public Books()
    {

    }
}
