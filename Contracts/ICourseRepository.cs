using Entities.Models;

namespace Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        bool IsValidForAsync { get; set; }
        Course GetCourseNameById(int id);
        Task<Course> GetCourseNameByIdAsync(int id);
    }
}
