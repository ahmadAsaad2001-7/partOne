using petStoreProject.Models;
namespace petStoreProject.Interfaces
{
    public interface IGenericService<T> where T : class ,IEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);   

    }
}