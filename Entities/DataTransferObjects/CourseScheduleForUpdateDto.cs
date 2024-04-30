using Entities.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataTransferObjects
{
    public class CourseScheduleForUpdateDto
    {
        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }

        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
