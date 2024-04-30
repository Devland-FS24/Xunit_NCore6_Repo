using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace SchoolLibrary.Tests.Mocks
{
    internal class MockIRepositoryWrapper
    {
        public static Mock<IRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IRepositoryWrapper>();
            var courseRepoMock = MockICourseRepository.GetMock();
            var studentRepoMock = MockIStudentRepository.GetMock();

            mock.Setup(m => m.Course).Returns(() => courseRepoMock.Object);
            mock.Setup(m => m.Student).Returns(() => studentRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}
