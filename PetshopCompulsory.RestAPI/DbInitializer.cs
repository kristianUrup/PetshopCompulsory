using Core.Entity;
using Petshop.Infrastructure.SQL;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopCompulsory.RestAPI
{
    public class DbInitializer: IDbInitializer
    {
        
        public void SeedDb(PetShopContext ctx)
        {
            SeedOwners(ctx);
            SeedPets(ctx);
            ctx.SaveChanges();
        }

        private void SeedOwners(PetShopContext ctx)
        {
            var owner1 = ctx.Owners.Add(new Owner()
            {
                Firstname = "John",
                Lastname = "Travolta",
                Address = "BongoStreet",
                PhoneNumber = "42 42 42 42",
                Email = "bongomanden@gmail.com"
            });

            var owner2 = ctx.Owners.Add(new Owner()
            {
                Firstname = "Mikkel",
                Lastname = "Travolta",
                Address = "BongoStreet",
                PhoneNumber = "42 42 43 43",
                Email = "bongomanden@hotmail.com"
            });

            var owner3 = ctx.Owners.Add(new Owner()
            {
                Firstname = "Marius",
                Lastname = "Kleppert",
                Address = "wongostreet",
                PhoneNumber = "33 33 33 33",
                Email = "bondemanden@gmail.com"
            });
        }

        private void SeedPets(PetShopContext ctx)
        {
            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Mingo",
                Type = "Dog",
                Birthdate = Convert.ToDateTime("13 Juni 2013"),
                SoldDate = Convert.ToDateTime("15 juni 2013"),
                Color = "Red"
            });

            var pet2 = ctx.Pets.Add(new Pet()
            {
                Name = "Dingo",
                Type = "Cat",
                Birthdate = Convert.ToDateTime("01 Juni 2013"),
                SoldDate = Convert.ToDateTime("12 juni 2013"),
                Color = "Blue"
            });
        }
    }
}
