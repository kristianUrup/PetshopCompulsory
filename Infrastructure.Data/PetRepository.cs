using Core.Entity;
using Infrastructure.Data;
using PetshopCompulsory.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Petshop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {

        public Pet Create(Pet pet)
        {
            List<Pet> pets = FakeDB._pets.ToList();
            pet.Id = FakeDB.id++;
            pets.Add(pet);
            FakeDB._pets = pets;
            return pet;
        }

        public Pet Delete(int id)
        {
            List<Pet> pets = FakeDB._pets.ToList();
            Pet petFound = ReadById(id);
            if(petFound != null)
            {
                pets.Remove(petFound);
            }
            FakeDB._pets = pets;
            return petFound;
        }

        public Pet ReadById(int id)
        {
            
            foreach (Pet pet in FakeDB._pets.ToList())
            {
                if(pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet petToUpdate, Pet petUpdated)
        {
            List<Pet> pets = FakeDB._pets.ToList();
            foreach(Pet pet in pets)
            {
                if(pet.Id == petToUpdate.Id)
                {
                    pet.Name = petUpdated.Name;
                    pet.Price = petUpdated.Price;
                    pet.PreviousOwner = petUpdated.PreviousOwner;
                }
            }
            FakeDB._pets = pets;
            return petUpdated;
        }



        public IEnumerable<Pet> SearchPets(string petSearch)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB._pets;
        }
    }
}
