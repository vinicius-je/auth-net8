using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Entities
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }
}
