using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Domain.Contracts
{
    public interface IBaseEntity<TId> : IReadDto<TId> { }

    public interface IReadDto<TId> : IEditDto<TId>, ICreatedAudit { }

    public interface IEditDto<TId> : ICreateDto, IDeleteDto<TId> { }

    public interface ICreateDto
    {
        public Status Status { get; set; }
    }

    public interface IDeleteDto<TId>
    {
        public TId Id { get; set; }
    }
    public interface ICreatedAudit 
    {
        public DateTime CreationDate { get; set; }
    }
}
