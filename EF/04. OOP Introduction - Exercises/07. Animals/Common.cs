using System;

public class Common
{
    public class Strings
    {
        public const string Dog = "Woof!";

        public const string Frog = "Ribbit";

        public const string Cat = "Meow meow";

        public const string Kitten = "Meow";

        public const string KittensGender = "Female";

        public const string Tomcat = "MEOW";

        public const string TomcatGender = "Male";

        public const string EndWhile = "Beast!";

        public const string ExceptionMessage = "Invalid input!";

        public static string Animal(Contracts.Animal animal)
        {
            return $"{animal.Name} {animal.Age} {animal.Gender}";
        }
    }

    public class Chars
    {
        public const char Space = ' ';
    }

    public class Ints
    {
        public const int Zero = 0;

        public const int One = 1;

        public const int Two = 2;

        public const int Three = 3;
    }

    public class AnimalHelper
    {
        public static void/*Contracts.Animal*/ NewDog(string input)
        {
            var data = input.Split(Chars.Space);
            PrintAnimalInfo(new Dog(data[Ints.Zero], data[Ints.One], data[Ints.Two]));
            //var data = Validator.IsValidLength(input.Split(Chars.Space), Ints.Three);
            //return new Dog(data[Ints.Zero], data[Ints.One], data[Ints.Two]);
        }

        public static void/*Contracts.Animal*/ NewFrog(string input)
        {
            var data = input.Split(Chars.Space);
            PrintAnimalInfo(new Frog(data[Ints.Zero], data[Ints.One], data[Ints.Two]));
            //var data = Validator.IsValidLength(input.Split(Chars.Space), Ints.Three);
            //return new Frog(data[Ints.Zero], data[Ints.One], data[Ints.Two]);
        }

        public static void/*Contracts.Animal*/ NewCat(string input)
        {
            var data = input.Split(Chars.Space);
            PrintAnimalInfo(new Cat(data[Ints.Zero], data[Ints.One], data[Ints.Two]));
            //var data = Validator.IsValidLength(input.Split(Chars.Space), Ints.Three);
            //return new Cat(data[Ints.Zero], data[Ints.One], data[Ints.Two]);
        }

        public static void/*Contracts.Animal*/ NewKitten(string input)
        {
            var data = input.Split(Chars.Space);
            PrintAnimalInfo(new Kitten(data[Ints.Zero], data[Ints.One]));
            //var data = Validator.IsValidLength(input.Split(Chars.Space), Ints.Two);
            //return new Kitten(data[Ints.Zero], data[Ints.One]);
        }

        public static void/*Contracts.Animal*/ NewTomcat(string input)
        {
            var data = input.Split(Chars.Space);
            PrintAnimalInfo(new Tomcat(data[Ints.Zero], data[Ints.One]));
            //var data = Validator.IsValidLength(input.Split(Chars.Space), Ints.Two);
            //return new Tomcat(data[Ints.Zero], data[Ints.One]);
        }

        public static void PrintAnimalInfo(Contracts.Animal animal)
        {
            Console.WriteLine(animal.GetType().Name);
            Console.WriteLine(Strings.Animal(animal));
            Console.WriteLine(animal.ProduceSound());
        }

        public static void PrintException(string message)
        {
            Console.WriteLine(message);
        }
    }
}