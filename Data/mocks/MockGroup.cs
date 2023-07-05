using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data.mocks
{
    public class MockGroup : IStudentGroup
    {
        public IEnumerable<Group> AllGroups
        {
            get 
            {
                return new List<Group>{
                    new Group { Name = "1" }
                };
            }
        }

        public Group GetNoGroup => throw new NotImplementedException();

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Create(string name)
        {
            throw new NotImplementedException();
        }

        public bool Create(Group student)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Group Read(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool updateAll(List<Group> groups)
        {
            throw new NotImplementedException();
        }
    }
}
