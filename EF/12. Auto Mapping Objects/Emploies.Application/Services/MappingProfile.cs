namespace Emploies.Application.Services
{
    using AutoMapper;
    using Emploies.DTOs;
    using Emploies.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<Employee, EmployeeInfoDTO>();

            CreateMap<Employee, EmployeeBirthdayDTO>();

            CreateMap<Employee, ManagerDTO>();
        }
    }
}
