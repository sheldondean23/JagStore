//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JagStore.Mapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductDiscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDiscription()
        {
            this.InvoiceItems = new HashSet<InvoiceItem>();
        }
    
        public System.Guid DiscriptionID { get; set; }
        public Nullable<System.Guid> ProductID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int QuantityInStock { get; set; }
        public decimal RetailPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        public virtual Product Product { get; set; }
    }
}
