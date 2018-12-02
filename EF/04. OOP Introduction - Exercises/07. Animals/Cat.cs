public class Cat : Contracts.Animal
{
    public Cat(string name, string age, string gender) : base()
    {
        base.Name = name;
        base.Age = age;
        base.Gender = gender;
    }

    public override string ProduceSound()
    {
        return Common.Strings.Cat;
    }
}