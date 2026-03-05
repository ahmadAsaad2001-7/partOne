

using petStoreProject.Models;
namespace petStoreProject.Interfaces
{
public interface IShelterServices
{
    List<Shelter> GetAllShelters();
    Shelter GetShelterById(int id);
    Shelter GetShelterByName(string name);
    void AddShelter(Shelter shelter);
    void UpdateShelter(Shelter shelter);
    void DeleteShelter(int id);
}
}