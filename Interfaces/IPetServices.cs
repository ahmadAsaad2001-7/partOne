using petStoreProject.Models;
namespace petStoreProject.Interfaces{

public interface IPetServices
{
    List<Pet> GetAllPets();
    List<Pet> GetPetsBySpecies(string species);
    Pet GetPetById(int id);
    void  AddPet(Pet pet);
    bool UpdatePet(Pet pet);
    bool DeletePet(int id);
    
}
}