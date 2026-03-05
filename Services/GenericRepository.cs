using petStoreProject.Models;
using petStoreProject.Interfaces;
using System;
namespace petStoreProject.Services
{
public class GenericRepository<T> : IGenericService<T> where T : class, IEntity
    {
    private readonly List<T> _items;

    public GenericRepository()
        {
        _items = new List<T>(); // or load from a data source
        }
    public List<T> GetAll() => _items.ToList(); // return a copy to avoid external modification
    public T GetById(int id)
        {
        // Assuming T has an Id property, you would need to use reflection or a common interface
        // For simplicity, this is just a placeholder and would need to be implemented based on your actual model
        return _items.FirstOrDefault(item => 
            (int)item.GetType().GetProperty("Id")?.GetValue(item) == id);
        }
    public void Add(T item)
        {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
        }
    public void Update(T item)
        {
        if (item == null) throw new ArgumentNullException(nameof(item));
        var existing = GetById((int)item.GetType().GetProperty("Id")?.
GetValue(item));

        if (existing == null) throw new InvalidOperationException("Item not found");
        // Update properties - this is a simplified example and would need to be implemented based on your actual model
        foreach (var prop in typeof(T).GetProperties())
            {
            var value = prop.GetValue(item);
            prop.SetValue(existing, value);
            }
        }
    public void Delete(int id)
        {        var existing = GetById(id);
        if (existing == null) throw new InvalidOperationException("Item not found");
        _items.Remove(existing);
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            
        return _items.Where(predicate).ToList();
        }         
    }
}