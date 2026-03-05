

// now what to do with this file?
// i think iam going to add the seed data and use it accordingly seeding data done 
// what about the services  crud operations [^_^ done in the services folder]
// now the new problem lies in the pet owner system and the adoption process
// i think i will add a new class for the pet owner and then add the adoption process
// and link every onwer  and pet 
// i think i should add saving to excel sheet process to save the data and make it more persistent

using petStoreProject.Models;
using petStoreProject.Interfaces;
using petStoreProject.Services;
using petStoreProject;
using petStoreProject.helper;
SeedData data = new SeedData();
List<Pet> pets = data.GetPets();
List<Shelter> shelters = data.GetShelters();
IPetServices petServices = new PetService(pets);
IShelterServices shelterServices = new ShelterServices(shelters);
IUnitOfWork unitOfWork = new UnitOfWork();
petStoreDisplays displays = new petStoreDisplays(unitOfWork);
OwnerServices ownerServices = new OwnerServices(new List<Owner>(), petServices);


Console.WriteLine("Welcome to the Pet Store Management System!");
displays.generalDisplay();

string userInput = Console.ReadLine();
while (userInput.ToLower() != "exit")
{
    switch (userInput)
    {
        case "1":
           displays.showPetsOptions();
            break;
        case "2":
            // Code to add a new animal friend
           displays.showShelterOptions();
            break;
     
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
    Console.WriteLine("Enter your selection number (or type Exit to exit the program):");
    userInput = Console.ReadLine();
}


