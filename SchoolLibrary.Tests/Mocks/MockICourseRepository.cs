using Contracts;
using Entities.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Tests.Mocks
{
    internal class MockICourseRepository
    {
        public static Mock<ICourseRepository> GetMock()
        {
            var mock = new Mock<ICourseRepository>();

            var courses = new List<Course>()
            {
                new Course()
                {
                    Id = 1,
                    Name = "John",
                    RegistrationFee = 250,              
                    StartDate = DateTime.Now.AddYears(-20),
                    EndDate = DateTime.Now.AddYears(-19),
                    CourseSchedules = new List<CourseSchedule>()
                    {
                        new CourseSchedule()
                        {
                            Id = 1,
                            StudentId = 1,
                            CourseId = 1,
                        }

                    }
                }
            };

            mock.Setup(m => m.GetAllCourses()).Returns(() => courses);

            mock.Setup(m => m.GetCourseNameById(It.IsAny<int>()))
                .Returns((int id) => courses.FirstOrDefault(o => o.Id == id));

            return mock;
        }
    }
}
