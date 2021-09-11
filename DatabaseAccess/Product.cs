namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Favorites = new HashSet<Favorite>();
            History_Buy = new HashSet<History_Buy>();
        }

        [StringLength(40)]
        public string id { get; set; }

        [Required]
        [StringLength(40)]
        public string name { get; set; }

        [Required]
        [StringLength(40)]
        public string slug { get; set; }

        [Required]
        [StringLength(40)]
        public string thumbnail { get; set; }

        public int price { get; set; }
        [Required]
        [StringLength(40)]
        public string category { get; set; }

        [StringLength(40)]
        public string sub_category { get; set; }

        public int quantity { get; set; }

        [Required]
        [StringLength(150)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifyAt { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite> Favorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History_Buy> History_Buy { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
