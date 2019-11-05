using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.Entity
{
    public class PetOwner
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

    }
}
