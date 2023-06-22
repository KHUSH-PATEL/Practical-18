using AutoMapper;
using Elfie.Serialization;

namespace WebApiDemoCore.Models
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
