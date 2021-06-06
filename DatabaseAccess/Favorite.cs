namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string idUser { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string idProduct { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifyAt { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
