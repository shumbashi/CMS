using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }

        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }

        string? LastUpdatedBy { get; set; }
        DateTime? LastUpdatedDate { get; set; }
    }
}
