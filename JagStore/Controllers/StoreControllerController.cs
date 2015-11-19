using JagStore.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JagStore.Controllers
{
    public class StoreController : Controller
    {
        public Cart[] cart;
        private JagStoreContext db = new JagStoreContext();
        private readonly ISession _session;
        // GET: Store
        public ActionResult Index()
        {
            return View(db.Products);

        }

        // GET: Store/Details/5
        public ActionResult Details(Guid id)
        {
          
            var name =
                               from products in db.Products
                               where products.ProductID == id
                               select products.ProductName;

            var color =
                               from products in db.ProductDiscriptions
                               where products.ProductID == id
                               select products.Color;
            var size =
                               from products in db.ProductDiscriptions
                               where products.ProductID == id
                               select products.Size;

            ViewBag.color = color.ToList();
            ViewBag.size = size.ToList();
            ViewBag.name = name.ToList();

            return View(new aProductsDetails());
        }

        // POST: Store/AddToCart
        [HttpPost]
        public ActionResult AddToCart(aProductsDetails selectedItem)
        {

            try
            {
                cart[cart.Count()] = new Cart();
                cart[cart.Count()].DiscriptionID = selectedItem.DiscriptionID;
                cart[cart.Count()].ProductID = selectedItem.ProductID;
                cart[cart.Count()].Color = selectedItem.Color;
                cart[cart.Count()].Size = selectedItem.Color;
                cart[cart.Count()].RetailPrice = selectedItem.RetailPrice;
                cart[cart.Count()].Product.ProductID = selectedItem.Product.ProductID;
                cart[cart.Count()].Product.ProductName = selectedItem.Product.ProductName;

                return RedirectToAction("Index","Cart");
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