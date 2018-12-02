using System;

public class Box
{
    private double length;

    private double width;

    private double height;

    public double Length
    {
        get { return this.length; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Length cannot be zero or negative.");
            }
            else this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Width cannot be zero or negative.");
            }
            else this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Height cannot be zero or negative.");
            }
            else this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double SurfaceArea()
    {
        return 2 * this.length * this.width
             + 2 * this.length * this.height
             + 2 * this.width * this.height;
    }

    public double LateralSurfaceArea()
    {
        return 2 * this.length * this.height + 2 * this.width * this.height;
    }

    public double Volume()
    {
        return this.length * this.width * this.height;
    }

    public void Print()
    {
        Console.WriteLine($"Surface Area - {SurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {Volume():F2}");
    }
}
