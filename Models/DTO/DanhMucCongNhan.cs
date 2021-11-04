namespace NKSLK.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongNhan")]
    public partial class DanhMucCongNhan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaToNhanCong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCN { get; set; }

        public TimeSpan? BatDauLam { get; set; }

        public TimeSpan? KetThucLam { get; set; }

        public virtual CongNhan CongNhan { get; set; }

        public virtual ToNhanCong ToNhanCong { get; set; }
    }
}
