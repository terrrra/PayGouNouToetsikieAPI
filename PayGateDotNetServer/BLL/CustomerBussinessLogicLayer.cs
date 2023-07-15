using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayGateDotNetServer.Common.Models;
using PayGateDotNetServer.Common.Models.Request;
using PayGateDotNetServer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.BLL
{
    public class CustomerBussinessLogicLayer
    {
        private readonly PayGateDotNetServerDBContext dBContext;
        public CustomerBussinessLogicLayer(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await dBContext.Customers.FindAsync(id);
            
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await dBContext.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> AddContact(CustomerRequest customerRequest)
        {
            var customer = new Customer()
            {
                FirstName = customerRequest.FirstName,
                LastName = customerRequest.LastName,
                Age = customerRequest.Age,
                Email = customerRequest.Email,
                Phone = customerRequest.Phone,
                IsActive = false
            };

            await dBContext.Customers.AddAsync(customer);
            await dBContext.SaveChangesAsync();

            return customer;

        } 

        public async Task<Customer> UpdateCustomer(int Id, UpdateCustomerRequest updateCustomerRequest)
        {
            var customer = await dBContext.Customers.FindAsync(Id);

            if(customer != null)
            {
                customer.FirstName = updateCustomerRequest.FirstName;
                customer.LastName = updateCustomerRequest.LastName;
                customer.Age = updateCustomerRequest.Age;
                customer.Email = updateCustomerRequest.Email;
                customer.Phone = updateCustomerRequest.Phone;

                await dBContext.SaveChangesAsync();
            }
            return customer;
        }
        
        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await dBContext.Customers.FindAsync(id);
            bool isDeleted = false;

            if(customer != null)
            {
                dBContext.Remove(customer);
                isDeleted = true;
            }
            return isDeleted;
        }
    }
}
