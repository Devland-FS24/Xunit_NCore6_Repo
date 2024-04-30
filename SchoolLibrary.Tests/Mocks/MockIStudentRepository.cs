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
    internal class MockIStudentRepository
    {
        public static Mock<IStudentRepository> GetMock()
        {
            var mock = new Mock<IStudentRepository>();

            var studentlist = new List<Student>()
            {
                new Student()
                {
                   Id=1,
                   Name= "Juan",
                   Age= "20"
                }
            };

            mock.Setup(m => m.GetStudentNameById(It.IsAny<int>()))
                .Returns((int id) => studentlist.FirstOrDefault(o => o.Id == id));

            return mock;
        }
    }
}
