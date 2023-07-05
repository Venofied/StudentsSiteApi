namespace WebAPITask_1.Data.Interfaces
{
    public interface IMainCRUD<T>
    {
        bool Create(string name);

        T Read(Guid entityId);

        IEnumerable<T> ReadAll();

        bool Update(T entity);

        bool Delete(string entity);
    }
}
