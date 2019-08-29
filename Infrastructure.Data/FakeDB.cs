using Core.Entity;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class FakeDB
    {

        List<Pet> _pets;
        FakeDB()
        {
            InitPets();
        }
        private static void InitPets()
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

            _pets.Add(pet1);
        }
    }
}
