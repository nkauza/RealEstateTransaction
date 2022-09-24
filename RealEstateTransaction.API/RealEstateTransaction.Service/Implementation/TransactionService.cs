using CsvHelper;
using RealEstateTransaction.Models;
using RealEstateTransaction.Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateTransaction.Service.Implementation
{
    public class TransactionService : ITrasanctionService
    {
        public string TransactionsRepo;

        public TransactionService()
        {
            //Read file path from Web config
            TransactionsRepo = ConfigurationManager.AppSettings["TransactionsRepo"];
        }
        public List<Transaction> GetList()
        {
            List<Transaction> Transactions = new List<Transaction>();

            /*
             Read csv into a datatable using Csv helper
            Loop through datatable row and populate the Transactions list
             */
            DataTable dtTransactions = null;
            using (var reader = new StreamReader(TransactionsRepo))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    using (var dr = new CsvDataReader(csv))
                    {
                        dtTransactions = new DataTable("Transaction");
                        dtTransactions.Load(dr);
                    }
                }
            }

            if(dtTransactions != null && dtTransactions.Rows.Count > 0)
            {
                for(var i = 0; i < dtTransactions.Rows.Count; i++)
                {
                    var _Transaction = new Transaction
                    {
                        id = i,
                        baths = Convert.ToInt32(dtTransactions.Rows[i]["baths"]),
                        beds = Convert.ToInt32(dtTransactions.Rows[i]["beds"]),
                        city = (string)dtTransactions.Rows[i]["city"],
                        latitude = Convert.ToDecimal(dtTransactions.Rows[i]["latitude"]),
                        longitude = Convert.ToDecimal(dtTransactions.Rows[i]["longitude"]),
                        price = Convert.ToDecimal(dtTransactions.Rows[i]["price"]),
                        sale_date = (string)dtTransactions.Rows[i]["sale_date"],
                        sq__ft = (string)dtTransactions.Rows[i]["sq__ft"],
                        state = (string)dtTransactions.Rows[i]["state"],
                        street = (string)dtTransactions.Rows[i]["street"],
                        type = (string)dtTransactions.Rows[i]["type"],
                        zip = (string)dtTransactions.Rows[i]["zip"]
                    };

                    Transactions.Add(_Transaction);
                }
            }

            return Transactions;
        }

        public void UpdateList(List<Transaction> Transactions)
        {
            /*Use csv helper library to override the content of the file*/
            using (StreamWriter writer = new StreamWriter(TransactionsRepo))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<Transaction>();
                    csv.NextRecord();

                    csv.WriteRecords(Transactions);
                }
            }
        }
    }
}
