using System;

public class Person : Human
{
    public /*override*/ string Name
    {
        get
        {
            return base.name;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            base.name = value;
        }
    }

    public /*override*/ int Age
    {
        get
        {
            return base.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            base.age = value;
        }
    }

    public Person(string name, int age) : base()
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}
