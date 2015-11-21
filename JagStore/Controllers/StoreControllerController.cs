using JagStore.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductDiscription = JagStore.ProductDiscription;

namespace JagStore.Controllers
{
    public class StoreController : Controller
    {
        public Cart[] cart;
        public List<Cart> cartList = new List<Cart>();
        private JagStoreContext db = new JagStoreContext();
        private readonly ISession _session;

        //public StoreController(ISession session)
        //{
        //    _session = session;
        //}
        //public StoreController()
        //{
        //}
        // GET: Store
        public ActionResult Index()
        {
            return View(db.Products);

        }

        // GET: Store/Details/5
        public ActionResult Details(Guid id)
        {
            //var colors = _session.QueryOver<ProductDiscription>().Where(pd => pd.ProductID == id).List()
            //                                     .Select(pd => new SelectListItem
            //                                     {
            //                                         Value = pd.DiscriptionID.ToString(),
            //                                         Text = pd.Color
            //                                     }).ToList();
            var colors = db.ProductDiscriptions
                         .Where(pd => pd.ProductID == id)
                         .Select(pd => new SelectListItem
                         {
                             Value = pd.DiscriptionID.ToString(),
                             Text = pd.Color
                         }).ToList();

            var name =
                            (from products in db.Products
                            where products.ProductID == id     
                            select products.ProductName).Single();

            Session.Add("color", colors);
            Session.Add("name", name);

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

        [Route("getSizeList/{id?}/{color?}"), HttpGet]
        public ActionResult getSizeList(string id, string color)
        {
            var ID = new Guid(id);
            var size = db.ProductDiscriptions
                         .Where(pd => pd.ProductID == ID && pd.Color == color)
                         .Select(pd => new SelectListItem
                         {
                             Value = pd.DiscriptionID.ToString(),
                             Text = pd.Size
                         }).ToList();

            return Json(size, JsonRequestBehavior.AllowGet);
        }
    }
}