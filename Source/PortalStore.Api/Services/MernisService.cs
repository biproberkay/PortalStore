using Mernis;
using PortalStore.Application.Services;
using PortalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Api.Services
{
    public class MernisService : IMernisService
    {
        public Task<bool> TrIdValidateAsync(CustomerCore customer)
        {

            bool validationResult = false;
            try
            {
                var mernisClient = new KPSPublicSoapClient(Mernis.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(customer.TCID, customer.FirstName, customer.LastName, customer.BirthDate.Year).GetAwaiter().GetResult();
                validationResult = tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
            }
            catch (Exception ex)
            {
                validationResult = false;
            }
            return Task.FromResult(validationResult);
        }
    }
}
