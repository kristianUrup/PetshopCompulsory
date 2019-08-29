using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using PetshopCompulsory.Core.DomainService;

namespace PetshopCompulsory.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        IPetRepository _petRepo;
        List<Pet> _pets;

        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
            _pets = petRepo.GetPets();
        }

        public Pet Create(Pet pet)
        {
            throw new NotImplementedException();
        }


        public Pet GetPet(int id)
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

        public List<Pet> GetPets()
        {
            return _pets;
        }

        public void Delete(Pet pet)
        {
            foreach (Pet _pet in _pets)
            {
                if(_pet.Id == pet.Id)
                {
                    _pets.Remove(pet);
                }
            }
        }

    }
}
