using Admin_HR.Domain.Entities;
using AutoMapper;

namespace HR_Admin.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Department, Department>();
        }
    }
}