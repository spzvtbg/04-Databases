using System;

public class Dog : Contracts.Animal
{
    public Dog(string name, string age, string gender) : base()
    {
        base.Name = name;
        base.Age = age;
        base.Gender = gender;
    }

    public override string ProduceSound()
    {
        return Common.Strings.Dog;
    }
}