using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();

        Pet GetPet(int id);
        Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price);

        Pet Create(Pet pet);
        Pet Update(Pet updatePet, Pet updatedPet);
        Pet Delete(int id);
        List<Pet> FiveCheapestPets();
        List<Pet> OrderByPrice();
    }
}
