using PayGateDotNetServer.Common.Enumerations;
using System.Collections.Generic;

namespace PayGateDotNetServer.Common.Models.Request
{
    public class AccountRequest
    {
        public AccountType AccountType { get; set; }
        public double MonthlyFee { get; set; }
        //public ICollection<CustomerAccount> Accounts { get; set; }
        //public ICollection<Transaction> AccountTransactions { get; set; }
    }
}
