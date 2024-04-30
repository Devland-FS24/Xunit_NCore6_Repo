using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CourseScheduleRepository : RepositoryBase<CourseSchedule>, ICourseScheduleRepository
    {
        public CourseScheduleRepository(SchoolDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool IsValidForAsync { get; set; }


    }
}
