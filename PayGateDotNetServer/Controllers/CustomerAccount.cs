using Microsoft.AspNetCore.Mvc;
using PayGateDotNetServer.BLL;
using PayGateDotNetServer.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccount : Controller
    {
        [HttpGet, Route("getContacts")]
        public string GetAllContacts()
        {
            return "[]";
        }
    }
}
