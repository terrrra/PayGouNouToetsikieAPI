using PayGateDotNetServer.Common.Enumerations;

namespace PayGateDotNetServer.Common.Models.Response
{
    public class CustomerAccountResponse
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }
        public double MonthlyFee { get; set; }
    }
}
