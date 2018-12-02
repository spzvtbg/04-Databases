namespace Emploies.Application.Core
{
    using System;

    using Emploies.Application.Core.Contracts;
    using Emploies.Application.Services;
    using Emploies.Services;
    using Emploies.Services.Contracts;
    using Emploies.DTOs;
    using Emploies.Application.Constants;
    using Emploies.Application.Engines;

    internal class SetBirthdayCommand : ICommand
    {
        private const ConsoleColor Color = ConsoleColor.Yellow;

        private readonly IService employeeService = CommonService.GetProvider<EmploiesService>();

        public void Execute(string[] commandParameters)
        {
            var ID = Convert.ToInt32(commandParameters[1]);

            if (employeeService.EmployeeExists(ID))
            {
                var Birthday = DateTime.Parse(commandParameters[2].Trim());
                var selectedEmployee = employeeService.GetEmployeeByID<EmployeeBirthdayDTO>(ID);
                selectedEmployee.Birthday = Birthday;
                employeeService.SetBirthday(selectedEmployee);

                OutputProvider.PrintMessage(Strings.SetBirthday, Color);
            }
        }
    }
}
