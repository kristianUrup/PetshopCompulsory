using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner ReadById(int id);
        FilteredList<Owner> ReadAllOwners(Filter filter);
        Owner Update(Owner ownerToUpdate);
        Owner Delete(int id);
        IEnumerable<Owner> searchByName(string searchByName);
    }
}
