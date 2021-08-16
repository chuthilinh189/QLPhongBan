namespace QLPhongBan.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staffmanagergroup")]
    public partial class staffmanagergroup
    {

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(10)]
        public string staffcode { get; set; }

        [Required]
        [StringLength(10)]
        public string managegroupcode { get; set; }

        [Column("lock")]
        public short _lock { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        [StringLength(50)]
        public string edituser { get; set; }

        public DateTime? edittime { get; set; }

        public virtual managegroup managegroup { get; set; }

        public virtual staff staff { get; set; }
    }
}
