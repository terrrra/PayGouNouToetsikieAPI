﻿using Microsoft.AspNetCore.Mvc;
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
        [Route("getCustomer/{id:int}")]
        public IActionResult GetCustomer([FromRoute] int id)
        {

            var customer = new CustomerBussinessLogicLayer(this.dBContext); 
            
            var retrievedcustomer = customer.GetCustomer(id);

            if (retrievedcustomer.Result == null)
            {
                return NotFound("Item Not Found in the Database");
            }

            return Ok(retrievedcustomer.Result);
        }

        [HttpPost]
        [Route("addCustomer")]
        public IActionResult AddCustomer(CustomerRequest addCustomerRequest)
        {
            var customer = new CustomerBussinessLogicLayer(this.dBContext);
            return Ok(customer.AddCustomer(addCustomerRequest).Result);
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
            return NotFound("Customer Not Found Item Not updated!");
        }

        [HttpPut]
        [Route("updatestate/{id:int}")]
        public IActionResult UpdateCustomerState([FromRoute] int id)
        {
            var customer = new CustomerBussinessLogicLayer(this.dBContext);

            var updatedCustomer = customer.UpdateCustomerState(id);

            if (updatedCustomer.Result != null)
            {
                return Ok(updatedCustomer.Result);
            }
            return NotFound("Customer Not Found State Not Updated!");
        }

        [HttpDelete] 
        [Route("deleteCustomer/{id:int}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {

            var customer = new CustomerBussinessLogicLayer(this.dBContext);

            var deletedcustomer = customer.DeleteCustomer(id);

            if (deletedcustomer.Result == false)
            {
                return NotFound("Customer Not Found Record not Deleted");
            }

            return Ok("Item Deleted thank you");
        }
    }
}
