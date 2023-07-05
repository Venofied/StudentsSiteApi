using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data.mocks
{
    public class MockMainCRUD : IMainCRUD<Main>
    {
        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Create(string name)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Main Read(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Main> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Main entity)
        {
            throw new NotImplementedException();
        }
    }
}
