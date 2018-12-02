namespace Emploies.Application.Core
{
    using System;

    using Emploies.Application.Core.Contracts;
    using Emploies.Services;
    using Emploies.Application.Services;
    using Emploies.DTOs;
    using Emploies.Application.Engines;

    class ManagerInfoCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Gray;

        private readonly EmploiesService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var ManagerID = Convert.ToInt32(commandParameters[1]);

            ManagerDTO manager = new ManagerDTO();
            if (employeeService.EmployeeExists(ManagerID))
            {
                manager = employeeService.GetManagerByID(ManagerID);
            }

            OutputProvider.PrintMessage(manager.ToString(), Color);
        }
    }
}
