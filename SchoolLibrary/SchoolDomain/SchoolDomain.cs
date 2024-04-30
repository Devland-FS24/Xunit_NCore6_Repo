using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;


namespace SchoolLibrary.SchoolDomain
{
    public class SchoolDomain
    {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        //private readonly IPaymentGateway _paymentAPI;

        public SchoolDomain(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAdultStudent(StudentForCreationDto student)
        {
            try
            {

                if (student is null)
                {
                    _logger.LogError("Student object sent from client is null.");
                    return -10;
                }

                if(int.Parse(student.Age)<18)
                {
                    _logger.LogError("Student is underage.");
                    return -20;
                }

                var studentEntity =  _mapper.Map<Student>(student);

                await _repository.Student.CreateAsync(studentEntity);
                _repository.Save();

                var createdStudent = _mapper.Map<StudentDto>(studentEntity);

                return 10;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAdultStudent action: {ex.Message}");
                return -30;
            }

        }

        public async Task<int> AdultStudentContractsExistingCourse(CourseScheduleForCreationDto courseschedule)
        {
            
            try
            {
                var idtransaction = 0;
                var createCourseSchedule = new CourseScheduleDto();

                if (courseschedule is null)
                {
                    _logger.LogError("Course Schedule Transaction object sent from client is null.");
                    return -10;
                }
                               
                var localstudent = _repository.Student.GetStudentNameById(courseschedule.StudentId.Value);

                if (int.Parse(localstudent.Age) < 18)
                {
                    _logger.LogError("Student is underage.");
                    return -20;
                }

                //This business rule assumes the Course exists, since it was selected from a list
                //of available courses on the UI.

                //For Demo purpose this method won't implement an actual data insertion
                var coursescheduleEntity = _mapper.Map<CourseSchedule>(courseschedule);

                Repository.PaymentGatewayRepository _paymentAPI = new Repository.PaymentGatewayRepository();
                _paymentAPI.IsValidForAsync = true;
                var purchasestatus = await _paymentAPI.SaleAsync(1);


                if (purchasestatus == "Approved")
                {
                    idtransaction = 10;

                    //For Demo purpose this method won't implement an actual data insertion
                    createCourseSchedule = _mapper.Map<CourseScheduleDto>(coursescheduleEntity);

                }

                //For Demo purpose this method won't implement an actual data insertion
                //await _repository.CourseSchedule.CreateAsync(courseschaduleEntity);
                //_repository.Save();             

                return idtransaction;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAdultStudent action: {ex.Message}");
                return -30;
            }
        }

    }
}
