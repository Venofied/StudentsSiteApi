using System.Data.Entity;
using System.Text.RegularExpressions;
using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Models;
using Group = WebAPITask_1.Data.Models.Group;

namespace WebAPITask_1.Data.Repository
{
    public class StudentRepository : IAllStudents
    {

        private readonly AppDBContent appDBContent;
        private GroupRepository _groupRepository;

        public StudentRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
            _groupRepository = new GroupRepository(appDBContent);
        }

        public IEnumerable<Student> Students => appDBContent.Student;

        public IEnumerable<GroupStudent> AllStudents => AllGroupStudent();

        public IEnumerable<GroupStudent> AllGroupStudent()
        {
            var employees = from s in appDBContent.Student
                            join g in _groupRepository.AllGroups on s.GroupId equals g.Id
                            select new GroupStudent 
                            {
                                Id = s.Id,
                                Name = s.Name,
                                SurName = s.SurName,
                                Patronymic = s.Patronymic,
                                Email = s.Email,
                                GroupId = s.GroupId,
                                Group = new Group {Id = g.Id, Name = g.Name }
                            };
            return employees;
        }

        public bool Create(string name)
        {           

            Student newStudent = new Student();
            newStudent.Id = Guid.NewGuid();
            newStudent.Name = name;
            newStudent.SurName = String.Empty;
            newStudent.Patronymic = String.Empty;
            newStudent.Email = String.Empty;
            newStudent.GroupId = _groupRepository.GetNoGroup.Id;
            appDBContent.Entry(newStudent).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            appDBContent.SaveChanges();

            return true;
        }

        public bool CreateStudent(StudentCreate addStudent)
        {

            Student newStudent = new Student();
            newStudent.Id = Guid.NewGuid();
            newStudent.Name = addStudent.Name;
            newStudent.SurName = addStudent.SurName;
            newStudent.Patronymic = addStudent.Patronymic;
            newStudent.Email = addStudent.Email;
            newStudent.GroupId = checkIdGroup(addStudent.GroupId).parseGuid;
            appDBContent.Entry(newStudent).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            appDBContent.SaveChanges();

            return true;
        }
        public bool CreateStudent(Student addStudent)
        {            
            appDBContent.Entry(addStudent).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            appDBContent.SaveChanges();

            return true;
        }
        public bool Delete(string id)
        {
            var check = Helper.checkIdGroup(id);
            if(!check.checkResult)
            {
                return false;
            }
            else
            {
                var student = Read(check.parseGuid);
                appDBContent.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                appDBContent.SaveChanges();

                return true;
            }

        }

        public (bool checkResult, Guid parseGuid) checkIdGroup(string guidValue)
        {            
            var check = Guid.TryParse(guidValue, out var result);
            if(check)
            {
                return (true, result);
            }
            else
            {
                return (false, _groupRepository.GetNoGroup.Id);
            }
        }

        public Student Read(Guid StudentId)
        {
            var student = appDBContent.Student.FirstOrDefault(c => c.Id == StudentId);
            return student;
        }

        public IEnumerable<Student> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student entity)
        {
            appDBContent.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDBContent.SaveChangesAsync();

            return true;
        }

        public bool updateAll(List<Student> students)
        {
            foreach (var student in students)
            {
                if (student.Id != null && student.Id != Guid.Empty)
                {
                    var result = Update(student);
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
