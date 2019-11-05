using PetshopCompulsory.Core.Entity;
using Petshop.Infrastructure.SQL;
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

            Owner owner1 = new Owner()
            {
                Firstname = "John",
                Lastname = "Travolta",
                Address = "BongoStreet",
                PhoneNumber = "42 42 42 42",
                Email = "bongomanden@gmail.com",
                Pets = new List<PetOwner>()
            };

            Owner owner2 = new Owner()
            {
                Firstname = "Mikkel",
                Lastname = "Travolta",
                Address = "BongoStreet",
                PhoneNumber = "42 42 43 43",
                Email = "bongomanden@hotmail.com",
                Pets = new List<PetOwner>()
            };

            Owner owner3 = new Owner()
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
            
            Color color1 = new Color
            {
                ColorName = "Red"
            };
            Color color2 = new Color
            {
                ColorName = "Blue"
            };
            Color color3 = new Color
            {
                ColorName = "Brown"
            };
            Color color4 = new Color
            {
                ColorName = "White"
            };
            Color color5 = new Color
            {
                ColorName = "Black"
            };
            Color color6 = new Color
            {
                ColorName = "Yellow"
            };
            color1 = ctx.Colors.Add(color1).Entity;
            color2 = ctx.Colors.Add(color2).Entity;
            color3 = ctx.Colors.Add(color3).Entity;
            color4 = ctx.Colors.Add(color4).Entity;
            color5 = ctx.Colors.Add(color5).Entity;
            color6 = ctx.Colors.Add(color6).Entity;

            PetColor petColor1 = new PetColor
            {
                Color = color1
            };
            PetColor petColor2 = new PetColor
            {
                Color = color2
            };
            PetColor petColor3 = new PetColor
            {
                Color = color3
            };
            PetColor petColor4 = new PetColor
            {
                Color = color4
            };
            PetColor petColor5 = new PetColor
            {
                Color = color5
            };
            PetColor petColor6 = new PetColor
            {
                Color = color6
            };
            string password = "1234";
            byte[] passwordHashUser1, passwordSaltUser1, passwordHashUser2, passwordSaltUser2;

            CreatePasswordHash(password, out passwordHashUser1, out passwordSaltUser1);
            CreatePasswordHash(password, out passwordHashUser2, out passwordSaltUser2);

            User user1 = new User
            {
                PasswordHash = passwordHashUser1,
                PasswordSalt = passwordSaltUser1,
                Username = "2222",
                IsAdmin = true,
                Owner = owner1
            };
            User user2 = new User
            {
                PasswordHash = passwordHashUser2,
                PasswordSalt = passwordSaltUser2,
                Username = "mikkeland",
                IsAdmin = false,
                Owner = owner2
            };

            //Adding owners to pets
            pet1.Owners.Add(petOwner1);
            pet2.Owners.Add(petOwner2);
            pet3.Owners.Add(petOwner3);

            //Adding colors to the pet
            pet1.Colors.Add(petColor6);
            pet1.Colors.Add(petColor1);
            pet2.Colors.Add(petColor4);
            pet2.Colors.Add(petColor6);
            pet2.Colors.Add(petColor3);
            pet3.Colors.Add(petColor5);


            ctx.Pets.AddRange(pet1, pet2, pet3);
            ctx.Users.AddRange(user1, user2);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
