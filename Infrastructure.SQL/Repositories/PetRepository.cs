using Core.Entity;
using PetshopCompulsory.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Petshop.Infrastructure.SQL;
using Microsoft.EntityFrameworkCore;

namespace Petshop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        PetShopContext _context;
        public PetRepository(PetShopContext petShopContext)
        {
            _context = petShopContext;
        }
        public Pet Create(Pet pet)
        {
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
            //var petToCreate = _context.Pets.Add(pet).Entity;
            //_context.SaveChanges();
            //return petToCreate;
        }
        public IEnumerable<Pet> ReadPets()
        {
            return _context.Pets.ToList();
        }
        public Pet ReadById(int id)
        {
            return _context.Pets.FirstOrDefault(pet => pet.Id == id);
        }

        public Pet Update(Pet petToUpdate, Pet petUpdated)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Pet> SearchPets(string petSearch)
        {
            return _context.Pets.Where(pet => pet.Type == petSearch).ToList();
        }

        

        public Pet Delete(int id)
        {
            var petToDelete = _context.Remove(new Pet { Id = id }).Entity;
            _context.SaveChanges();
            return petToDelete;
            //var petToDelete = _context.Pets.Remove(ReadById(id)).Entity;
            //_context.SaveChanges();
            //return petToDelete;
        }
    }
}
