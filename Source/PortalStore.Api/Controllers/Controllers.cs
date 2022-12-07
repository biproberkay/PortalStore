using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Api.Services;
using PortalStore.Application;
using PortalStore.Application.Services;
using PortalStore.Domain.Entities;
using PortalStore.Shared.Wrappers;

namespace PortalStore.Api.Controllers
{
    public class OrderItemsController : BaseController<OrderItem, OrderItemReadDto,OrderItemEditDto,OrderItemCreateDto,OrderItemDeleteDto, int>
    {
        public OrderItemsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
    // Order
    public class OrdersController : BaseController<OrderItem, OrderReadDto,OrderEditDto,OrderCreateDto,OrderDeleteDto, int>
    {
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper){

        }
    }
    // Customer
    public class CustomersController : BaseController<Customer, CustomerReadDto,CustomerEditDto,CustomerCreateDto,CustomerDeleteDto, int>
    {
        private readonly IMernisService _mernisService;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper, IMernisService mernisService) : base(unitOfWork, mapper)
        {
            _mernisService = mernisService;
        }

        public override async Task<IActionResult> Put([FromBody] CustomerEditDto tCore, CancellationToken cancellationToken)
        {
            if (!await _mernisService.TrIdValidateAsync(tCore.TCID,tCore.FirstName,tCore.LastName,tCore.BirthDate.Year)) return Ok(CustomResult.Fail("Mernis TCID Validation failed"));
            return await base.Put(tCore, cancellationToken);
        }

        public override async Task<IActionResult> Post([FromBody] CustomerCreateDto tCore, CancellationToken cancellationToken)
        {
            if (!await _mernisService.TrIdValidateAsync(tCore.TCID, tCore.FirstName, tCore.LastName, tCore.BirthDate.Year)) return Ok(CustomResult.Fail("Mernis TCID Validation failed"));
            return await base.Post(tCore, cancellationToken);
        }
    }

    //Address
    public class AddressController : BaseController<Address, AddressReadDto,AddressEditDto,AddressCreateDto,AddressDeleteDto, int>
    {
        public AddressController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }

}