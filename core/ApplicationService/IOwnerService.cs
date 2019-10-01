using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);
        FilteredList<Owner> ReadAllOwners(Filter filter);
        Owner ReadOwnerById(int id);
        Owner Update(int id,Owner updatedOwner);
        Owner Delete(int id);
        List<Owner> SearchByName(string nameToSearch);
    }
}
