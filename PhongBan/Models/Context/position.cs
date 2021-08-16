namespace QLPhongBan.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("position")]
    public partial class position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public position()
        {
            departmentpositionhis = new HashSet<departmentpositionhi>();
            staffs = new HashSet<staff>();
        }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int comparelevel { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        [StringLength(50)]
        public string edituser { get; set; }

        public DateTime? edittime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<departmentpositionhi> departmentpositionhis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }
    }
}
