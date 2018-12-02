using System;

public class Box
{
    private double length;

    private double width;

    private double height;

    public double Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
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
