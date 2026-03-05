using petStoreProject.Models;

namespace petStoreProject
{
    public class SeedData
    {
        public List<Pet> Pets { get; set; }
        public List<Shelter> Shelters { get; set; }

        public SeedData()
        {
            Pets = new List<Pet>
            {
                new Pet { Id = 1, Name = "Buddy", Species = "Dog", Age = 3, HealthStatus = "Healthy", Personality = "Friendly" },
                new Pet { Id = 2, Name = "Whiskers", Species = "Cat", Age = 2, HealthStatus = "Healthy", Personality = "Curious" },
                new Pet { Id = 3, Name = "Charlie", Species = "Dog", Age = 5, HealthStatus = "Healthy", Personality = "Playful" }
            };

            Shelters = new List<Shelter>
            {
                new Shelter { Id = 1, Name = "Happy Tails Shelter", Location = "123 Main St", Capacity = 50, Pets = Pets.ToArray() },
                new Shelter { Id = 2, Name = "Paws and Claws Shelter", Location = "456 Elm St", Capacity = 30, Pets = Pets.ToArray() },
                new Shelter { Id = 3, Name = "Furry Friends Shelter", Location = "789 Oak St", Capacity = 40, Pets = Pets.ToArray() }
            };
        }

        // Optional: if you still want explicit methods to return the lists
        public List<Pet> GetPets() => Pets;
        public List<Shelter> GetShelters() => Shelters;
    }
}