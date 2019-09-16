using Core.Entity;
using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class FakeDB
    {
        public static IEnumerable<Pet> _pets;
        public static IEnumerable<Owner> _owners;
        public static IEnumerable<PetOwner> _petOwners;
        public static int idPet = 1;
        public static int idOwner = 1;
        FakeDB()
        {
            InitDataPet();
            InitDataOwner();
        }

        private void InitDataOwner()
        {
            Owner owner1 = new Owner()
            {
                Id = idOwner++,
                Firstname = "Charles",
                Lastname = "Bingo",
                Address = "Jungostreet 22",
                PhoneNumber = "28 29 20 22",
                Email = "bingo@hotmail.com"
            };
            Owner owner2 = new Owner()
            {
                Id = idOwner++,
                Firstname = "Chumpy",
                Lastname = "Dunky",
                Address = "Bingostreet 22",
                PhoneNumber = "28 99 21 23",
                Email = "dunky@hotmail.com"
            };
            Owner owner3 = new Owner()
            {
                Id = idOwner++,
                Firstname = "Goofy",
                Lastname = "Almighty",
                Address = "Shortstreet 22",
                PhoneNumber = "28 40 32 74",
                Email = "almighty@hotmail.com"
            };
            _owners = new List<Owner> { owner1, owner2, owner3 };
        }

        public static void InitDataPet()
        {
            Pet pet1 = new Pet()
            {
                Id = idPet++,
                Name = "Bobby",
                Type = "Cat",
                Birthdate = Convert.ToDateTime("20/08/2018"),
                SoldDate = Convert.ToDateTime("20/08/2019"),
                Color = "Red",
                PreviousOwner = "Bob",
                Price = 500
            };
            Pet pet2 = new Pet()
            {
                Id = idPet++,
                Name = "John",
                Type = "Dog",
                Birthdate = Convert.ToDateTime("20/07/2018"),
                SoldDate = Convert.ToDateTime("20/06/2019"),
                Color = "Black",
                PreviousOwner = "Johnny",
                Price = 549.99
            };
            Pet pet3 = new Pet()
            {
                Id = idPet++,
                Name = "Claus",
                Type = "Goat",
                Birthdate = Convert.ToDateTime("23/07/2018"),
                SoldDate = Convert.ToDateTime("22/06/2019"),
                Color = "Grey",
                PreviousOwner = "Santa Claus",
                Price = 49.95
            };

            Pet pet4 = new Pet()
            {
                Id = idPet++,
                Name = "Jørgen",
                Type = "Dog",
                Birthdate = Convert.ToDateTime("04/07/2018"),
                SoldDate = Convert.ToDateTime("03/06/2019"),
                Color = "Yellow",
                PreviousOwner = "Kristian",
                Price = 149.99
            };

            Pet pet5 = new Pet()
            {
                Id = idPet++,
                Name = "Salt",
                Type = "Goat",
                Birthdate = Convert.ToDateTime("12/07/2018"),
                SoldDate = Convert.ToDateTime("15/06/2019"),
                Color = "White/Grey",
                PreviousOwner = "Michael",
                Price = 449.95
            };

            Pet pet6 = new Pet()
            {
                Id = idPet++,
                Name = "The Rock",
                Type = "Cow",
                Birthdate = Convert.ToDateTime("25/12/2018"),
                SoldDate = Convert.ToDateTime("15/05/2019"),
                Color = "Black/White",
                PreviousOwner = "Kesi",
                Price = 444.95
            };

            Pet pet7 = new Pet()
            {
                Id = idPet++,
                Name = "Kevin",
                Type = "Cat",
                Birthdate = Convert.ToDateTime("20/07/2018"),
                SoldDate = Convert.ToDateTime("20/06/2019"),
                Color = "Grey",
                PreviousOwner = "Hart",
                Price = 549.99

            };
            _pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6, pet7 };
        }

        public static void InitDataPetOwners()
        {
            PetOwner petOwner1 = new PetOwner()
            {
                PId = 7,
                OId = 3
            };

            PetOwner petOwner2 = new PetOwner()
            {
                PId = 7,
                OId = 2
            };

            PetOwner petOwner3 = new PetOwner()
            {
                PId = 1,
                OId = 2
            };

            PetOwner petOwner4 = new PetOwner()
            {
                PId = 2,
                OId = 1
            };

            PetOwner petOwner5 = new PetOwner()
            {
                PId = 5,
                OId = 2
            };

            _petOwners = new List<PetOwner> { petOwner1, petOwner2, petOwner3, petOwner4, petOwner5 };
        }

        
    }
}
