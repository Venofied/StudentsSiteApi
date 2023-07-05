using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data.mocks
{
    public class MockStudent : IAllStudents
    {
        private readonly IStudentGroup _studentGroup = new MockGroup();
        public IEnumerable<Student> Students 
        {            
            get 
            { 
                return new List<Student> { 
                    new Student {Name = "testname", SurName = "testsurname", Email = "mail", Patronymic = "testpatrname"} 
                };
            }
        }

        public IEnumerable<GroupStudent> AllStudents => throw new NotImplementedException();

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Create(string name)
        {
            throw new NotImplementedException();
        }

        public bool CreateStudent(StudentCreate addStudent)
        {
            throw new NotImplementedException();
        }

        public bool CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Student Read(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student entity)
        {
            throw new NotImplementedException();
        }

        public bool updateAll(List<Student> students)
        {
            throw new NotImplementedException();
        }
    }
}
