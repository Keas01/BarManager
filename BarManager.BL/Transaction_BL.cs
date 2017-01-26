using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarManager.CommonLib;
using BarManager.DL;

namespace BarManager.BL
{
    public class Transaction_BL
    {
        public List<TransactionModel> GetTransactions()
        {
            using (Transaction_DL tDL = new Transaction_DL())
            {
                return tDL.GetTransactions();
            }
        }

        public Boolean CreateTransaction(TransactionModel trnsToCreate)
        {
            using (Transaction_DL tDL = new Transaction_DL())
            {
                return tDL.CreateTransaction(trnsToCreate);
            }
        }
    }
}
