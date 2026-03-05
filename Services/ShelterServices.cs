using petStoreProject.Models;
using petStoreProject.Interfaces;
namespace petStoreProject.Services
{
public class ShelterServices : IShelterServices
{
    private List<Shelter> _shelters;
    public ShelterServices(List<Shelter> shelters)
    {
        _shelters = shelters;
    }
    public List<Shelter> GetAllShelters()
    {
        return _shelters;
    }
    public Shelter GetShelterById(int id)
    {
        return _shelters.FirstOrDefault(s => s.Id == id);
    }
    public Shelter GetShelterByName(string name)
    {
        return _shelters.FirstOrDefault(s => s.Name.ToLower().Trim().Equals(name.ToLower().Trim(), StringComparison.OrdinalIgnoreCase));
    }
    public void AddShelter(Shelter shelter)
    {
        _shelters.Add(shelter);
    }
    public void UpdateShelter(Shelter shelter)
    {
        var existingShelter = GetShelterById(shelter.Id);
        if (existingShelter != null)
        {
            existingShelter.Name = shelter.Name;
            existingShelter.Location = shelter.Location;
            existingShelter.Capacity = shelter.Capacity;
            existingShelter.Pets = shelter.Pets;
        }
    }
    public void DeleteShelter(int id)
    {
        var shelter = GetShelterById(id);
        if (shelter != null)
        {
            _shelters.Remove(shelter);
        }
    }
}
}