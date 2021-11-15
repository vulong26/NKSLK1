namespace NKSLK.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTK { get; set; }
        
        [Column("TaiKhoan1")]
        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "{0} không thể để trống")]
        
        [StringLength(100)]
        public string TaiKhoan1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không thể để trống")]
        public string MatKhau { get; set; }

        [StringLength(100)]
        [Display(Name = "Quyền hạn")]
        [Required(ErrorMessage = "{0} không thể để trống")]
        public string PhanQuyen { get; set; }
        [Display(Name = "Mã công nhân của bạn")]
        public int MaCN { get; set; }

        public virtual CongNhan CongNhan { get; set; }
    }
}
