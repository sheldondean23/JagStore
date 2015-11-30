namespace JagStore.Models.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDiscription")]
    public partial class ProductDiscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDiscription()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        public virtual Product Product { get; set; }
    }
}
