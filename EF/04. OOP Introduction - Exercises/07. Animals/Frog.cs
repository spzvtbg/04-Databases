public class Frog : Contracts.Animal
{
    public Frog(string name, string age, string gender) : base()
    {
        base.Name = name;
        base.Age = age;
        base.Gender = gender;
    }

    public override string ProduceSound()
    {
        return Common.Strings.Frog;
    }
}