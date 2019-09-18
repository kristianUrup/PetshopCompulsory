using Microsoft.EntityFrameworkCore;
using Petshop.Infrastructure.SQL;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petshop.Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        PetShopContext _context;
        public OwnerRepository(PetShopContext petShopContext)
        {
            _context = petShopContext;
        }
        public Owner Create(Owner owner)
        {
            _context.Owners.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _context.Owners.ToList();
        }

        public Owner ReadById(int id)
        {
            return _context.Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public Owner Update(Owner ownerToUpdate)
        {
            var ownerFromDB = ReadById(ownerToUpdate.Id);
            if (ownerFromDB == null) return null;

            ownerFromDB.Firstname = ownerToUpdate.Firstname;
            ownerFromDB.Lastname = ownerToUpdate.Lastname;
            ownerFromDB.PhoneNumber = ownerToUpdate.PhoneNumber;
            ownerFromDB.Address = ownerToUpdate.Address;
            ownerFromDB.Email = ownerToUpdate.Email;
            return ownerFromDB;
        }
        public Owner Delete(int id)
        {
            var ownerToDelete = _context.Remove(new Owner { Id = id }).Entity;
            _context.SaveChanges();
            return ownerToDelete;
        }

        public IEnumerable<Owner> searchByName(string searchByName)
        {
            return _context.Owners.Where(owner => (owner.Firstname + "" + owner.Lastname) == searchByName).ToList();
        }
    }
}
