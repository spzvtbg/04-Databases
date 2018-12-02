namespace Emploies.Application.Core
{
    using System;
    using System.Linq;

    using Emploies.Application.Core.Contracts;
    using Emploies.Application.Services;
    using Emploies.Services;
    using Emploies.Services.Contracts;
    using Emploies.Application.Engines;
    using Emploies.Application.Constants;

    internal class SetAddressCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Yellow;

        private readonly IService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var ID = Convert.ToInt32(commandParameters[1]);
            var newAddress = string.Join(" ", commandParameters.Skip(2));

            if (employeeService.EmployeeExists(ID))
            {
                employeeService.SetAddress(ID, newAddress);
                OutputProvider.PrintMessage(Strings.SetAddress, Color);
            }
        }
    }
}
