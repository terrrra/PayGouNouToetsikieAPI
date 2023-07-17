using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.Common.Models
{
   
    public class CustomerAccount
    {
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
