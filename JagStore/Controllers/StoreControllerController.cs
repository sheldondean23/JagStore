using JagStore.Models.db;
//using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JagStore.Controllers
{
    public class StoreController : Controller
    {       
        private JagStoreContext db = new JagStoreContext();
        //private readonly ISession _session;

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
            //var color = _session.QueryOver<ProductDiscription>().Where(pd => pd.ProductID == id).List()
            //                                     .Select(pd => new SelectListItem
            //                                     {
            //                                         Value = pd.DiscriptionID.ToString(),
            //                                         Text = pd.Color
            //                                     }).ToList();

            //var colors = db.ProductDiscriptions
            //             .Where(pd => pd.ProductID == id)
            //             .GroupBy(c => new { c.Color })
            //             .Select(final => new SelectListItem
            //             {

            //                 Value = ((final.Select(pid => pid.ProductID)).FirstOrDefault()).ToString(),
            //                 Text = final.Key.Color.ToString()
            //             }).ToList();

            Session["Pickcolor"] =
                            (from ProductDiscription in db.ProductDiscriptions
                             where ProductDiscription.ProductID == id
                             group ProductDiscription by new { ProductDiscription.Color }
                             into g
                             select new SelectListItem
                             {
                                 Value = g.Key.Color,
                                 Text = g.Key.Color
                             }).ToList();

            Session["name"] =
                            (from products in db.Products
                             where products.ProductID == id
                             select products.ProductName).Single();

            Session.Remove("id");
            Session.Add("id", id);

            return View(new InvoiceItem());
        }

        [Route("getSizeList/{color?}"), HttpGet]
        public ActionResult getSizeList(string id)
        {
            var ID = (Guid)Session["id"];
            var size = db.ProductDiscriptions
             .Where(pd => pd.ProductID == ID && pd.Color == id)
             .GroupBy(c => new { c.Size })
             .Select(final => new SelectListItem
             {

                 Value = final.Key.Size,
                 Text = final.Key.Size
             }).ToList();

            return Json(size, JsonRequestBehavior.AllowGet);
        }

        [Route("getSizeList/{color?}"), HttpGet]
        public ActionResult getPrice(string id, string size)
        {
            var ID = (Guid)Session["id"];
            var price = db.ProductDiscriptions
             .Where(pd => pd.ProductID == ID && pd.Color == id && pd.Size == size)
             .GroupBy(c => new { c.Size })
             .Select(final => new SelectListItem
             {

                 Value = final.Key.Size,
                 Text = final.Key.Size
             }).ToList();

            return Json(price, JsonRequestBehavior.AllowGet);
        }
    }
}