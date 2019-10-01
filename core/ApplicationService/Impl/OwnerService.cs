using System;
using System.Collections.Generic;
using System.Text;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.Entity;
using System.Linq;
using System.IO;
using PetshopCompulsory.Core.DomainService.Filtering;

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

        public FilteredList<Owner> ReadAllOwners(Filter filter)
        {
            FilteredList<Owner> owners = _ownerRepo.ReadAllOwners(filter);
            if (owners == null)
            {
                throw new InvalidDataException("There is no pets");
            }
            else
            {
                return owners;
            }

        }

        public Owner ReadOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }


        public Owner Update(int id, Owner updatedOwner)
        {
            if (id != updatedOwner.Id)
            {
                throw new InvalidDataException("The id is not right");
            }
            else
            {
                Owner updateOwner = ReadOwnerById(id);
                return _ownerRepo.Update(updateOwner);
            }
        }

        public Owner Delete(int id)
        {
            var ownerToDelete = ReadOwnerById(id);
            if(ownerToDelete == null)
            {
                throw new InvalidDataException("The id is not right");
            }
            else
            {
                _ownerRepo.Delete(ownerToDelete.Id);
                return ownerToDelete;
            }
        }

        public List<Owner> SearchByName(string nameToSearch)
        {
            List<Owner> searchedByOwners = _ownerRepo.searchByName(nameToSearch).ToList();
            if(searchedByOwners == null)
            {
                throw new InvalidDataException("There is no owners by this name");
            }
            else
            {
                return searchedByOwners;
            }
        }

    }
}
