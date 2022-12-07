using MediatR;
using PortalStore.Domain.Entities;
using PortalStore.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Application.Features.Customer.Commands
{
    public class AddCustomerCommand : IRequest<CustomResult<CustomerCore>>
    {
    }
}
