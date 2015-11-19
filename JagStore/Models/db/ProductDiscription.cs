namespace JagStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDiscription")]
    public partial class ProductDiscription
    {
        [Key]
        public Guid DiscriptionID { get; set; }

        public Guid? ProductID { get; set; }

        [StringLength(10)]
        public string Color { get; set; }

        [StringLength(75)]
        public string Size { get; set; }

        public int QuantityInStock { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal RetailPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}
