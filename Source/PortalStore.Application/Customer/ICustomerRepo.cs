using PortalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Application.CustomerBL
{
    public interface ICustomerRepo
    {
        Task<bool> AddCustomer(CustomerCore customer);
    }
}
