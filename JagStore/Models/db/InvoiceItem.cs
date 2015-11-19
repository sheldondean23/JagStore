namespace JagStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceItem
    {
        public int InvoiceItemID { get; set; }

        public int InvoiceID { get; set; }

        public Guid Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal SalePrice { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
