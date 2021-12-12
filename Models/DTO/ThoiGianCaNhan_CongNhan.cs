using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class ThoiGianCaNhan_CongNhan
    {
        public int MaCN { get; set; }
        public string HoTen { get; set; }
        public int ThoiGianCaNhan { get; set; }
        public int ThoiGianCongChuan { get; set; }
    }
}