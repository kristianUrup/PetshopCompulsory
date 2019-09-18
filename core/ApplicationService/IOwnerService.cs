using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);
        List<Owner> ReadAllOwners();
        Owner ReadOwnerById(int id);
        Owner Update(int id,Owner updatedOwner);
        Owner Delete(int id);
        List<Owner> SearchByName(string nameToSearch);
    }
}
