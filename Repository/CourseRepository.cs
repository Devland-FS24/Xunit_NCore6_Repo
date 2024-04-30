using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(SchoolDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }

        public bool IsValidForAsync { get; set; }
        public Course GetCourseNameById(int id)
        {
            // This code goes to the database, finds the given id, and retrieves
            // that user's name to us.
            var mycourse = new Course();
    
            // Simulating some work:
            if (id == 1)
               mycourse.Name = "Sharepoint 101";      
            else
                mycourse.Name = "Python in 2 hours";

            return mycourse;
        }
        public Task<Course> GetCourseNameByIdAsync(int id)
        {
            // Get user's name from the database, asynchronously.

            if (!IsValidForAsync)
                throw new InvalidOperationException();

            var coursebyid = Task.Run(() => GetCourseNameById(1));

            return coursebyid;

        }

    }
}
