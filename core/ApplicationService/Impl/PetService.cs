using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using PetshopCompulsory.Core.DomainService;
using System.Linq;
using System.IO;
using PetshopCompulsory.Core.Entity;

namespace PetshopCompulsory.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        IPetRepository _petRepo;

        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }

        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, List<PetOwner> owners, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                Owners = owners,
                Price = price
            };
            return pet;
        }

        public Pet Create(Pet pet)
        {
            if(string.IsNullOrEmpty(pet.Name))
            {
                throw new InvalidDataException("Pet Needs a Name");
            }
            return _petRepo.Create(pet);
        }


        public Pet GetPet(int id)
        {
            return _petRepo.ReadById(id);
        }

        public Pet Update(int id, Pet updatedPet)
        {
            if(id != updatedPet.Id)
            {
                throw new InvalidDataException("The id is not right");
            }
            else
            {
                Pet updatePet = GetPet(id);
                return _petRepo.Update(updatePet);
            }

        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public Pet Delete(int id)
        {
           return _petRepo.Delete(id);
        }

        public List<Pet> FiveCheapestPets(int amount)
        {
            return _petRepo.FiveCheapestPets(amount).ToList();
        }

        public List<Pet> OrderByPrice()
        {
            IEnumerable<Pet> pets = _petRepo.ReadPets().OrderBy(pet => pet.Price);
            return pets.ToList();
        }

        public List<Pet> SearchForType(string type)
        {
            string theType = type.ToLower();
            List<Pet> searchedPets = new List<Pet>();
            foreach (var pet in _petRepo.ReadPets().ToList())
            {
                if (pet.Type.ToLower().Equals(theType))
                {
                    searchedPets.Add(pet);
                }
            }
            return searchedPets;
        }
    }
}
