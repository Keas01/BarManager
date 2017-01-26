using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarManager.BL;
using BarManager.CommonLib;

namespace BarManager.Controllers
{
    public class TransactionController : Controller
    {
        private Transaction_BL _transBL = null;
        public Transaction_BL TransBL
        {
            get
            {
                if (_transBL == null)
                {
                    _transBL = new Transaction_BL();
                }
                return _transBL;
            }
        }


        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            List<TransactionModel> details = TransBL.GetTransactions();
            return View(details.AsEnumerable());
        }

        //
        // GET: /Transaction/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Transaction/Create

        public ActionResult Create()
        {


            DropDownList_BL dbl = new DropDownList_BL();
            List<DDLItem> dropItems = dbl.GetDropdowns();

            List<DDLItem> vendors = dropItems.Where(d => d.Type.Equals("vendor")).ToList();
            ViewBag.VendorID = new SelectList(vendors, "ID", "Value");

            List<DDLItem> taxRates = dropItems.Where(d => d.Type.Equals("tax")).ToList();
            ViewBag.TaxRateID = new SelectList(taxRates, "ID", "Value");

            List<DDLItem> payMethods = dropItems.Where(d => d.Type.Equals("payment")).ToList();
            ViewBag.PaymentMethodID = new SelectList(payMethods, "ID", "Value");

            List<DDLItem> transType = dropItems.Where(d => d.Type.Equals("type")).ToList();
            ViewBag.TransactionTypeID = new SelectList(transType, "ID", "Value");

            return View();
        }

        //
        // POST: /Transaction/Create

        [HttpPost]
        public ActionResult Create(TransactionModel trnsToCreate)
        {
            try
            {
                if (TransBL.CreateTransaction(trnsToCreate) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Transaction/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Transaction/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Transaction/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Transaction/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
