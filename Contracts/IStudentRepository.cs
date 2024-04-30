using Entities.Models;

namespace Contracts
{
    public interface IStudentRepository
    {
        //IEnumerable<Account> AccountsByOwner(Guid ownerId);
        bool IsValidForAsync { get; set; }

        int Create(int id);

        Task<int> CreateAsync(Student? student);

        Student GetStudentById(int? studentId);

        bool Delete(int Id);

        Task<bool> DeleteAsync(int Id);

        string Update(string newname);

        Task<string> UpdateAsync(string newname);

        Student GetStudentNameById(int id);

        Task<Student> GetStudentNameByIdAsync(int id);
    }
}
