public class Kitten : Cat
{
    public Kitten(string name, string age) : base(name, age, Common.Strings.KittensGender)
    {
        base.Name = name;
        base.Age = age;
        base.Gender = Common.Strings.KittensGender;
    }

    public override string ProduceSound()
    {
        return Common.Strings.Kitten;
    }
}