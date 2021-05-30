namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Slug { get; set; }

        [StringLength(50)]
        public string Parent_category { get; set; }

        [StringLength(50)]
        public string Sub_category { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? Quantily { get; set; }

        public int? Price { get; set; }

        public DateTime? ModifyAt { get; set; }

        public DateTime? CreateAt { get; set; }
    }
}
