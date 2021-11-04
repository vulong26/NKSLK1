namespace NKSLK.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViec")]
    public partial class CongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongViec()
        {
            DanhMucCongViecs = new HashSet<DanhMucCongViec>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaCV { get; set; }

        [StringLength(100)]
        public string TenCV { get; set; }

        public decimal? DinhMucKhoan { get; set; }

        [StringLength(50)]
        public string DonViKhoan { get; set; }

        public int? HeSoKhoan { get; set; }

        public decimal? DinhMucLD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucCongViec> DanhMucCongViecs { get; set; }
    }
}
