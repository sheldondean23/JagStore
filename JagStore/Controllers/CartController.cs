using Jagstore;
using JagStore.Models.db;
using JagStore.Models.Connector;
//using NHibernate;
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
        //private readonly ISession _session;
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

        // GET: Cart/Details/5
        public ActionResult Details(Guid id)
        {
            InvoiceItem Item = new InvoiceItem();
            Session.Remove("name");

            Item = db.InvoiceItems.Where(i => i.InvoiceItemID == id).Select(i => i).Single();
            Session["name"] =
                            (from products in db.Products
                             where products.ProductID == id
                             select products.ProductName).Single();

            return View(Item);
        }
        // POST: Cart/Create
        [HttpPost]
        public ActionResult AddToCart(InvoiceItem cartAdd)
        {
            cartAdd.ProductDiscription.ProductID = (Guid)Session["id"];
            var product = db.ProductDiscriptions
                         .Where(pd => pd.ProductID == cartAdd.ProductDiscription.ProductID && pd.Size == cartAdd.ProductDiscription.Size && pd.Color == cartAdd.ProductDiscription.Color)
                         .Select(pd => pd.DiscriptionID).Single();
            Cart connector = new Cart();
            try
            {
                connector.Add(Guid.NewGuid(), product, cartAdd.Quantity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(Guid id)
        {
            InvoiceItem editItem = new InvoiceItem();
            Session.Remove("name");

            Session["changeColor"] =
                           (from ProductDiscription in db.ProductDiscriptions
                            where ProductDiscription.ProductID == id
                            group ProductDiscription by new { ProductDiscription.Color }
                            into g
                            select new SelectListItem
                            {
                                Value = g.Key.Color,
                                Text = g.Key.Color
                            }).ToList();

            Session["changeSize"] = db.ProductDiscriptions
                            .Where(pd => pd.ProductID == id)
                            .GroupBy(c => new { c.Size })
                            .Select(final => new SelectListItem
                            {
                                Value = final.Key.Size,
                                Text = final.Key.Size
                            }).ToList();

            Session["name"] =
                            (from products in db.InvoiceItems
                             where products.InvoiceItemID == id
                             select products.ProductDiscription.Product.ProductName).Single();

            editItem = db.InvoiceItems.Where(i => i.InvoiceItemID == id).Select(i => i).Single();
            Session.Remove("id");
            Session.Add("id", id);

            return View(editItem);
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(InvoiceItem cartEdit)
        {
            cartEdit.ProductDiscription.ProductID = (Guid)Session["id"];
            var product = db.ProductDiscriptions
                         .Where(pd => pd.ProductID == cartEdit.ProductDiscription.ProductID && pd.Size == cartEdit.ProductDiscription.Size && pd.Color == cartEdit.ProductDiscription.Color)
                         .Select(pd => pd.DiscriptionID).Single();
            Cart connector = new Cart();
            try
            {
                connector.Edit(cartEdit.InvoiceItemID, product, cartEdit.Quantity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(Guid id)
        {
            InvoiceItem deleteItem = new InvoiceItem();
            Session.Remove("name");

            deleteItem = db.InvoiceItems.Where(i => i.InvoiceItemID == id).Select(i => i).Single();
            Session["name"] =
                            (from products in db.Products
                             where products.ProductID == id
                             select products.ProductName).Single();

            return View(deleteItem);
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(InvoiceItem cartDelete)
        {
            Cart connector = new Cart();
            try
            {
                connector.Delete(cartDelete.InvoiceItemID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
