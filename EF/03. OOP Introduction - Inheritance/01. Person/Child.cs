using System;

public class Child : Human
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
            if (value > 15)
            {
                throw new ArgumentException($"Child's age must be less than 15!");
            }
            base.age = value;
        }
    }

    public Child(string name, int age) : base()
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}
