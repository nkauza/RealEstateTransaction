using RealEstateTransaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateTransaction.API.Models
{
    public class TransactionViewModel
    {
        public List<Transaction> Transactions { get; set; }
    }
}