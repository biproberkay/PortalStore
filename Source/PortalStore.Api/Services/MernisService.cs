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
        public Task<bool> TrIdValidateAsync(long TCKimlikNo, string Ad, string Soyad, int DogumYili)
        {

            bool validationResult = false;
            try
            {
                var mernisClient = new KPSPublicSoapClient(Mernis.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(TCKimlikNo, Ad, Soyad, DogumYili).GetAwaiter().GetResult();
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
