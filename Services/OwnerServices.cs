using petStoreProject.Models;
using petStoreProject.Interfaces;
using petStoreProject.intefaces; // because it uses IShelterServices
namespace petStoreProject 
{
    public class OwnerServices : IOwnerServices
    {
        private List<Owner> _owners;
        private IPetServices _petServices;

        public OwnerServices(List<Owner> owners, IPetServices petServices)
        {
            _owners = owners;
            _petServices = petServices;
        }

        public void AddOwner(Owner owner)
        {
            owner.Id = _owners.Count + 1; // Simple ID generation
            _owners.Add(owner);
        }

        public Owner GetOwnerById(int id)
        {
            return _owners.FirstOrDefault(o => o.Id == id);
        }

        public List<Owner> GetAllOwners()
        {
            return _owners;
        }

        public void UpdateOwner(Owner owner)
        {
            var existingOwner = GetOwnerById(owner.Id);
            if (existingOwner != null)
            {
                existingOwner.Name = owner.Name;
                existingOwner.ContactInfo = owner.ContactInfo;
                // Update pets if needed
            }
        }

        public void DeleteOwner(int id)
        {
            var owner = GetOwnerById(id);
            if (owner != null)
            {
                _owners.Remove(owner);
            }
        }

        public List<Pet> GetPetsByOwnerId(int ownerId)
        {
            var owner = GetOwnerById(ownerId);
            return owner?.Pets ?? new List<Pet>();
        }
    }
}