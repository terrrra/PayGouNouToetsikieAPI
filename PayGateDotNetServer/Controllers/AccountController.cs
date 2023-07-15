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
    public class AccountController : Controller
    {
        private readonly PayGateDotNetServerDBContext dBContext;
        public AccountController(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        [HttpGet, Route("getAccount")]
        public IActionResult GetAllAccounts()
        {
            var account = new AccountBusinessLogicLayer(this.dBContext);
            return Ok(account.GetAllAcounts());
        }

        [HttpPost, Route("addAccount")]
        public IActionResult AddAccount(AccountRequest addAccountRequest)
        {
            var account = new AccountBusinessLogicLayer(this.dBContext);
            return Ok(account.AddAccount(addAccountRequest));
        }
    }
}
