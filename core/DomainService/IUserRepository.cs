using System;
using System.Collections.Generic;
using System.Text;
using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;

namespace PetshopCompulsory.Core.DomainService
{
    public interface IUserRepository
    {
        void Create(User user);
        User ReadById(int id);
        FilteredList<User> ReadAllUsers(Filter filter);
        User Update(User userUpdated);
        void Delete(int id);
    }
}
