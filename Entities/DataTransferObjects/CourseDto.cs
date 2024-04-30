using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? RegistrationFee { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual ICollection<CourseSchedule> CourseSchedules { get; set; }
    }
}
