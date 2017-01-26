using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BarManager.CommonLib
{
    public class TaxRateModel
    {
        [ScaffoldColumn(false)]
        public int TaxRateID { get; set; }

        [DisplayName("Tax Rate")]
        public Decimal TaxRate { get; set; }
    }
}
