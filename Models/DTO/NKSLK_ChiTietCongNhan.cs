using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class NKSLK_ChiTietCongNhan
    {
        public int MaCN { get; set; }
        public string HoTen { get; set; }
        public int MaToNhanCong { get; set; }
        public TimeSpan? BatDauLam { get; set; }
        public TimeSpan? KetThucLam { get; set; }
        public string TrangThai { get; set; }
    }
}