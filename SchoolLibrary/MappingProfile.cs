using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Linq;

namespace SchoolLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();

            CreateMap<CourseForCreationDto, Course>();

            CreateMap<CourseForUpdateDto, Course>();

            CreateMap<Student, StudentDto>();

            CreateMap<StudentForCreationDto, Student>();

            CreateMap<StudentForUpdateDto, Student>();

            CreateMap<CourseSchedule, CourseScheduleDto>();

            CreateMap<CourseScheduleForCreationDto, CourseSchedule>();

            CreateMap<CourseScheduleForUpdateDto, CourseSchedule>();

        }
    }
}
