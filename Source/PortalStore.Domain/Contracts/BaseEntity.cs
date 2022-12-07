using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Domain.Contracts
{
    public abstract class BaseEntity<TId> : IReadQuery<TId>
    {
        public TId Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public interface IReadQuery<TId> : IEditCommand<TId>, ICreatedAudit { }

    public interface IEditCommand<TId> : ICreateCommand
    {
        public TId Id { get; set; }
    }

    public interface ICreateCommand
    {
        public Status Status { get; set; }
    }

    public interface IDeleteCommand<TId>
    {
        public TId Id { get; set; }
    }


    public interface ICreatedAudit 
    {
        public DateTime CreationDate { get; set; }
    }
}
