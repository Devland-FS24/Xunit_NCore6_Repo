using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(SchoolDBContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool IsValidForAsync { get; set; }

        public int Create(int id)
        {
            try
            {
                if (id < 18)
                    return 0;

                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public Student GetStudentById(int? studentId)
        {
            return FindByCondition(student => student.Id.Equals(studentId))
                .FirstOrDefault();
        }

        public Task<int> CreateAsync(Student? student)
        {
            if (IsValidForAsync == true)
            {
                var createstatus = Task.Run(() => Create(student.Id));

                return createstatus;
            }
            else
            {
                throw new Exception("Using async method was not valid.");
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                if (Id > 10)
                    return true;

                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Task<bool> DeleteAsync(int Id)
        {
            if (IsValidForAsync == true)
            {
                var name = Task.Run(() => Delete(11));

                return name;
            }
            else
            {
                throw new Exception("Using async method was not valid.");
            }
        }

        public string Update(string newname)
        {
            try
            {
                if (!string.IsNullOrEmpty(newname))
                    return newname;

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Task<string> UpdateAsync(string newname)
        {
            if (IsValidForAsync == true)
            {
                var name = Task.Run(() => Update("Amelia"));

                return name;
            }
            else
            {
                throw new Exception("Using async method was not valid.");
            }
        }

        public Student GetStudentNameById(int id)
        {
            // This code goes to the database, finds the given id, and retrieves
            // that user's name to us.
            var mystudent = new Student();
            
            // Simulating some work:

                if (id == 1)
                    mystudent.Name = "Amelia";             
                else
                    mystudent.Name = "John";

                return mystudent;
            
        }

        public Task<Student> GetStudentNameByIdAsync(int id)
        {
            // Get user's name from the database, asynchronously.

            if (IsValidForAsync == true)
            {
                var asyncstudent = Task.Run(() => GetStudentNameById(id));

                return asyncstudent;
            }
            else
            {
                throw new Exception("Using async method was not valid.");
            }
        }

    }
}
