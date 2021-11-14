using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class NKK_CongNhan
    {
        public int? MaCN { get; set; }

        public string HoTen { get; set; }

        public int? MaNhatKy { get; set; }
        public DateTime? NgayThucHien { get; set; }

        public TimeSpan? BatDau { get; set; }

        public TimeSpan? KetThuc { get; set; }
    }
}