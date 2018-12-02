public class Employee
{
    private string name;

    private int age;

    private string email;

    private string position;

    private string department;

    private decimal salary;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    public string Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public Employee()
    {
        this.age = -1;
        this.Email = "n/a";
    }

    public Employee(string name, decimal salary, string position, string department) : this()
    {
        this.Name = name;
        this.Position = position;
        this.Department = department;
        this.Salary = salary;
    }

    public Employee(string name, decimal salary, string position, string department
        , string email, int age) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
        this.Position = position;
        this.Department = department;
        this.Salary = salary;
    }

    public Employee(string name, decimal salary, string position, string department
        , string email) : this()
    {
        this.Name = name;
        this.age = -1;
        this.Email = email;
        this.Position = position;
        this.Department = department;
        this.Salary = salary;
    }

    public Employee(string name, decimal salary, string position, string department
        , int age) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Email = "n/a";
        this.Position = position;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:F2} {this.Email} {this.Age}";
    }
}

