using Core.Entity;

namespace PetshopCompulsory.Core.Entity
{
    public class PetColor
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int ColorId { get; set; }
        public Pet Pet { get; set; }
        public Color Color { get; set; }
    }
}