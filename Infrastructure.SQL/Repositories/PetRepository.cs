using PetshopCompulsory.Core.Entity;
using PetshopCompulsory.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Petshop.Infrastructure.SQL;
using Microsoft.EntityFrameworkCore;
using PetshopCompulsory.Core.DomainService.Filtering;

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
        public FilteredList<Pet> ReadPets(Filter filter)
        {
            var filteredList = new FilteredList<Pet>();
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                var items = _context.Pets
                    .Include(p => p.Owners)
                    .ThenInclude(po => po.Owner)
                    .Include(p => p.Colors)
                    .ThenInclude(pc => pc.Color)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage)
                    .ToList();

                return new FilteredList<Pet>() {List = items, Count = _context.Pets.Count()};
            }
            filteredList.List = _context.Pets;
            filteredList.Count = _context.Pets.Count();
            return filteredList;
        }
        public Pet ReadById(int id)
        {
            return _context.Pets
                .Include(p => p.Owners)
                .ThenInclude(po => po.Owner)
                .Include(p => p.Colors)
                .ThenInclude(pc => pc.Color)
                .FirstOrDefault(pet => pet.Id == id);
        }

        public Pet Update(Pet petToUpdate)
        {
            var petFromDB = ReadById(petToUpdate.Id);
            if (petFromDB == null) return null;

            petFromDB.Name = petToUpdate.Name;
            petFromDB.Price = petToUpdate.Price;
            petFromDB.Owners = petFromDB.Owners;
            return petFromDB;
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

        public IEnumerable<Pet> FiveCheapestPets(int amount)
        {
            IEnumerable<Pet> orderedList = _context.Pets.OrderBy(p => p.Price).Take(amount);
            return orderedList;
        }
    }
}
