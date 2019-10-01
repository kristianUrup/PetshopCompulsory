using Core.Entity;
using Petshop.Infrastructure.SQL;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetshopCompulsory.RestAPI
{
    public class DbInitializer : IDbInitializer
    {

        public void SeedDb(PetShopContext ctx)
        {
            SeedOwners(ctx);
            ctx.SaveChanges();
        }

        private void SeedOwners(PetShopContext ctx)
        {
            var owner1 = new Owner()
            {
                Firstname = "John",
                Lastname = "Travolta",
                Address = "BongoStreet",
                PhoneNumber = "42 42 42 42",
                Email = "bongomanden@gmail.com",
                Pets = new List<PetOwner>()
            };

            var owner2 = new Owner()
            {
                Firstname = "Mikkel",
                Lastname = "Travolta",
                Address = "BongoStreet",
                PhoneNumber = "42 42 43 43",
                Email = "bongomanden@hotmail.com",
                Pets = new List<PetOwner>()
            };

            var owner3 = new Owner()
            {
                Firstname = "Marius",
                Lastname = "Kleppert",
                Address = "wongostreet",
                PhoneNumber = "33 33 33 33",
                Email = "bondemanden@gmail.com",
                Pets = new List<PetOwner>()

            };
            owner1 = ctx.Owners.Add(owner1).Entity;
            owner2 = ctx.Owners.Add(owner2).Entity;
            owner3 = ctx.Owners.Add(owner3).Entity;

            var pet1 = new Pet()
            {
                Name = "Mingo",
                Type = "Dog",
                Price = 500.0,
                Birthdate = Convert.ToDateTime("13 Juni 2013"),
                SoldDate = Convert.ToDateTime("15 juni 2013"),
                Colors = new List<PetColor>(),
                Owners = new List<PetOwner>()
            };

            var pet2 = new Pet()
            {
                Name = "Dingo",
                Type = "Cat",
                Price = 50.0,
                Birthdate = Convert.ToDateTime("01 Juni 2013"),
                SoldDate = Convert.ToDateTime("12 juni 2013"),
                Colors = new List<PetColor>(),
                Owners = new List<PetOwner>()
            };

            var pet3 = new Pet()
            {
                Name = "Suko",
                Type = "Goat",
                Price = 5.0,
                Birthdate = Convert.ToDateTime("01 Juni 2013"),
                SoldDate = Convert.ToDateTime("12 August 2013"),
                Colors = new List<PetColor>(),
                Owners = new List<PetOwner>()

            };

            
            PetOwner petOwner1 = new PetOwner
            {
                Owner = owner1
            };
            PetOwner petOwner2 = new PetOwner
            {
                Owner = owner2
            };
            PetOwner petOwner3 = new PetOwner
            {
                Owner = owner3
            };

            pet1.Owners.Add(petOwner1);
            pet2.Owners.Add(petOwner2);
            pet3.Owners.Add(petOwner3);

            ctx.Pets.AddRange(pet1, pet2, pet3);

        }
    }
}
