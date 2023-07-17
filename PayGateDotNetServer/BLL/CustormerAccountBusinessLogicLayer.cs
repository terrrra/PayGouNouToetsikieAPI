using PayGateDotNetServer.Common.Models.Request;
using PayGateDotNetServer.Common.Models;
using PayGateDotNetServer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using PayGateDotNetServer.Common.Models.Response;

namespace PayGateDotNetServer.BLL
{
    public class CustormerAccountBusinessLogicLayer
    {
        private readonly PayGateDotNetServerDBContext dBContext;
        private CustomerBussinessLogicLayer customer; 
        public CustormerAccountBusinessLogicLayer(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<CustomerAccount> AddCustomerAccount(CustomerAccountRequest customerAccountRequest)
        {
            var customerAccount = new CustomerAccount()
            {
                AccountId = customerAccountRequest.AccountId,
                CustomerId = customerAccountRequest.CustomerId,
                Name = customerAccountRequest.Name
            };

            try
            {
                await dBContext.CustomerAccounts.AddAsync(customerAccount);
                await dBContext.SaveChangesAsync();
            }
            catch
            {
                customerAccount = null;
            }
            return customerAccount;

        }

        public  List<CustomerAccountResponse> GetCustomerAccounts(int custId)
        {
            List<CustomerAccountResponse> customerAccounts = new List<CustomerAccountResponse>();

            CustomerAccountResponse response;

            var customerFound = this.customer.GetCustomer(custId).Result;
            
            if(customerFound != null)
            {
                using (var db = this.dBContext)
                {
                    var Test = from cusaccount in db.CustomerAccounts
                               from account in db.Account
                               where cusaccount.CustomerId == custId
                               where cusaccount.AccountId == account.Id
                               select new
                               {
                                   accountId = cusaccount.AccountId,
                                   monthlyFee = account.MonthlyFee,
                                   accountType = account.AccountType,
                                   name = cusaccount.Name,
                                   balance = cusaccount.Balance
                               };

                    foreach(var obj in Test)
                    {
                        response = new CustomerAccountResponse();

                        response.AccountId = obj.accountId;
                        response.MonthlyFee = obj.monthlyFee;
                        response.Name = obj.name;
                        response.AccountType = obj.accountType;
                        response.Balance = obj.balance;

                        customerAccounts.Add(response);
                    }
                }
            }
            return customerAccounts;
        }
    }
}
