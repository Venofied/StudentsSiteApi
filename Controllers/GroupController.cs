using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Models;
using WebAPITask_1.Data.Repository;
using WebAPITask_1.ViewModels;
namespace WebAPITask_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IAllStudents _iallStudents;
        private readonly IStudentGroup _iallGroups;
        public GroupController(IAllStudents iallStudents, IStudentGroup iallGroups)
        {
            _iallStudents = iallStudents;
            _iallGroups = iallGroups;
        }
        [HttpGet(Name = "GetGroup")]
        //[EnableCors("MyPolicy")]
        public IEnumerable<Group> Get()
        {
            GroupListViewModel model = new GroupListViewModel();
            model.allGroup = _iallGroups.AllGroups;
            return model.allGroup;
        }
        [HttpPost]
        public bool Create([FromBody] Group groupName)
        {
            var result = _iallGroups.Create(groupName);
            return result;
        }

        [HttpDelete]
        public bool Delete([FromBody] string id)
        {
            var result = _iallGroups.Delete(id);
            return result;
        }
        [HttpPut]
        public bool updateAll([FromBody] List<Group> groups)
        {
            var result = _iallGroups.updateAll(groups);
            return result;
        }
    }
}
