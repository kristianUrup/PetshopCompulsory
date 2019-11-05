using PetshopCompulsory.Core.Entity;
using PetshopCompulsory.Core.DomainService.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.DomainService
{
    public interface IPetRepository
    {
        FilteredList<Pet> ReadPets(Filter filter);

        Pet Create(Pet pet);

        Pet ReadById(int id);

        Pet Update(Pet petToUpdate);

        Pet Delete(int id);

        IEnumerable<Pet> SearchPets(string petSearch);
        IEnumerable<Pet> FiveCheapestPets(int amount);
    }
}
