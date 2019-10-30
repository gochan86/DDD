using System;

namespace Project.Domain.Base
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime Creation { get; set; }
        Guid CreatedBy { get; set; }
        DateTime LastModified { get; set; }
        Guid ModifiedBy { get; set; }
    }
}