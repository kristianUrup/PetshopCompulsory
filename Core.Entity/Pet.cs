using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetshopCompulsory.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public List<PetColor> Colors { get; set; }
        public double Price { get; set; }
        public List<PetOwner> Owners { get; set; }

    }
}
