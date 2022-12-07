using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Api.Services;
using PortalStore.Application;
using PortalStore.Application.Services;
using PortalStore.Domain.Entities;
using PortalStore.Shared.Wrappers;

namespace PortalStore.Api.Controllers
{
    public class OrderItemsController : BaseController<OrderItem, OrderItemReadQuery,OrderItemEditCommand,OrderItemCreateCommand,OrderItemDeleteCommand, int>
    {
        public OrderItemsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
    // Order
    public class OrdersController : BaseController<OrderItem, OrderReadQuery,OrderEditCommand,OrderCreateCommand,OrderDeleteCommand, int>
    {
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper){

        }
    }
    // Customer
    public class CustomersController : BaseController<Customer, CustomerReadQuery,CustomerEditCommand,CustomerCreateCommand,CustomerDeleteCommand, int>
    {
        private readonly IMernisService _mernisService;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper, IMernisService mernisService) : base(unitOfWork, mapper)
        {
            _mernisService = mernisService;
        }

        public override async Task<IActionResult> Put([FromBody] CustomerEditCommand tCore, CancellationToken cancellationToken)
        {
            if (!await _mernisService.TrIdValidateAsync(tCore)) return Ok(CustomResult.Fail("Mernis TCID Validation failed"));
            return await base.Put(tCore, cancellationToken);
        }

        public override async Task<IActionResult> Post([FromBody] CustomerCreateCommand tCore, CancellationToken cancellationToken)
        {
            if (!await _mernisService.TrIdValidateAsync(tCore)) return Ok(CustomResult.Fail("Mernis TCID Validation failed"));
            return await base.Post(tCore, cancellationToken);
        }
    }

    //Address
    public class AddressController : BaseController<Address, AddressReadQuery,AddressEditCommand,AddressCreateCommand,AddressDeleteCommand, int>
    {
        public AddressController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }

}