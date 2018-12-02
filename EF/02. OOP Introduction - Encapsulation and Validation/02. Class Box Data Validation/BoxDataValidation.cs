using System;
using System.Linq;
using System.Reflection;

public class BoxDataValidation
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        var length = Convert.ToDouble(Console.ReadLine());
        var width = Convert.ToDouble(Console.ReadLine());
        var height = Convert.ToDouble(Console.ReadLine());

        try
        {
            var box = new Box(length, width, height);
            box.Print();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}