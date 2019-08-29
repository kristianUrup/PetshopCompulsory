using Core.Entity;
using PetshopCompulsory.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            Pet petFound = ReadById(id);
            if(petFound != null)
            {
                _pets.Remove(petFound);
            }
            return null;
        }

        public Pet ReadById(int id)
        {
            foreach (Pet pet in _pets)
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

        public List<Pet> GetPets()
        {
            return _pets;
        }
    }
}
