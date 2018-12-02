using System;

public class Animals
{
    //static Contracts.AnimalList animals = new Contracts.AnimalList();

    public static void Main()
    {
        var input = Console.ReadLine();
        while (input != Common.Strings.EndWhile)
        {
            try
            {
                Validator.IsValidAnimal(input);
                //animals.List.Add(Validator.IsValidAnimal(input));
            }
            catch (Exception ex)
            {
                Common.AnimalHelper.PrintException(ex.Message);
            }
            input = Console.ReadLine();
        }

        //foreach (var animal in animals.List)
        //{
        //    Common.AnimalHelper.PrintAnimalInfo(animal);
        //}
    }
}