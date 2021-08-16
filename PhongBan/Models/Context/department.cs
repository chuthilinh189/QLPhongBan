namespace QLPhongBan.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("department")]
    public partial class department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public department()
        {
            departmentpositionhis = new HashSet<departmentpositionhi>();
            department1 = new HashSet<department>();
            staffs = new HashSet<staff>();
        }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [StringLength(10)]
        public string parentcode { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        [StringLength(50)]
        public string edituser { get; set; }

        public DateTime? edittime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<departmentpositionhi> departmentpositionhis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<department> department1 { get; set; }

        public virtual department department2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staffmanagergroup> staffmanagergroups { get; set; }
    }
}
