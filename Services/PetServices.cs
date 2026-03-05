
using petStoreProject.Interfaces;
using petStoreProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace petStoreProject.Services;

public class PetService : IPetServices
{
    private readonly List<Pet> _pets;

    public PetService()
    {
        _pets = new List<Pet>(); // or load from a data source
    }

    // Optional: allow initial seeding
    public PetService(IEnumerable<Pet> initialPets)
    {
        _pets = new List<Pet>(initialPets);
    }

    public List<Pet> GetAllPets() => _pets.ToList(); // return a copy to avoid external modification

    public Pet GetPetById(int id) => _pets.FirstOrDefault(p => p.Id == id);

    public List<Pet> GetPetsBySpecies(string species)
    {
        if (string.IsNullOrWhiteSpace(species))
            return new List<Pet>();

        return _pets.Where(p => 
            p.Species?.Trim().Equals(species.Trim(), StringComparison.OrdinalIgnoreCase) == true
        ).ToList();
    }

    public void AddPet(Pet pet)
    {
        if (pet == null) throw new ArgumentNullException(nameof(pet));
        // Optionally validate Id uniqueness
        _pets.Add(pet);
    }

    public bool UpdatePet(Pet updatedPet)
    {
        if (updatedPet == null) throw new ArgumentNullException(nameof(updatedPet));

        var existing = GetPetById(updatedPet.Id);
        if (existing == null) return false;

        existing.Name = updatedPet.Name;
        existing.Species = updatedPet.Species;
        existing.Age = updatedPet.Age;
        existing.HealthStatus = updatedPet.HealthStatus;
        existing.Personality = updatedPet.Personality;
        return true;
    }

    public bool DeletePet(int id)
    {
        var pet = GetPetById(id);
        if (pet == null) return false;
        return _pets.Remove(pet);
    }
}

// Separate export service
