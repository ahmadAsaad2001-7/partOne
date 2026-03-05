
using petStoreProject.Models;
using petStoreProject.Interfaces;
namespace petStoreProject.Interfaces
{
  public interface IUnitOfWork : IDisposable
{
   IGenericService<T> GetRepository<T>() where T : class, IEntity;


    void SaveChanges();
}



}