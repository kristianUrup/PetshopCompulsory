using Core.Entity;
using Petshop.Infrastructure.SQL;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //Initializing owners
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

            //Initializing petOwner
            var petOwner1 = new PetOwner()
            {
                Owner = owner1
            };

            var petOwner2 = new PetOwner()
            {
                Owner = owner2
            };

            var petOwner3 = new PetOwner()
            {
                Owner = owner3
            };

            //Initializing pets
            var pet1 = new Pet()
            {
                Name = "Mingo",
                Type = "Dog",
                Price = 500.0,
                Birthdate = Convert.ToDateTime("13 Juni 2013"),
                SoldDate = Convert.ToDateTime("15 juni 2013"),
                Color = "Red",
                Owners = new List<PetOwner>()
            };

            var pet2 = new Pet()
            {
                Name = "Dingo",
                Type = "Cat",
                Price = 50.0,
                Birthdate = Convert.ToDateTime("01 Juni 2013"),
                SoldDate = Convert.ToDateTime("12 juni 2013"),
                Color = "Blue",
                Owners = new List<PetOwner>()
            };

            var pet3 = new Pet()
            {
                Name = "Suko",
                Type = "Goat",
                Price = 5.0,
                Birthdate = Convert.ToDateTime("01 Juni 2013"),
                SoldDate = Convert.ToDateTime("12 August 2013"),
                Color = "Yellow",
                Owners = new List<PetOwner>()
            };


            pet1.Owners.Add(petOwner1);
            pet2.Owners.Add(petOwner2);
            pet3.Owners.Add(petOwner3);

            pet1 = ctx.Pets.Add(pet1).Entity;
            pet2 = ctx.Pets.Add(pet2).Entity;
            pet3 = ctx.Pets.Add(pet3).Entity;

        }
    }
}
