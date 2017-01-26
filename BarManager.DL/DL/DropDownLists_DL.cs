using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarManager;
using BarManager.CommonLib;

namespace BarManager.DL
{
    public class DropDownLists_DL : Base_DL
    {
        public DropDownLists_DL()
            : base()
        {

        }

        public DropDownLists_DL(BarManagerEntities context)
            : base(context)
        {

        }

        public List<DDLItem> GetDropDowns()
        {
            List<DDLItem> transTypes = context.Transaction_Types.
                Select(t => new DDLItem
                {
                    ID = t.Transaction_Type_ID,
                    Value = t.Transaction_TypeName,
                    Type = "type"
                }).ToList();

            List<DDLItem> vendors = context.Vendors.
                Select(t => new DDLItem
                {
                    ID = t.VendorID,
                    Value = t.VendorName,
                    Type = "vendor"
                }).ToList();

            List<DDLItem> taxTypes = context.Tax_Rates.ToList().
                Select(t => new DDLItem
                {
                    ID = t.Tax_Rate_ID,
                    Value = (t.Tax_RateName != null) ? t.Tax_RateName.Value.ToString() : "",
                    Type = "tax"
                }).ToList();

            List<DDLItem> PayTypes = context.Payment_Methods.
                Select(t => new DDLItem
                {
                    ID = t.Payment_Method_ID,
                    Value = t.Payment_MethodName,
                    Type = "payment"
                }).ToList();

            transTypes.AddRange(vendors);
            transTypes.AddRange(taxTypes);
            transTypes.AddRange(PayTypes);
            return transTypes;
        }

        public List<DDLItem> GetTransTypes()
        {
            List<DDLItem> transTypes = context.Transaction_Types.
                Select(t => new DDLItem
                {
                    ID = t.Transaction_Type_ID,
                    Value = t.Transaction_TypeName,
                    Type = "Trans"
                }).ToList();

            return transTypes;
        }

        public List<Tax_Rate> GetTaxRates()
        {
            List<Tax_Rate> taxRates = context.Tax_Rates.ToList();
            return taxRates;
        }

        public List<Vendor> GetVendors()
        {
            List<Vendor> vends = context.Vendors.ToList();
            return vends;
        }

        public List<Payment_Method> GetPaymentMethods()
        {
            List<Payment_Method> payMethods = context.Payment_Methods.ToList();
            return payMethods;
        }
    }
}
