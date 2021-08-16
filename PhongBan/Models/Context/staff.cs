namespace QLPhongBan.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staff")]
    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            departmentpositionhis = new HashSet<departmentpositionhi>();
            staffmanagergroups = new HashSet<staffmanagergroup>();
        }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(300)]
        public string address { get; set; }

        [StringLength(300)]
        public string hometown { get; set; }

        [StringLength(20)]
        public string mobiphone { get; set; }

        [StringLength(200)]
        public string photo { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public bool sex { get; set; }

        [StringLength(10)]
        public string departmentcode { get; set; }

        [StringLength(10)]
        public string positioncode { get; set; }

        public short left { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        [StringLength(50)]
        public string edituser { get; set; }

        public DateTime? edittime { get; set; }

        public virtual department department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<departmentpositionhi> departmentpositionhis { get; set; }

        public virtual position position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staffmanagergroup> staffmanagergroups { get; set; }
    }
}
