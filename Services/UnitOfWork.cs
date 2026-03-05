using petStoreProject.Interfaces;
using petStoreProject.Models;
using petStoreProject.Services;


public class UnitOfWork : IUnitOfWork
{


   private readonly Dictionary<Type, object> _repositories = new();

        // You can add specific repositories as properties for convenience
     
    
        public IGenericService<T> GetRepository<T>() where T : class, IEntity
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericService<T>)_repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>();
            _repositories.Add(typeof(T), repository);
            return repository;
        }
        public void SaveChanges()
            {
                // For in-memory storage, nothing to save.
                // In Entity Framework, you'd call _context.SaveChanges()
                Console.WriteLine("Changes saved (in-memory)");
            }


    public void Dispose()
    {
        _repositories.Clear();
    }
}