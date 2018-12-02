public class Tomcat : Cat
{
    public Tomcat(string name, string age) : base(name, age, Common.Strings.TomcatGender)
    {
        base.Name = name;
        base.Age = age;
        base.Gender = Common.Strings.TomcatGender;
    }

    public override string ProduceSound()
    {
        return Common.Strings.Tomcat;
    }
}