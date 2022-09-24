using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateTransaction.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public int beds { get; set; }
        public int baths { get; set; }
        public string sq__ft { get; set; }
        public string type { get; set; }
        public string sale_date { get; set; }
        public decimal price { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
