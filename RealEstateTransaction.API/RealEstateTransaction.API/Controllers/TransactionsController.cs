using RealEstateTransaction.API.Models;
using RealEstateTransaction.Models;
using RealEstateTransaction.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RealEstateTransaction.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] //Allow cors for all orgins
    public class TransactionsController : ApiController
    {
        //Get a list of transactions
        public TransactionViewModel Get()
        {
            TransactionViewModel Response = new TransactionViewModel();

            Response.Transactions = new TransactionService().GetList();

            return Response;
        }

        //Update the list of transactions
        public void Post([FromBody] List<Transaction> Transactions)
        {
            new TransactionService().UpdateList(Transactions);
        }
    }
}
