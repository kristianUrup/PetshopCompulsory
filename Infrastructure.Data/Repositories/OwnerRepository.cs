using System;
using System.Collections.Generic;
using System.Text;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.Entity;
using System.Linq;
using Petshop.Infrastructure.SQL;

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

        public Owner Update(Owner ownerToUpdate, Owner updatedOwner)
        {
            throw new NotImplementedException();
        }
        public Owner Delete(int id)
        {
            var ownerToDelete =_context.Remove(new Owner { Id = id }).Entity;
            _context.SaveChanges();
            return ownerToDelete;
        }

        public IEnumerable<Owner> searchByName(string searchByName)
        {
            return _context.Owners.Where(owner => (owner.Firstname + "" + owner.Lastname) == searchByName).ToList();
        }

        public List<Owner> IOwnerRepository.searchByName(string searchByName)
        {
            throw new NotImplementedException();
        }
    }
}
