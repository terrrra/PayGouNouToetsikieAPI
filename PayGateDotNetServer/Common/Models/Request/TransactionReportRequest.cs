using System.Data;

namespace PayGateDotNetServer.Common.Models.Request
{
    public class TransactionReportRequest
    {
        public int ClientId { get; set; }
        public int AccountId { get; set; }
    }
}
