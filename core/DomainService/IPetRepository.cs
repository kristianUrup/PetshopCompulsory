using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        Pet Create(Pet pet);

        Pet ReadById(int id);

        Pet Update(Pet petToUpdate);

        Pet Delete(int id);

        IEnumerable<Pet> SearchPets(string petSearch);
        IEnumerable<Pet> FiveCheapestPets(int amount);
    }
}
