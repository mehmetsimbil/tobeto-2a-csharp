

using Core.Entities;

namespace Entities.Concrete
{
    public class Car : Entity<int>
    {
        public string Name { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public int CarState { get; set; }
        public int Kilometer { get; set; }
        public int ModelYear { get; set; }
        public string Plate { get; set; }
    }
}
