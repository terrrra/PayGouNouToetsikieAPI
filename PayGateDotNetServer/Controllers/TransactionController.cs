using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        [HttpGet, Route("addCustomer")]
        public string AddCustomer()
        {
            return "Pong";
        }
    }
}
