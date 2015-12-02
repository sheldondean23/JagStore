using Jagstore.Models;
using Jagstore.Models.Connector;
using JagStore.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jagstore.Controllers
{
    public class CheckOutController : Controller
    {
        private JagStoreContext db = new JagStoreContext();
        // GET: CheckOut
        public ActionResult Index()
        {
            Total totals = new Total();
            int count = 0;

            foreach (var item in db.InvoiceItems)
            {
                totals.Value[count] = Convert.ToDouble(item.Quantity * item.ProductDiscription.RetailPrice);
                count++;
            }

            Session.Add("totals", totals);
            Receipt receipt = new Receipt();
            //receipt.Create(db.People.Select(p => p.UserID).Single(),
            //               db.Companies.Select(c => c.AddressLine1).Single(),
            //               db.Companies.Select(c => c.City).Single(),
            //               db.Companies.Select(c => c.StateCode).Single(),
            //               db.Companies.Select(c => c.Zip).Single(),
            //               Convert.ToDecimal(totals.SubTotal())
            //               );
            Session["companyName"] = db.Companies
                                     .Select(c => c.CompanyName).Single();
            ViewBag.InvoiceDate = db.Invoices.Select(i => i.InvoiceDate).Single();
            ViewBag.InvoiceID = db.Invoices.Select(i => i.InvoiceID).Single();
            ViewBag.Address = db.Invoices.Select(i => i.ShippingAddressLine1).Single();
            ViewBag.CityState = (db.Invoices.Select(i => i.ShippingCity).Single() + ", " + db.Invoices.Select(i => i.ShippingState).Single() + " " + db.Invoices.Select(i => i.ShippingZip).Single());

            return View(db.InvoiceItems);
        }

        // GET: CheckOut/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckOut/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckOut/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckOut/Edit/5
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

        // GET: CheckOut/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckOut/Delete/5
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
