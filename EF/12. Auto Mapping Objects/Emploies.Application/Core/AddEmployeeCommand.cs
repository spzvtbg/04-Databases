namespace Emploies.Application.Core
{
    using System;

    using Emploies.DTOs;
    using Emploies.Services;
    using Emploies.Application.Engines;
    using Emploies.Application.Services;
    using Emploies.Application.Constants;
    using Emploies.Application.Core.Contracts;

    internal class AddEmployeeCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Green;

        private readonly EmploiesService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var employeeDto = new EmployeeDTO();
            employeeDto.FirstName = commandParameters[1];
            employeeDto.Surname = commandParameters[2];
            employeeDto.Salary = Convert.ToDecimal(commandParameters[3]);
            employeeService.AddEmployee(employeeDto);

            OutputProvider.PrintMessage(Strings.AddedEmployee, Color);
        }
    }
}
