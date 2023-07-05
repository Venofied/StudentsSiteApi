using WebAPITask_1.Data.Models;

namespace WebAPITask_1.ViewModels
{
    public class StudentListViewModel
    {
        public IEnumerable<Student> allStudent { get; set; }
        public IEnumerable<GroupStudent> allGroupStudent { get; set; }

        public string currGroup { get; set; }
    }
}
