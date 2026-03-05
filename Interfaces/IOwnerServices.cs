using petStoreProject.Models;

namespace petStoreProject.intefaces
{
    public interface IOwnerServices
    {
        void AddOwner(Owner owner);
        Owner GetOwnerById(int id);
        List<Owner> GetAllOwners();
        void UpdateOwner(Owner owner);
        void DeleteOwner(int id);
        List<Pet> GetPetsByOwnerId(int ownerId);
    }
}