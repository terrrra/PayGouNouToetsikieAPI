using Microsoft.AspNetCore.Mvc;
using PayGateDotNetServer.BLL;
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
    public class TransactionController : ControllerBase
    {
        private readonly PayGateDotNetServerDBContext dBContext;
        public TransactionController(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost]
        [Route("createTransaction")]
        public IActionResult AddCustomerAccount(TransactionRequest transactionRequest)
        {
            var customerAccountTransaction = new TransactionBusinessLogicLayer(this.dBContext);

            if (customerAccountTransaction.AddTransaction(transactionRequest).Result == null)
            {
                return NotFound("Make Sure you have the right Keys Added. This Table has Link to the Account and the Customer Tables which form the Composite Key for the Table. Item Not Added");
            }

            return Ok("Record has been created successfully");
        }

        [HttpPost]
        [Route("getTransactionReport/{clientId:int}/{accountId:int}")]
        public IActionResult TransactionReport(int clientId, int accountId)
        {
            var customerTransaction = new TransactionBusinessLogicLayer(this.dBContext);

            var customerAccounts = customerTransaction.GetCustomerTransaction(clientId,accountId);

            if (customerAccounts.Customer.Id != 0)
            {
                return Ok(customerAccounts);
            }

            return NotFound("No transaction are present for the given Id");
        }
    }
}
