using JagStore.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JagStore.Controllers
{
    public class CartController : Controller
    {
        private JagStoreContext db = new JagStoreContext();
        private readonly ISession _session;
        //public CartController()
        //{ }
        //    public CartController(ISession session)
        //{
        //    _session = session;
        
        //}
        // GET: Cart
        public ActionResult Index()
        {
            return View(db.InvoiceItems);
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult AddToCart(InvoiceItem cartAdd)
        {
            cartAdd.ProductDiscription.ProductID = (Guid)Session["id"];
            var product = db.ProductDiscriptions
                         .Where(pd => pd.ProductID == cartAdd.ProductDiscription.ProductID && pd.Size == cartAdd.ProductDiscription.Size && pd.Color == cartAdd.ProductDiscription.Color)
                         .Select(pd => pd.DiscriptionID).Single();
            dbConnector connector = new dbConnector();
            try
            {
                connector.AddToCart(cartAdd.InvoiceItemID, cartAdd.Product, cartAdd.Quantity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
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
