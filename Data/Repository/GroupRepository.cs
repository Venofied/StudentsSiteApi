using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data.Repository
{
    public class GroupRepository : IStudentGroup
    {
        private readonly AppDBContent appDBContent;

        public GroupRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Group> AllGroups => appDBContent.Group;

        public Group GetNoGroup => appDBContent.Group.Select(c => c).Where(c => c.Name == Constants.NOGROUP).FirstOrDefault();

        public bool Create(Group group)
        {
            if ((group != null) && group.Id != Guid.Empty)
            {
                appDBContent.Entry(group).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                appDBContent.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Create(string name)
        {
            if ((name != null) && name != String.Empty)
            {
                Group group = new Group();
                group.Id = Guid.NewGuid();
                group.Name = name;
                appDBContent.Entry(group).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                appDBContent.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            var check = Helper.checkIdGroup(id);
            if (!check.checkResult)
            {
                return false;
            }
            else
            {
                var group = appDBContent.Group.FirstOrDefault(c => c.Id == check.parseGuid);
                appDBContent.Entry(group).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                appDBContent.SaveChanges();

                return true;
            }
        }

        public Group Read(Guid groupId)
        {
            var group = appDBContent.Group.FirstOrDefault(c => c.Id == groupId);
            return group;
        }

        public IEnumerable<Group> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Group entity)
        {
            appDBContent.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDBContent.SaveChanges();

            return true;
        }

        public bool updateAll(List<Group> groups)
        {
           foreach(var group in groups)
            {                
                if(group.Id != null && group.Id != Guid.Empty)
                {
                    var result = Update(group);
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
