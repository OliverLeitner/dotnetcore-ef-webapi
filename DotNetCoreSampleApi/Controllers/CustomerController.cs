using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DotNetCoreSampleApi.classicmodels;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public enum Types {
    Customer = 0,
    Employee = 1, // this one is broken atm, debuggin would rock
    Office = 2,
    Order = 3,
    Payment = 4,
    Product = 5
}

namespace DotNetCoreSampleApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private IConfiguration _config;
        public CustomerController(ILogger<CustomerController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet("/GetAllItems", Name = "GetAllItems")]
        public IEnumerable<Object> GetAllItems(Types type = Types.Customer)
        {
            using (var context = new classicmodelsContext())
            {
                switch (type)
                {
                    case Types.Customer:
                        return context.Customers.ToList();
                    case Types.Employee:
                        return context.Employees.ToList();
                    case Types.Product:
                        return context.Products.ToList();
                    case Types.Order:
                        return context.Orders.ToList();
                    case Types.Payment:
                        return context.Payments.ToList();
                    default:
                        return context.Offices.ToList();
                }
            }
        }

        [HttpGet("/GetItem", Name = "GetItem")]
        public Customer GetItem(
            String name = ""
        ) {
            using (var context = new classicmodelsContext())
            {
                var item = context.Customers.FirstOrDefault(p => p.CustomerName.Contains(name));
                if (item == null)
                    return null;
                return item;
            }
        }

        [HttpPost("/CreateCustomer")]
        [Authorize]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            using (var context = new classicmodelsContext())
            {
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
                return CreatedAtAction(nameof(PostCustomer), new { id = customer.CustomerNumber }, customer);
            }
        }
    }
}
