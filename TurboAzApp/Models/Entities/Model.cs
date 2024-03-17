using TurboAzApp.Models.Commons;

namespace TurboAzApp.Models.Entity
{
    public class Model : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BrandId { get; set; }
    }
}
