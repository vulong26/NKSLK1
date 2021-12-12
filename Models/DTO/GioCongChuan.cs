using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class GioCongChuan
    {
        public DateTime? NgayDauTuan { get; set; }
        public DateTime? NgayCuoiTuan { get; set; }
        public int? ThoiGianCongChuan { get; set; }
        public string TrangThai { get; set; }
    }
}