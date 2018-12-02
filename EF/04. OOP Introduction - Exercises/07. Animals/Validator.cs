using System;

public class Validator
{
    public static void/*Contracts.Animal*/ IsValidAnimal(string input)
    {
        if (input == nameof(Dog))
        {
            Common.AnimalHelper.NewDog(Console.ReadLine());
            //return Common.AnimalHelper.NewDog(Console.ReadLine());
        }
        else if (input == nameof(Frog))
        {
            Common.AnimalHelper.NewFrog(Console.ReadLine());
            //return Common.AnimalHelper.NewFrog(Console.ReadLine());
        }
        else if (input == nameof(Cat))
        {
            Common.AnimalHelper.NewCat(Console.ReadLine());
            //return Common.AnimalHelper.NewCat(Console.ReadLine());
        }
        else if (input == nameof(Kitten))
        {
            Common.AnimalHelper.NewKitten(Console.ReadLine());
            //return Common.AnimalHelper.NewKitten(Console.ReadLine());
        }
        else if (input == nameof(Tomcat))
        {
            Common.AnimalHelper.NewTomcat(Console.ReadLine());
            //return Common.AnimalHelper.NewTomcat(Console.ReadLine());
        }
        else
        {
            Console.ReadLine();
            throw new Exception(Common.Strings.ExceptionMessage);
        }
    }

    //public static string[] IsValidLength(string[] input, int mustLength)
    //{
    //    if (input.Length < mustLength)
    //    {
    //        throw new Exception(Common.Strings.ExceptionMessage);
    //    }
    //    return input;
    //}

    public static void IsValidParameter(string input)
    {
        if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
        {
            throw new Exception(Common.Strings.ExceptionMessage);
        }
    }

    public static int IsValidAge(string input)
    {
        var age = Common.Ints.Zero;
        if (!int.TryParse(input, out age))
        {
            throw new Exception(Common.Strings.ExceptionMessage);
        }
        if (age < Common.Ints.Zero)
        {
            throw new Exception(Common.Strings.ExceptionMessage);
        }
        return age;
    }
}