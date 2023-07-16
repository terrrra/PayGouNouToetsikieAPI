using PayGateDotNetServer.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.Common.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public AccountType AccountType{get; set;}
        public double MonthlyFee { get; set; }
        //public ICollection<CustomerAccount> Accounts { get; set; }
        //public ICollection<Transaction> AccountTransactions { get; set; }
    }
}