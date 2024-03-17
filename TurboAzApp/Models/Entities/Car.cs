using TurboAzApp.Models.Commons;
using TurboAzApp.Models.Stables;

namespace TurboAzApp.Models.Entity
{
    public class Car : AuditableEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Categories Category { get; set; }
        public Gears Gear { get; set; }
        public FuelTypes FuelType { get; set; }
        public Transmissions Transmission { get; set; }
        public decimal March { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }  
    }
}
