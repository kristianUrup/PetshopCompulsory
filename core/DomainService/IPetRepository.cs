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

        Pet Update(Pet petToUpdate, Pet updatedPet);

        Pet Delete(int id);

        IEnumerable<Pet> SearchPets(string petSearch);
    }
}
