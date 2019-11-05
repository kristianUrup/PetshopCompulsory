using PetshopCompulsory.Core.Entity;
using PetshopCompulsory.Core.DomainService.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.ApplicationService
{
    public interface IPetService
    {
        FilteredList<Pet> GetPets(Filter filter);

        Pet GetPet(int id);
        Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, List<PetColor> colors, List<PetOwner> owners, double price);

        Pet Create(Pet pet);
        Pet Update(int id, Pet updatedPet);
        Pet Delete(int id);
        List<Pet> FiveCheapestPets(int amount);
        FilteredList<Pet> OrderByPrice(Filter filter);
        List<Pet> SearchForType(string type);
    }
}
