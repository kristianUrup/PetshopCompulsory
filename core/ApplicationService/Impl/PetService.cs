using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using PetshopCompulsory.Core.DomainService;
using System.Linq;

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
            return _petRepo.ReadById(id);
        }

        public Pet Update(Pet updatePet, Pet updatedPet)
        {
            return _petRepo.Update(updatePet, updatedPet);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public Pet Delete(int id)
        {
           return _petRepo.Delete(id);
        }

        public List<Pet> FiveCheapestPets( )
        {
            List<Pet> sortedList = new List<Pet>();
            IEnumerable<Pet> pets = _petRepo.ReadPets().OrderBy(pet => pet.Price);
            List<Pet> petsordered = pets.ToList();
            foreach (var pet in petsordered)
            {
                if(sortedList.Count == 5)
                {
                    break;
                }
                else
                {
                    sortedList.Add(pet);
                }
            }
            return sortedList;
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
