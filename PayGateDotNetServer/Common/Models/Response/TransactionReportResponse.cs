using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.Common.Models.Response
{
    public class TransactionReportResponse
    {
        public Customer Customer { get; set; }
        public List<Transaction> Transactions{get;set;}
    }
}
