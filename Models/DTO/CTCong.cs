using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class CTCong
    {
        public DateTime  Ngay { get; set; }

        public TimeSpan GioBatDau { get; set; }

        public TimeSpan GioKetThuc { get; set; }
        public string TrangThai { get; set; }
        public double Cong { get; set; }
    }
}