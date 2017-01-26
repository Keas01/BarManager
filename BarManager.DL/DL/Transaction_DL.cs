using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarManager.CommonLib;

namespace BarManager.DL
{
    public class Transaction_DL : Base_DL
    {
        public Transaction_DL()
            : base()
        {

        }

        public Transaction_DL(BarManagerEntities context)
            : base(context)
        {

        }

        public List<TransactionModel> GetTransactions()
        {
            var result = from t in context.Transactions
                         join tp in context.Transaction_Types
                         on t.FK_Transaction_Type equals tp.Transaction_Type_ID
                         join v in context.Vendors
                         on t.FK_Vendor equals v.VendorID
                         join tx in context.Tax_Rates
                         on t.FK_Tax_Rate equals tx.Tax_Rate_ID
                         join p in context.Payment_Methods
                         on t.FK_Payment_Method equals p.Payment_Method_ID
                         select new TransactionModel
                         {
                             TransactionID = t.TransactionID,
                             Amount = t.Amount,
                             Details = t.Details,
                             PaymentDate = t.Date,
                             Reason = t.Reason,
                             VendorID = t.FK_Vendor,
                             VendorName = v.VendorName,
                             TransactionTypeID = t.FK_Transaction_Type,
                             TransactionTypeName = tp.Transaction_TypeName,
                             TaxRateID = t.FK_Tax_Rate,
                             TaxRateAmount = tx.Tax_RateName,
                             PaymentMethodID = t.FK_Payment_Method,
                             PaymentMethodName = p.Payment_MethodName
                         };

            return result.ToList();
        }

        public bool CreateTransaction(TransactionModel trnsToCreate)
        {
            context.AddToTransactions(new Transaction
            {
                Amount = trnsToCreate.Amount,
                Date = trnsToCreate.PaymentDate,
                Reason = trnsToCreate.Reason,
                Details = trnsToCreate.Details,
                FK_Tax_Rate = trnsToCreate.TaxRateID,
                FK_Payment_Method = trnsToCreate.PaymentMethodID,
                FK_Transaction_Type = trnsToCreate.TransactionTypeID,
                FK_Vendor = trnsToCreate.VendorID
            });

            return (context.SaveChanges() > 0);
        }
    }
}
