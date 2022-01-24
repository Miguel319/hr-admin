using Admin_HR.Domain.Entities;
using AutoMapper;
using HR_Admin.Application.Employees;

namespace HR_Admin.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Department, Department>();
            CreateMap<Position, Position>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, Employee>();
        }
    }
}