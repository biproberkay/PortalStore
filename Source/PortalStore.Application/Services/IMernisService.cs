using PortalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Application.Services
{
    public interface IMernisService
    {
        Task<bool> TrIdValidateAsync(CustomerCore customer);
    }
}
