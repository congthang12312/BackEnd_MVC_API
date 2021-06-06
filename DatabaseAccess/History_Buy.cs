namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class History_Buy
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string idUser { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string idProduct { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifyAt { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
