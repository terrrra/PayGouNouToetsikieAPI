using PayGateDotNetServer.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayGateDotNetServer.Common.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        //Customer Foreign Key Entry
        [ForeignKey ("Customer")]
        public int CustomerId {get; set;}
        public Customer Customer { get; set; } 
        //Account Foreign Key Entry
       [ForeignKey("Account")]
        public int AccountId {get; set;}
        public Account Account { get; set; }
        //Amount and Reference
        public string Amount {get; set;}
        public string Reference {get; set;}
        //Date and Time
        public DateTime Date {get; set; }
        public TransactionType TransactionType {get; set; }
    }
}
