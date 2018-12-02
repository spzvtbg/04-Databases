namespace Emploies.Application
{
    using System;
    using Emploies.Application.Engines;
    using Emploies.Data;
    using Microsoft.EntityFrameworkCore;
    using Emploies.Models;

    internal class Startup
    {
        internal static void Main()
        {
            //using (EmploiesContext context = new EmploiesContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //    context.Database.Migrate();
            //    context.Emploies.AddRange(Seed(context));
            //    context.SaveChanges();

            //    var x = context.Emploies.Find(11);
            //}
            //System.Console.WriteLine("Done");

            Engine engine = new Engine();
            engine.Run();
        }

        private static Employee[] Seed(EmploiesContext context)
        {
            return new Employee[]
            {
                new Employee() //1
                {
                    FirstName = "Pesho",
                    Surname = "Petrov",
                    Salary = 2000
                },
                new Employee()//2
                {
                    FirstName = "Ivan",
                    Surname = "Petrov",
                    Salary = 1000,
                    ManagerID = 1
                },
                new Employee()//3
                {
                    FirstName = "Stamat",
                    Surname = "Ivanov",
                    Salary = 1000,
                    ManagerID = 1
                },
                new Employee()//4
                {
                    FirstName = "Maria",
                    Surname = "Doe",
                    Salary = 2000
                },
                new Employee()//5
                {
                    FirstName = "Gosho",
                    Surname = "Goshov",
                    Salary = 1000,
                    ManagerID = 4
                },
                new Employee()//6
                {
                    FirstName = "Stephen",
                    Surname = "King",
                    Salary = 1000,
                    ManagerID = 4
                },
                new Employee()//7
                {
                    FirstName = "John",
                    Surname = "Malkovich",
                    Salary = 1000,
                    ManagerID = 4
                },
                new Employee()//8
                {
                    FirstName = "Ivanka",
                    Surname = "Petrova",
                    Salary = 1000,
                    ManagerID = 4
                },
                new Employee()//9
                {
                    FirstName = "Mimi",
                    Surname = "Georgieva",
                    Salary = 1000,
                    ManagerID = 4
                },
                new Employee()//10
                {
                    FirstName = "Moni",
                    Surname = "Kozinac",
                    Salary = 1000,
                    ManagerID = 4
                },
                new Employee()//11
                {
                    FirstName = "Kopp",
                    Surname = "Spidok",
                    Salary = 3000
                },
                new Employee()//12
                {
                    FirstName = "Jurgen",
                    Surname = "Straus",
                    Salary = 1000,
                    ManagerID = 11
                },
                new Employee()//13
                {
                    FirstName = "Carl",
                    Surname = "Kormak",
                    Salary = 1000,
                    ManagerID = 11
                },
                new Employee()//14
                {
                    FirstName = "Kirilic",
                    Surname = "Lefi",
                    Salary = 1000,
                    ManagerID = 11
                },
                new Employee()//15
                {
                    FirstName = "Steve",
                    Surname = "Jobbsen",
                    Salary = 1000,
                    ManagerID = 11
                },
                new Employee()//16
                {
                    FirstName = "Stephen",
                    Surname = "Bjorn",
                    Salary = 1000,
                    ManagerID = 11
                },
            };
        }
    }
}
