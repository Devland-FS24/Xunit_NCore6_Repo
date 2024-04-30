using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("student")]
    public partial class Student
    {
        public Student()
        {
            CourseSchedules = new HashSet<CourseSchedule>();
        }

        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public string? Age { get; set; }

        public virtual ICollection<CourseSchedule> CourseSchedules { get; set; }
    }
}
