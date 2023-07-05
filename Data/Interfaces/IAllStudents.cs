using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data.Interfaces
{
    public interface IAllStudents : IMainCRUD<Student>
    {
        IEnumerable<Student> Students { get; }
        IEnumerable<GroupStudent> AllStudents { get; }
        bool CreateStudent(Student student);
        bool updateAll(List<Student> students);

        //Student GetStudent(Guid StudentId);

    }
}
