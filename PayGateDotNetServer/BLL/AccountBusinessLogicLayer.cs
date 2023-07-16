using PayGateDotNetServer.Common.Models.Request;
using PayGateDotNetServer.Common.Models;
using PayGateDotNetServer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PayGateDotNetServer.BLL
{
    public class AccountBusinessLogicLayer
    {
        private readonly PayGateDotNetServerDBContext dBContext;
        public AccountBusinessLogicLayer(PayGateDotNetServerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IEnumerable<Account>> GetAllAcounts()
        {
            var customers = await dBContext.Account.ToListAsync();
            return customers;
        }

        public async Task<Account> AddAccount(AccountRequest accountRequest)
        {
            var account = new Account()
            {
                AccountType = accountRequest.AccountType,
                MonthlyFee = accountRequest.MonthlyFee,
               
            };

            await dBContext.Account.AddAsync(account);
            await dBContext.SaveChangesAsync();

            return account;

        }
    }
}
