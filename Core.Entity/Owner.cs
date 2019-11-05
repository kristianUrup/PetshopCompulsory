using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetshopCompulsory.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<PetOwner> Pets { get; set; }
    }
}
