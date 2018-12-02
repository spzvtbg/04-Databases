using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        var box = new Box();
        box.Length = Convert.ToDouble(Console.ReadLine());
        box.Width = Convert.ToDouble(Console.ReadLine());
        box.Height = Convert.ToDouble(Console.ReadLine());
        box.Print();
    }
}
