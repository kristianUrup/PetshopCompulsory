using System;
using System.Collections.Generic;
using System.Text;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.Entity;
using System.Linq;

namespace PetshopCompulsory.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }
        public Owner Create(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public List<Owner> ReadAllOwners()
        {
            return _ownerRepo.ReadAllOwners().ToList();
        }

        public Owner ReadOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }


        public Owner Update(int id, Owner updatedOwner)
        {
            throw new NotImplementedException();
        }

        public Owner Delete(int id)
        {
            return _ownerRepo.Delete(id);
        }

        public List<Owner> SearchByName(string nameToSearch)
        {
            return _ownerRepo.searchByName(nameToSearch).ToList();
        }

    }
}
