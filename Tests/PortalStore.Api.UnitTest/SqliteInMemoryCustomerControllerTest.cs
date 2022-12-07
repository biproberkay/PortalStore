using System;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using PortalStore.Api.Controllers;
using PortalStore.Application;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using PortalStore.Infrastructure;
using PortalStore.Domain.Entities;
using AutoMapper;
using PortalStore.Application.Mappings;
using PortalStore.Application.Services;
using PortalStore.Api.Services;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Shared.Wrappers;
using System.Collections.Generic;

namespace PortalStore.Api.UnitTests;

public class SqliteInMemoryCustomerControllerTest : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<PortalStoreDbContext> _contextOptions;
    private readonly PortalStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMernisService _mernisService;
    private readonly IUnitOfWork _unitOfWork;

    #region ConstructorAndDispose
    public SqliteInMemoryCustomerControllerTest()
    {
        // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
        // at the end of the test (see Dispose below).
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        // These options will be used by the context instances in this test suite, including the connection opened above.
        _contextOptions = new DbContextOptionsBuilder<PortalStoreDbContext>()
            .UseSqlite(_connection)
            .Options;

        // Create the schema and seed some data

        _context = new PortalStoreDbContext(_contextOptions);
        if (_context.Database.EnsureCreated())
        {
            using var viewCommand = _context.Database.GetDbConnection().CreateCommand();
            viewCommand.CommandText = @"
CREATE VIEW AllResources AS
SELECT *
FROM Customers;";
            viewCommand.ExecuteNonQuery();
        }
        _context.AddRange(
            new Customer
            {
                FirstName = "Þükrü",
                LastName = "Berkay",
                Email = "biproberkay@gmail.com",
                TCID = 15002296634,
                BirthDate = DateTime.Parse("14.08.1989"),
                CreationDate = DateTime.Parse("2022-12-06 09:01:12.992"),
                Gsm = "5398220128",
                Id = 1
            },
            new Customer
            {
                FirstName = "Wrong",
                LastName = "Smith",
                Email = "mrwrong@gmail.com",
                TCID = 15002296634,
                BirthDate = DateTime.Parse("14.08.1989"),
                CreationDate = DateTime.Parse("2022-12-06 09:01:12.992"),
                Gsm = "2022-12-06 09:01:12.992",
                Id = 2
            });
        _context.SaveChanges();

        _unitOfWork ??= new UnitOfWork(_context);

        if (_mapper == null)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
                //etc;
            });
            var mapper = config.CreateMapper();
            _mapper = mapper;
        }

        _mernisService ??= new MernisService();

    }

    public void Dispose() => _connection.Dispose();
    #endregion

    #region GetCustomer
    [Fact]
    public void GetCustomer_GivenEmailMatches_WhenSelectedIdCallRun() 
    {
        var controller = new CustomersController(_unitOfWork, _mapper, _mernisService);

        var result = controller.Get(1).Result as OkObjectResult;
        CustomResult<CustomerCore> response = (CustomResult<CustomerCore>)result.Value;
        Assert.Equal("biproberkay@gmail.com", response.Data.Email);
    }
    #endregion

    [Fact]
    public void GetCustomers_CustomerNameContains_WhenAddedValueCall() 
    {
        var controller = new CustomersController(_unitOfWork, _mapper, _mernisService);

        var result = controller.Get() as OkObjectResult;
        var response = (CustomResult<List<CustomerCore>>)result.Value;

        Assert.Collection(
            response.Data,
            b => Assert.Equal("Þükrü", b.FirstName),
            b => Assert.Equal("Smith", b.LastName));
    }

    [Fact]
    public async Task AddCustomer_ReturnFalse_WhenTCIDValidationFalse() 
    {
        var controller = new CustomersController(_unitOfWork, _mapper, _mernisService);
        var model = new CustomerCore
        {
            FirstName = "Erdem",
            LastName = "Berkay",
            Email = "erdemberkay@gmail.com",
            TCID = 15002296634,
            BirthDate = DateTime.Parse("14.08.1988"),
            CreationDate = DateTime.Parse("2022-12-06 09:01:12.992"),
            Gsm = "5398220128"
        };
        var result = await controller.Post(model, default) as OkObjectResult;
        var response = (CustomResult)result.Value;

        Assert.False(!response.Messages.Contains("Mernis TCID Validation failed"));
    }


}