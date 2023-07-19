using Microsoft.EntityFrameworkCore;
using PayGateDotNetServer.Common.Models.Request;
using PayGateDotNetServer.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayGateDotNetServer.DAL;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Security.Cryptography.Xml;
using PayGateDotNetServer.Common.Models.Response;

namespace PayGateDotNetServer.BLL
{
    public class TransactionBusinessLogicLayer
    {
        private readonly PayGateDotNetServerDBContext dBContext;
        private CustomerBussinessLogicLayer customer;
        public TransactionBusinessLogicLayer(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
            customer = new CustomerBussinessLogicLayer(dBContext);
        }

        public async Task<Transaction> AddTransaction(TransactionRequest transactionRequest)
        {
            var customerAccount = dBContext.CustomerAccounts.Find(transactionRequest.CustomerId, transactionRequest.AccountId);
            
            if (customerAccount != null)
            {
                Transaction transaction = new Transaction();

                transaction.TransactionType = transactionRequest.TransactionType;
                transaction.Amount = transactionRequest.Amount;
                transaction.AccountId = transactionRequest.AccountId;
                transaction.CustomerId = transactionRequest.CustomerId;
                transaction.Date = transactionRequest.Date;
                transaction.TransactionReference = transactionRequest.TransactionReference;

                await dBContext.Transactions.AddAsync(transaction);

                //Altering the Balance
                if (transactionRequest.TransactionType == Common.Enumerations.TransactionType.CR)
                {
                    customerAccount.Balance += transactionRequest.Amount;
                    dBContext.CustomerAccounts.Update(customerAccount);
                }
                else if (transactionRequest.TransactionType == Common.Enumerations.TransactionType.DR)
                {
                    customerAccount.Balance -= transactionRequest.Amount;
                    dBContext.CustomerAccounts.Update(customerAccount);
                }
                await dBContext.SaveChangesAsync();

                return transaction;
            }
            return null;
        }

        public TransactionReportResponse GetCustomerTransaction(int custId, int accountId)
        {
            TransactionReportResponse transactionReport = new TransactionReportResponse() 
            { 
                Transactions = new List<Transaction>(),
                Customer = new Customer()
            };

            var customerFound = this.customer.GetCustomer(custId).Result;

            if (customerFound != null)
            {
                using (var db = this.dBContext)
                {
                    var Test = from transactions in db.Transactions
                               where transactions.AccountId == accountId
                               where transactions.CustomerId == custId
                               select new
                               {
                                   Amount = transactions.Amount,
                                   TransactionReference = transactions.TransactionReference,
                                   DateOfTransaction = transactions.Date,
                                   TransactionType = transactions.TransactionType
                               };

                    transactionReport.Customer = customerFound;
                   
                    foreach(var obj in Test.ToList())
                    {
                        transactionReport.Transactions.Add(new Transaction() { 
                            Amount = obj.Amount,
                            Date = obj.DateOfTransaction.ToUniversalTime(),
                            CustomerId = custId,
                            AccountId = accountId,
                            TransactionReference = obj.TransactionReference,
                            TransactionType = obj.TransactionType
                        });
                    }
                }
            }
            return transactionReport;
        }
    }
}
