using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace SchoolLibrary.Tests
{
    public class ValidationTests
    {

        [Theory]
        [InlineData(null, null, null, null, null, false)]
        [InlineData(null, 25, null, null, null, false)]
        [InlineData(null, null, "06/04/2008", null, null, false)]
        [InlineData(null, 290, null, "06/04/2008", null, false)]
        [InlineData("TestName", 315, "06/04/2008", "2008-04-16", "39", true)]
        [InlineData("TestName", null, "06/04/2008", "2008-04-16", "39", true)]
        [InlineData("TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", 2050, "06/04/2008", "2008-04-16", "21", false)]
        public void TestModelValidation(string? name, decimal registrationfee, string? startDate, string? endDate, string? age, bool isValid)
        {
            var course = new CourseForCreationDto()
            {
                Name = name,
                RegistrationFee = registrationfee,
                StartDate = startDate is null ? DateTime.MinValue : DateTime.Parse(startDate),
                EndDate = endDate is null ? DateTime.MaxValue : DateTime.Parse(endDate)
            };

            var student = new StudentForCreationDto()
            {
                Name = name,
                Age = age
                
            };

            Assert.Equal(isValid, ValidateModel(course));
            Assert.Equal(isValid, ValidateModel(student));
        }

        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }
    }
}
