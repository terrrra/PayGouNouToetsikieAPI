using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayGateDotNetServer.BLL;
using PayGateDotNetServer.Common.Models;
using PayGateDotNetServer.Common.Models.Request;
using PayGateDotNetServer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : Controller
    {
        private readonly PayGateDotNetServerDBContext dBContext;

        public CustomerAccountController(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        [Route("getCustomer/{id:int}")]
        public IActionResult GetAllCustomerAccounts(int id)
        {
            var accountCustomer = new CustormerAccountBusinessLogicLayer(this.dBContext);

            var customerAccounts = accountCustomer.GetCustomerAccounts(id);
            if (customerAccounts.Count  != 0)
            {
                return Ok(customerAccounts);
            }
            return NotFound("No accounts are present for the given Id");
        }

        [HttpPost]
        [Route("createCustomerAccount")]
        public IActionResult AddCustomerAccount(CustomerAccountRequest addCustomerAccountRequest)
        {
            var account = new CustormerAccountBusinessLogicLayer(this.dBContext);

            if(account.AddCustomerAccount(addCustomerAccountRequest).Result == null)
            {
                return NotFound("Make Sure you have the right Keys Added. This Table has Link to the Account and the Customer Tables which form the Composite Key for the Table. Item Not Added");
            }

            return Ok("Record has been created successfully");
        }
    }
}
