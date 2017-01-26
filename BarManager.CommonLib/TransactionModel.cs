using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BarManager.CommonLib
{
    public class TransactionModel
    {
        [ScaffoldColumn(false)]
        public int TransactionID { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> PaymentDate { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public Nullable<decimal> Amount { get; set; }

        public String Reason { get; set; }

        public String Details { get; set; }

        public Image Image { get; set; }

        [DisplayName("Tax Rate")]
        public Nullable<int> TaxRateID { get; set; }

        [DisplayName("Pament Method")]
        public Nullable<int> PaymentMethodID { get; set; }

        [DisplayName("Transaction Type")]
        public Nullable<int> TransactionTypeID { get; set; }

        [DisplayName("Supplier")]
        public Nullable<int> VendorID { get; set; }

        [ScaffoldColumn(false)]
        public String VendorName { get; set; }

        [ScaffoldColumn(false)]
        public String PaymentMethodName { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<decimal> TaxRateAmount { get; set; }

        [ScaffoldColumn(false)]
        public String TransactionTypeName { get; set; }

    }
}
