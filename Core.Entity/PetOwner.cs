using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.Entity
{
    public class PetOwner
    {
        public int Id { get; set; }
        public int PId { get; set; }
        public int OId { get; set; }
        public Owner Owner { get; set; }
        public Pet Pet { get; set; }
    }
}
