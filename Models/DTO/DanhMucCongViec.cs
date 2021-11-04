namespace NKSLK.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCongViec")]
    public partial class DanhMucCongViec
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaToNhanCong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCV { get; set; }

        public int? SLThucTe { get; set; }

        public int? SoLoSP { get; set; }

        public int? MaSP { get; set; }

        public virtual CongViec CongViec { get; set; }

        public virtual ToNhanCong ToNhanCong { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
