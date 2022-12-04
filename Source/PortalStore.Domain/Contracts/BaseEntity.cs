using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Domain.Contracts
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreationDate { get; set; } 
        public Status Status { get; set; }
    }
}
