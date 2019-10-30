using System; 

namespace Project.Domain.Base
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Creation { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public Guid ModifiedBy { get; set; }

    }
}