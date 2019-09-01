using Core.Entity;
using Infrastructure.Data;
using PetshopCompulsory.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {

        public Pet Create(Pet pet)
        {
            
            pet.Id = FakeDB.id++;
            FakeDB._pets.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            Pet petFound = ReadById(id);
            if(petFound != null)
            {
                FakeDB._pets.Remove(petFound);
            }
            return petFound;
        }

        public Pet ReadById(int id)
        {
            foreach (Pet pet in FakeDB._pets)
            {
                if(pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet pet)
        {
            throw new NotImplementedException();
        }



        public List<Pet> SearchPets(string petSearch)
        {
            throw new NotImplementedException();
        }

        public List<Pet> ReadPets()
        {
            return FakeDB._pets;
        }
    }
}
