namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Favorites = new HashSet<Favorite>();
            History_Buy = new HashSet<History_Buy>();
        }

        public string hashPassword(string password)
        {
            return this.password = password + "00000000";
        }

        [StringLength(40)]
        public string id { get; set; }

        [Required]
        [StringLength(40)]
        public string fullname { get; set; }

        [Required]
        [StringLength(40)]
        public string email { get; set; }

        [StringLength(40)]
        public string password { get; set; }

        [StringLength(40)]
        public string googleID { get; set; }

        [StringLength(40)]
        public string facebookID { get; set; }

        public int role { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifyAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite> Favorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History_Buy> History_Buy { get; set; }
        public override string ToString() {
            return "Person: " + id + " " + fullname + " " + email + " " + password + " "+ googleID + " " + facebookID + " " + createAt + " " + modifyAt;
        }
    }
}
