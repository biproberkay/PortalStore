using AutoMapper;
using MediatR;
using PortalStore.Domain.Entities;
using PortalStore.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Application.Features.CustomerFeatures.Commands
{
    public partial class AddCustomerCommand :CustomerCreateDto, IRequest<CustomResult<CustomerReadDto>>
    {
    }

    internal class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomResult<CustomerReadDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CustomResult<CustomerReadDto>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
