using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CustomerController : ControllerBase
    {
        private readonly PayGateDotNetServerDBContext dBContext;
        public CustomerController(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        [Route("getCustomers")]
        public IActionResult GetAllCustomers()
        {
            var customer = new CustomerBussinessLogicLayer(this.dBContext);
            return Ok(customer.GetCustomers().Result);
        }

        [HttpGet]
        [Route("getCustomer/{id:int})")]
        public IActionResult GetCustomer([FromRoute] int id)
        {

            var customer = new CustomerBussinessLogicLayer(this.dBContext); 
            
            var retrievedcustomer = customer.GetCustomer(id);

            if (retrievedcustomer == null)
            {
                return NotFound();
            }

            return Ok(retrievedcustomer.Result);
        }

        [HttpPost]
        [Route("addCustomers")]
        public IActionResult AddCustomers(CustomerRequest addCustomerRequest)
        {
            var customer = new CustomerBussinessLogicLayer(this.dBContext);
            return Ok(customer.AddContact(addCustomerRequest).Result);
        }
         
        [HttpPut] 
        [Route("updateCustomer/{id:int}")]
        public IActionResult UpdateCustomer([FromRoute] int id, UpdateCustomerRequest updateContactRequest)
        {
            var customer = new CustomerBussinessLogicLayer(this.dBContext);

            var updatedCustomer = customer.UpdateCustomer(id, updateContactRequest);

            if (updatedCustomer.Result != null)
            {
                return Ok(updatedCustomer.Result);
            }
            return NotFound();
        }

        [HttpDelete] 
        [Route("(deleteCustomer/id:int)")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {

            var customer = new CustomerBussinessLogicLayer(this.dBContext);

            var deletedcustomer = customer.DeleteCustomer(id);

            if (deletedcustomer.Result == false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
