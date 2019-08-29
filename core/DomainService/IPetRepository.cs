using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.DomainService
{
    public interface IPetRepository
    {
        List<Pet> GetPets();

        Pet Create(Pet pet);

        Pet ReadById(int id);

        Pet Update(Pet pet);

        Pet Delete(int id);

        List<Pet> SearchPets(string petSearch);
    }
}
