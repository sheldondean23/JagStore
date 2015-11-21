namespace JagStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        public int InvoiceID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserID { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime ShippingDate { get; set; }

        [Required]
        [StringLength(75)]
        public string ShipToName { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingAddressLine1 { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingAddressLine2 { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingCity { get; set; }

        [Required]
        [StringLength(2)]
        public string ShippingState { get; set; }

        [Required]
        [StringLength(10)]
        public string ShippingZip { get; set; }

        [StringLength(500)]
        public string ShippingTerms { get; set; }

        [Column(TypeName = "money")]
        public decimal ShippingCost { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}