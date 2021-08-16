namespace QLPhongBan.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class departmentpositionhi
    {
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(10)]
        public string staffcode { get; set; }

        [Required]
        [StringLength(10)]
        public string departmentcode { get; set; }

        [Required]
        [StringLength(10)]
        public string positioncode { get; set; }

        public bool effect { get; set; }

        [StringLength(10)]
        public string approvedby { get; set; }

        public DateTime? approvaltime { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        [StringLength(50)]
        public string edituser { get; set; }

        public DateTime? edittime { get; set; }

        public virtual department department { get; set; }

        public virtual position position { get; set; }

        public virtual staff staff { get; set; }

    }
}
