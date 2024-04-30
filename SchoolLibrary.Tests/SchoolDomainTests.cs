using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Net;
using SchoolLibrary;
using SchoolLibrary.Tests.Mocks;
using Contracts;
using Entities.DataTransferObjects;
using LoggerService;
using Entities.Models;
using SchoolLibrary.SchoolDomain;
using Microsoft.AspNetCore.Mvc;


namespace SchoolLibrary.Tests
{
    public class SchoolDomainTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public async Task CreateAdultStudent_ShouldReturnStatus10Test()
        {
            // Arrange
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();

            var schooldomaintest = new SchoolDomain.SchoolDomain(logger, repositoryWrapperMock.Object, mapper);

            var studenttest = new StudentForCreationDto();

            studenttest.Name = "John";
            studenttest.Age = "20";

            // Act
            var result = await schooldomaintest.CreateAdultStudent(studenttest);

            // Assert
            Assert.Equal(10, result);

        }

        [Fact]
        public async Task AdultStudentContractsExistingCourse_ShouldReturnApprovedStatusTest()
        {
            // Arrange
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();

            var schooldomaintest = new SchoolDomain.SchoolDomain(logger, repositoryWrapperMock.Object, mapper);


            var studenttest = new StudentForCreationDto();

            studenttest.Name = "John";
            studenttest.Age = "20";

            var studentcontractscoursetest = new CourseScheduleForCreationDto();
            studentcontractscoursetest.StudentId = 1;
            studentcontractscoursetest.CourseId = 1;
            studentcontractscoursetest.Student = studenttest;

            // Act
            var result = await schooldomaintest.AdultStudentContractsExistingCourse(studentcontractscoursetest);

            // Assert
            Assert.Equal(10, result);
        }

    }
}
