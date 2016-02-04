using AutoMapper;
using QA.InterviewV2.Data.Entities;
using QA.InterviewV2.Models;

namespace QA.InterviewV2.Config
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureUserMapping();
        }

        private static void ConfigureUserMapping()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            Mapper.CreateMap<Dependent, DependentViewModel>().ReverseMap();
        }
    }
}
