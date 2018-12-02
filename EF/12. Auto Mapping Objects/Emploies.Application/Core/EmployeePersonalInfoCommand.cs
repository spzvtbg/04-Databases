namespace Emploies.Application.Core
{
    using System;

    using Emploies.Application.Core.Contracts;
    using Emploies.Application.Services;
    using Emploies.Services;
    using Emploies.Services.Contracts;
    using Emploies.Models;
    using Emploies.Application.Engines;

    internal class EmployeePersonalInfoCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Gray;

        private readonly IService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var ID = Convert.ToInt32(commandParameters[1]);

            if (employeeService.EmployeeExists(ID))
            {
                var currentEmployee = employeeService.GetEmployeeByID<Employee>(ID);
                var personalData = $@"{currentEmployee.ID} - {currentEmployee.FirstName} {currentEmployee.Surname} - ${currentEmployee.Salary:F2}";
                var birthday = $"Birthday: {currentEmployee.Birthday.Value.ToString("dd-MM-yyyy")}";
                var address = $"Address: {currentEmployee.Addresse}";

                OutputProvider.PrintMessage(personalData, Color);
                OutputProvider.PrintMessage(birthday, Color);
                OutputProvider.PrintMessage(address, Color);
            }
        }
    }
}
