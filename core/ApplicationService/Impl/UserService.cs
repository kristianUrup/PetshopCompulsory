using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;

namespace PetshopCompulsory.Core.ApplicationService.Impl
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public void Create(User user)
        {
            _userRepo.Create(user);
        }

        public User ReadById(int id)
        {
            return _userRepo.ReadById(id);
        }

        public FilteredList<User> ReadAllUsers(Filter filter)
        {
            return _userRepo.ReadAllUsers(filter);
        }

        public User Update(User userUpdated)
        {
            try
            {
                return _userRepo.Update(userUpdated);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The id in query and the id in body is not the same");
            }
        }

        public void Delete(int id)
        {
            _userRepo.Delete(id);
        }
    }
}
