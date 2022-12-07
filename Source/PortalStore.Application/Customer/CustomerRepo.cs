using PortalStore.Application.Services;
using PortalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Application.CustomerBL 
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly IMernisService _mernis;

        public CustomerRepo(IMernisService mernis)
        {
            _mernis = mernis;
        }

        public async Task<bool> AddCustomer(CustomerCreateDto customer)
        {
            if (!customer.FirstName.StartsWith("K"))
            {
                return false;
            }
            if(!await _mernis.TrIdValidateAsync(customer.TCID, customer.FirstName, customer.LastName, customer.BirthDate.Year))
            {
                return false;
            }

            //Added customer
            return true;
        }
    }
}
