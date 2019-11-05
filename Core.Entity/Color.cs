using PetshopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopCompulsory.Core.Entity
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public List<PetColor> Pets { get; set; }
    }
}
