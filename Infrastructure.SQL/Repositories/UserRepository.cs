using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.DomainService.Filtering;
using PetshopCompulsory.Core.Entity;

namespace Petshop.Infrastructure.SQL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private PetShopContext _ctx;

        public UserRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(User user)
        {
            _ctx.Users.Attach(user).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public User ReadById(int id)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        public FilteredList<User> ReadAllUsers(Filter filter)
        {
            var filteredList = new FilteredList<User>();
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                var items = _ctx.Users
                    .Include(u=>u.Owner)
                    .ThenInclude(o => o.Pets)
                    .ThenInclude(po => po.Pet)
                    .ThenInclude(p => p.Colors)
                    .ThenInclude(pc => pc.Color)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage)
                    .ToList();
                return new FilteredList<User>() { List = items, Count = _ctx.Users.Count() };
            }

            filteredList.List = _ctx.Users;
            filteredList.Count = _ctx.Users.Count();
            return filteredList;
        }

        public User Update(User userUpdated)
        {
            _ctx.Attach(userUpdated).State = EntityState.Modified;
            _ctx.Remove(_ctx.Users.Where(u => u.Id == userUpdated.Id));
            _ctx.Entry(userUpdated).Reference(u => u.Owner).IsModified = true;
            _ctx.SaveChanges();
            return userUpdated;
        }

        public void Delete(int id)
        {
            _ctx.Users.Remove(new User {Id = id}).State = EntityState.Deleted;
            _ctx.SaveChanges();
        }
    }
}
