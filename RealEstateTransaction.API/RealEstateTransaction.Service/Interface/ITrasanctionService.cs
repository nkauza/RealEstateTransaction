using RealEstateTransaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateTransaction.Service.Interface
{
    public interface ITrasanctionService
    {
        List<Transaction> GetList();
        void UpdateList(List<Transaction> Transactions);
    }
}
