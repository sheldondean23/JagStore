using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JagStore.Controllers
{
    public class StoreController : Controller
    {
        private JagStoreContext db = new JagStoreContext();
        // GET: Store
        public ActionResult Index()
        {
            return View(db.Products);

        }

        // GET: Store/Details/5
        public ActionResult Details(Guid id)
        {
            var model =
                               from products in db.ProductDiscriptions
                               where products.ProductID.Equals(id)
                               select products;

            return View(model);
        }

        // POST: Store/AddToCart
        [HttpPost]
        public ActionResult AddToCart(string id)
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

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
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