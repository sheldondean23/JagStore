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
        public ActionResult _Details(Guid id)
        {
            InvoiceItem Item = new InvoiceItem();
            Session.Remove("name");

            Item = db.InvoiceItems.Where(i => i.InvoiceItemID == id).Select(i => i).Single();
            Session["name"] =
                            (from products in db.InvoiceItems
                             where products.InvoiceItemID == id
                             select products.ProductDiscription.Product.ProductName).Single();

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
        public ActionResult _Edit(Guid id)
        {
            InvoiceItem editItem = new InvoiceItem();
            Session.Remove("name");
            Guid pid = db.InvoiceItems.Where(pd => pd.InvoiceItemID == id).Select(pd => pd.ProductDiscription.Product.ProductID).Single();

            Session["changeColor"] =
                           (from InvoiceItem in db.InvoiceItems
                            where InvoiceItem.ProductDiscription.Product.ProductID == pid
                            group InvoiceItem by new { InvoiceItem.ProductDiscription.Color }
                            into g
                            select new SelectListItem
                            {
                                Value = g.Key.Color,
                                Text = g.Key.Color
                            }).ToList();

            Session["changeSize"] = db.InvoiceItems
                            .Where(pd => pd.ProductDiscription.Product.ProductID == pid)
                            .GroupBy(c => new { c.ProductDiscription.Size })
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
            Guid id = (Guid)Session["id"];
            cartEdit.ProductDiscription.ProductID = db.InvoiceItems.Where(pd => pd.InvoiceItemID == id).Select(pd => pd.ProductDiscription.Product.ProductID).Single();
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
        public ActionResult _Delete(Guid id)
        {
            InvoiceItem deleteItem = new InvoiceItem();
            Session.Remove("name");

            deleteItem = db.InvoiceItems.Where(i => i.InvoiceItemID == id).Select(i => i).Single();
            Session["name"] =
                            (from products in db.InvoiceItems
                             where products.InvoiceItemID == id
                             select products.ProductDiscription.Product.ProductName).Single();

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
