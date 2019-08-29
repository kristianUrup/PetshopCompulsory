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

        Pet Create(Pet pet);
        Pet Update(Pet pet);
        Pet Delete(Pet pet);
    }
}
