using Microsoft.AspNetCore.Mvc;
using PayGateDotNetServer.BLL;
using PayGateDotNetServer.Common.Enumerations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayGateDotNetServer.Common.Models.Request
{
    public class TransactionRequest
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        //Amount and Reference
        public double Amount { get; set; }
        public string TransactionReference { get; set; }
        //Date and Time
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
