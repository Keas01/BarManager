using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarManager.CommonLib;
using BarManager.DL;

namespace BarManager.BL
{
    public class DropDownList_BL
    {

        public List<DDLItem> GetDropdowns()
        {
            using (DropDownLists_DL dDL = new DropDownLists_DL())
            {
                return dDL.GetDropDowns();
            }
        }
    }
}
