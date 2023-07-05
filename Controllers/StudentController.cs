using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebAPITask_1.Data;
using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Models;
using WebAPITask_1.Data.Repository;
using WebAPITask_1.ViewModels;

namespace WebAPITask_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IAllStudents _iallStudents;
        private readonly IStudentGroup _iallGroups;

        public StudentController(IAllStudents iallStudents, IStudentGroup iallGroups)
        {
            _iallStudents = iallStudents;
            _iallGroups = iallGroups;
        }
        [HttpGet(Name = "GetStudents")]
        [EnableCors("MyPolicy")]
        public IEnumerable<Student> Get()
        {
            StudentListViewModel model = new StudentListViewModel();
            model.allGroupStudent = _iallStudents.AllStudents;
            return model.allGroupStudent;
        }
        [HttpPost]
        public bool Create([FromBody] Student student)
        {
            if (student != null)
            {
                var result = _iallStudents.CreateStudent(student);
                return result;
            }
            else
            {
                return false;
            }
        }
        [HttpDelete]
        public bool Delete([FromBody] string id)
        { 
                var result = _iallStudents.Delete(id);
                return result;
        }
        [HttpPut]
        public bool Update([FromBody] List<Student> students)
        {
            var result = _iallStudents.updateAll(students);
            return result;
        }

    }
}
