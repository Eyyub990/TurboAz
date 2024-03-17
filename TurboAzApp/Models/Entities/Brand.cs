using TurboAzApp.Models.Commons;

namespace TurboAzApp.Models.Entity
{
    public class Brand : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
