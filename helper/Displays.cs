
using petStoreProject.Models;
using petStoreProject.Interfaces;

using petStoreProject.intefaces; // because it uses IShelterServices


namespace petStoreProject.helper
{
    public class petStoreDisplays
    {
        private IPetServices _petServices;
        private IShelterServices _shelterServices;
        private IUnitOfWork _unitOfWork;

        public petStoreDisplays(IPetServices petServices, IShelterServices shelterServices)
        {
            _petServices = petServices;
            _shelterServices = shelterServices;
        }
        public petStoreDisplays(IPetServices petServices, IShelterServices shelterServices, IUnitOfWork unitOfWork  )
        {
            _petServices = petServices;
            _shelterServices = shelterServices;
            _unitOfWork = unitOfWork;
        }
        public petStoreDisplays(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 
// Method to display general options the user can choose from to use the specialized methods for pets and shelters or exit
        public void generalDisplay()
        {
            Console.WriteLine("Welcome to the Pet Store Management System!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Show pets options:");
            Console.WriteLine("2. show shelters options:");
            Console.WriteLine("To exit the program, type 'Exit'.");
        } 
        // Method to display pet method options
        public void showPetsOptions()
        { string userInput="";
           
            while(userInput != "5")
            {
                 Console.WriteLine("Showing pets options:");
            Console.WriteLine("1. Add a new pet");
            Console.WriteLine("2. Update a pet's information");
            
            Console.WriteLine("3. Show all pets");
            Console.WriteLine("4. Find pets by species");
            Console.WriteLine("5. if you wanna go back to main menu type 5");
            userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        addpet();
                        break;
                    case "2":
                        updatePet();
                        break;
             
                    case "3":
                        showpets();
                        break;
                    case "4":
                        FindPetBySpecies();
                        break;
                        case "5":
                        generalDisplay();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
              
                userInput = Console.ReadLine();
            }
         
          
        }
        public void showShelterOptions()    
        {
            Console.WriteLine("Showing shelter options:");
            Console.WriteLine("1. Add a new shelter");
            Console.WriteLine("2. Update a shelter's information");
            Console.WriteLine("3. Show all shelters");
            Console.WriteLine("4. Find shelter by name");
            Console.WriteLine("5. if you wanna go back to main menu type 5");
            string userInput = "";
            while(userInput != "5")
            {
                switch(userInput)
                {
                    case "1":
                        addshelter();
                        break;
                    case "2":
                        updateShelter();
                        break;
             
                    case "3":
                        showshelters();
                        break;
                    case "4":
                        findShelterByName();
                        break;
                        case "5":
                        generalDisplay();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
                Console.WriteLine("Please select an option:");
                userInput = Console.ReadLine();
            }
        }
#region pet methods
        public void addpet()
        {
            Console.WriteLine("Enter the pet's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the pet's species:");
            string species = Console.ReadLine();
            Console.WriteLine("Enter the pet's age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the pet's health status:");
            string healthStatus = Console.ReadLine();
            Console.WriteLine("Enter the pet's personality:");
            string personality = Console.ReadLine();
            Pet newPet = new Pet
            {
                Id = _unitOfWork.GetRepository<Pet>().GetAll().Count + 1, // Simple ID generation
                Name = name,
                Species = species,
                Age = age,
                HealthStatus = healthStatus,
                Personality = personality
            };
            _unitOfWork.GetRepository<Pet>().Add(newPet);
            Console.WriteLine("New pet added successfully!"); 
            showPetsOptions();



        }
        public void updatePet()
            {
                Console.WriteLine("Enter the pet's ID to update:");
                int id =int.TryParse(Console.ReadLine(), out int petId) ? petId : -1;
                var pet = _petServices.GetPetById(id);
                if (pet != null)
                {
                    Console.WriteLine("Enter the pet's new name (leave blank to keep current):");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the pet's new species (leave blank to keep current):");
                    string species = Console.ReadLine();
                    Console.WriteLine("Enter the pet's new age (leave blank to keep current):");
                    string ageInput = Console.ReadLine();
                    Console.WriteLine("Enter the pet's new health status (leave blank to keep current):");
                    string healthStatus = Console.ReadLine();
                    Console.WriteLine("Enter the pet's new personality (leave blank to keep current):");
                    string personality = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name)) pet.Name = name;
                    if (!string.IsNullOrWhiteSpace(species)) pet.Species = species;
                    if (int.TryParse(ageInput, out int age)) pet.Age = age;
                    if (!string.IsNullOrWhiteSpace(healthStatus)) pet.HealthStatus = healthStatus;
                    if (!string.IsNullOrWhiteSpace(personality)) pet.Personality = personality;

                    _petServices.UpdatePet(pet);
                    Console.WriteLine("Pet updated successfully!");
                    showPetsOptions();
                }
                else
                {
                    Console.WriteLine("Pet not found. try again.");
                    updatePet();
                }
            }
            
    public void FindPetBySpecies()
{
    Console.WriteLine("Enter the species to search for:");
    string species = Console.ReadLine();
    var petsBySpecies = _unitOfWork.GetRepository<Pet>().Find(p => p.Species.Equals(species, StringComparison.OrdinalIgnoreCase)).ToList();
    if (petsBySpecies.Count > 0)
    {
        foreach (var pet in petsBySpecies)
        {
            Console.WriteLine($"Pet ID: {pet.Id}, Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}, Health Status: {pet.HealthStatus}, Personality: {pet.Personality}");
        }
        showPetsOptions();
    }
    else
    {
        Console.WriteLine("No pets found for the specified species.");
        Console.WriteLine("Would you like to try again? (yes/no)");
        string retryInput = Console.ReadLine(); 
        if (retryInput.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            FindPetBySpecies();
        }
        else
        {
            showPetsOptions();
        }
    }
}    
    public void showpets()
        {
            foreach (var pet in _petServices.GetAllPets())
            {
                Console.WriteLine($"Pet ID: {pet.Id}, Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}, Health Status: {pet.HealthStatus}, Personality: {pet.Personality}");
            }
            Console.WriteLine("To go back to the previous menu, type 'back'.");
            string userInput = Console.ReadLine();
            while(userInput != "back")
            {
                Console.WriteLine("Invalid input. Please try again.");
                userInput = Console.ReadLine();
            }
            if(userInput == "back")
            {
                showPetsOptions();
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                showpets();
            }
        }

#endregion
    
#region shelter methods

        public void showshelters()
        {
            foreach (var shelter in _shelterServices.GetAllShelters())
            {
                Console.WriteLine($"Shelter ID: {shelter.Id}, Name: {shelter.Name}, Location: {shelter.Location}, Capacity: {shelter.Capacity}");
            }


                Console.WriteLine("To go back to the previous menu, type 'back'.");
                string userInput = Console.ReadLine();
                while(userInput != "back")
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    userInput = Console.ReadLine();
                }
                if(userInput == "back")
                {
                    showShelterOptions();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    showshelters();
                }
                
        }
        public void addshelter()
        {
            Console.WriteLine("Enter the shelter's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the shelter's location:");
            string location = Console.ReadLine();
            Console.WriteLine("Enter the shelter's capacity:");
            int capacity = int.Parse(Console.ReadLine());
            Shelter newShelter = new Shelter
            {
                Id = _shelterServices.GetAllShelters().Count + 1, // Simple ID generation
                Name = name,
                Location = location,
                Capacity = capacity
            };
            _shelterServices.AddShelter(newShelter);
            Console.WriteLine("New shelter added successfully!"); 
            showShelterOptions();

        }
        public void updateShelter()
        {
            Console.WriteLine("Enter the shelter's ID to update:");
            int id = int.TryParse(Console.ReadLine(), out int shelterId) ? shelterId : -1;
            var shelter = _shelterServices.GetShelterById(id);
            if (shelter != null)
            {
                Console.WriteLine("Enter the shelter's new name (leave blank to keep current):");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the shelter's new location (leave blank to keep current):");
                string location = Console.ReadLine();
                Console.WriteLine("Enter the shelter's new capacity (leave blank to keep current):");
                string capacityInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name)) shelter.Name = name;
                if (!string.IsNullOrWhiteSpace(location)) shelter.Location = location;
                if (int.TryParse(capacityInput, out int capacity)) shelter.Capacity = capacity;

                _shelterServices.UpdateShelter(shelter);
                Console.WriteLine("Shelter updated successfully!");
                showShelterOptions();

            }
            else
            {
                Console.WriteLine("Shelter not found.");
                Console.WriteLine("Would you like to try again? (yes/no)");
                string retryInput = Console.ReadLine();
                if (retryInput.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    updateShelter();
                }
                else
                {
                    showShelterOptions();
                }

            }
        }
       public void findShelterByName()
        {
            Console.WriteLine("Enter the shelter name to search for:");
            string name = Console.ReadLine();
            var shelter = _shelterServices.GetShelterByName(name);
            if (shelter != null)
            {
                Console.WriteLine($"Shelter ID: {shelter.Id}, Name: {shelter.Name}, Location: {shelter.Location}, Capacity: {shelter.Capacity}");
          
                Console.WriteLine("To go back to the previous menu, type 'back'.");
                string userInput = Console.ReadLine();
                while(userInput != "back")
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    userInput = Console.ReadLine();
                }
                if(userInput == "back")
                {
                    showShelterOptions();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    findShelterByName();
                }

            }
            else
            {
                Console.WriteLine("No shelter found with the specified name.");
                Console.WriteLine("Would you like to try again? (yes/no)");
                string retryInput = Console.ReadLine(); 
                if (retryInput.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    findShelterByName();
                }
                else
                {
                    showShelterOptions();
                }   
            }
        }
        
#endregion
    }
}