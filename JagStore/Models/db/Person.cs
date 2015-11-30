namespace JagStore.Models.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        [StringLength(50)]
        public string UserID { get; set; }

        public int? CompanyID { get; set; }

        [StringLength(75)]
        public string FirstName { get; set; }

        [StringLength(75)]
        public string LastName { get; set; }

        [StringLength(75)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
