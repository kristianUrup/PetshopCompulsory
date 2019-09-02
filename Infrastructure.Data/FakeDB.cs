using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class FakeDB
    {
        public static IEnumerable<Pet> _pets;
        public static int id = 1;
        FakeDB()
        {
            InitData();
        }
        public static void InitData()
        {
            Pet pet1 = new Pet()
            {
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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
                Id = id++,
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

        
    }
}
