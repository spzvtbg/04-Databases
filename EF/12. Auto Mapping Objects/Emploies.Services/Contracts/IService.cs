namespace Emploies.Services.Contracts
{
    using Emploies.DTOs;

    public interface IService
    {
        void AddEmployee(EmployeeDTO employee);

        TModel GetEmployeeByID<TModel>(int ID);

        ManagerDTO GetManagerByID(int ID);

        void SetBirthday(EmployeeBirthdayDTO employeeBirthdayDTO);

        void SetAddress(int ID, string newAddress);

        bool EmployeeExists(int ID);

        void SetManager(int ID, int ManagerID);
    }
}
