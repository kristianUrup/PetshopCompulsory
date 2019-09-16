using Core.Entity;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();

        Pet GetPet(int id);
        Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner, double price);

        Pet Create(Pet pet);
        Pet Update(int id, Pet updatedPet);
        Pet Delete(int id);
        List<Pet> FiveCheapestPets();
        List<Pet> OrderByPrice();
        List<Pet> SearchForType(string type);
    }
}
