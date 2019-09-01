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

        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }

        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return pet;
        }

        public Pet Create(Pet pet)
        {
            return _petRepo.Create(pet);
        }


        public Pet GetPet(int id)
        {
            foreach (Pet pet in _petRepo.ReadPets())
            {
                if(pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet petUpdate)
        {
            var pet = GetPet(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Price = petUpdate.Price;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            return pet;
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets();
        }

        public Pet Delete(int id)
        {
           return _petRepo.Delete(id);
        }

        
    }
}
