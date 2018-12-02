namespace Emploies.Application.Core
{
    using System;

    using Emploies.Application.Core.Contracts;
    using Emploies.Services;
    using Emploies.Application.Services;
    using System.Linq;

    internal class ListEmployeesOlderThanCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Green;

        private readonly EmploiesService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var age = Convert.ToInt32(commandParameters[1]);

            foreach (var item in employeeService.GetEmployeesOlderThan(age).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
