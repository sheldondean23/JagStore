using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JagStore.Models
{
    public class aProductsDetails
    {
        public Guid DiscriptionID { get; set; }

        public Guid? ProductID { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public int QuantityInStock { get; set; }

        public decimal RetailPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}