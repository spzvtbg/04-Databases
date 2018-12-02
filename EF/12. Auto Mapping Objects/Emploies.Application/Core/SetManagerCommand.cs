namespace Emploies.Application.Core
{
    using System;

    using Emploies.Application.Constants;
    using Emploies.Application.Engines;
    using Emploies.Application.Services;
    using Emploies.Services;
    using Emploies.Application.Core.Contracts;

    internal class SetManagerCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Green;

        private readonly EmploiesService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var EmployeeID = Convert.ToInt32(commandParameters[1]);
            var ManagerID = Convert.ToInt32(commandParameters[2]);

            if (employeeService.EmployeeExists(EmployeeID) && employeeService.EmployeeExists(ManagerID))
            {
                employeeService.SetManager(EmployeeID, ManagerID);
            }

            OutputProvider.PrintMessage(Strings.SetManager, Color);
        }
    }
}
