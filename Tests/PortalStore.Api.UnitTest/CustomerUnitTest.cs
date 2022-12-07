using Moq;
using PortalStore.Application.CustomerBL;
using PortalStore.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Api.UnitTest
{
#if false
    public class CustomerUnitTest
    {
        [Fact]
        public async void AddCustomer_ReturnFalse_WhenNameStartsWithoutS()
        {
            //Arrange
            var mernisService = new Mock<IMernisService>();

            CustomerRepo customer = new CustomerRepo(mernisService.Object);

            //Act
            var result = await customer.AddCustomer();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async void AddCustomer_ReturnFalse_WhenTrIdInvalidate()
        {
            //Arrange
            var mernisService = new Mock<IMernisService>();
            mernisService.Setup(x => x.TrIdValidateAsync(new Domain.Entities.CustomerCore())).ReturnsAsync(false);

            CustomerRepo customer = new CustomerRepo(mernisService.Object);

            //Act
            var result = await customer.AddCustomer(new Domain.Entities.CustomerCore { FirstName = "Serhat" });

            //Assert
            Assert.False(result);
        }
    } 
#endif
}
