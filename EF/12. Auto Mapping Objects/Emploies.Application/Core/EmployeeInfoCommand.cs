namespace Emploies.Application.Core
{
    using System;

    using Emploies.Application.Core.Contracts;
    using Emploies.Application.Services;
    using Emploies.Services;
    using Emploies.Services.Contracts;
    using Emploies.Application.Engines;
    using Emploies.DTOs;

    internal class EmployeeInfoCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Gray;

        private readonly IService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var ID = Convert.ToInt32(commandParameters[1]);

            if (employeeService.EmployeeExists(ID))
            {
                var currentEmployee = employeeService.GetEmployeeByID<EmployeeInfoDTO>(ID);
                OutputProvider.PrintMessage(currentEmployee.ToString(), Color);
            }
        }
    }
}
