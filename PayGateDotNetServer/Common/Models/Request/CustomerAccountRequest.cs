using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayGateDotNetServer.Common.Models.Request
{
    public class CustomerAccountRequest
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
