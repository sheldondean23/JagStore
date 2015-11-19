﻿using System;
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

        public virtual Product Product { get; set; }
    }
}