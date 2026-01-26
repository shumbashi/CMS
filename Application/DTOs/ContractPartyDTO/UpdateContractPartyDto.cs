using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ContractPartyDTO
{
    public class UpdateContractPartyDto
    {
        // Id remains required to locate the entity
        public Guid Id { get; set; }

        // Make optional for patch-like updates
        public string? ContractPartyName { get; set; }

        // Make optional so partial updates don't overwrite existing value
        public string? Residence { get; set; }

        // Collections nullable -> if null, handler ignores them; if provided, processed.
        public ICollection<Guid>? DocumentIds { get; set; }
        public ICollection<Guid>? CompanyIds { get; set; }
    }
}
