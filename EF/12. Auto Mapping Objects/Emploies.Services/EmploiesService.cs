namespace Emploies.Services
{
    using System;
    using System.Linq;

    using AutoMapper;
    using Emploies.Data;
    using Emploies.DTOs;
    using Emploies.Models;
    using Emploies.Services.Contracts;

    public class EmploiesService : IService
    {
        private readonly EmploiesContext Context;

        public EmploiesService(EmploiesContext context)
        {
            this.Context = context;
        }

        public void AddEmployee(EmployeeDTO employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);
            this.Context.Emploies.Add(employee);
            this.Context.SaveChanges();
        }

        public void SetBirthday(EmployeeBirthdayDTO employeeBirthdayDTO)
        {
            var employee = this.Context.Emploies.FirstOrDefault(e => e.ID == employeeBirthdayDTO.ID);
            employee.Birthday = employeeBirthdayDTO.Birthday;
            this.Context.SaveChanges();
        }

        public TModel GetEmployeeByID<TModel>(int ID)
        {
            var employee = this.Context.Emploies.FirstOrDefault(e => e.ID == ID);
            return Mapper.Map<TModel>(employee);
        }

        public ManagerDTO GetManagerByID(int ID)
        {
            var emploies = this.Context.Emploies.ToList();

            var manager = emploies.Find(x => x.ID == ID);

            var managedEmploies = emploies.Where(x => x.ManagerID == ID).ToList();

            var currentManager = new ManagerDTO();
            currentManager.FirstName = manager.FirstName;
            currentManager.Surname = manager.Surname;
            currentManager.ManagedEmployees = managedEmploies;

            return currentManager;
        }

        public void SetAddress(int ID, string newAddress)
        {
            var currentEmployee = this.Context.Emploies.FirstOrDefault(e => e.ID == ID);
            currentEmployee.Addresse = newAddress;
            this.Context.SaveChanges();
        }

        public bool EmployeeExists(int ID)
        {
            return this.Context.Emploies.Any(e => e.ID == ID);
        }

        public void SetManager(int ID, int ManagerID)
        {
            var employee = this.Context.Emploies.Find(ID);
            employee.ManagerID = ManagerID;
            this.Context.SaveChanges();
        }

        public EmployeesOlderThanDto[] GetEmployeesOlderThan(int age)
        {
            var employeesAge = this.Context.Emploies.ToArray();
            var random = new Random();
            foreach (var item in employeesAge)
            {
                var year = random.Next(1960, 2007);
                var month = random.Next(1, 13);
                var day = random.Next(1, 29);
                item.Birthday = new DateTime(year, month, day);
            }
            this.Context.SaveChanges();

            var employees = this.Context.Emploies
                .Where(e => ((DateTime.Now - (e.Birthday.HasValue? e.Birthday.Value: DateTime.Now))
                .Days / 365) > age)
                .Select(x => new EmployeesOlderThanDto()
                {
                    Name = $"{x.FirstName} {x.Surname}",
                    Salary = x.Salary,
                    Manager = new ManagerInfoDto()
                    {
                        LastName = x.Surname
                    }
                }).ToArray();
            return employees;
        }
    }
}
