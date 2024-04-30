using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("courseschedule")]
    public partial class CourseSchedule
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }

        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
