using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JagStore.Models
{
    public class Cart
    {
        public Guid DiscriptionID { get; set; }

        public Guid? ProductID { get; set; }

        public string Color { get; set; }
        
        public string Size { get; set; }
        
        public decimal RetailPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}

//@Html.DisplayNameFor(model => model.ProductDiscription.Product.ProductName)
//        </th>
//        <th>
//            @Html.DisplayNameFor(model => model.ProductDiscription.Color)
//        </th>
//        <th>
//            @Html.DisplayNameFor(model => model.ProductDiscription.Size)
//        </th>
//        <th>
//            @Html.DisplayNameFor(model => model.ProductDiscription.RetailPrice)
//        </th>
//        <th>
//            @Html.DisplayNameFor(model => model.Quantity)