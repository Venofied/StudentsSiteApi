using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data.Interfaces
{
    public interface IStudentGroup : IMainCRUD<Group>
    {
        IEnumerable<Group> AllGroups { get; }

        Group GetNoGroup { get; }

        bool Create(Group student);

        bool updateAll(List<Group> groups);

    }
}
