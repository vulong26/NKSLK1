using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class GioCongChuanDAO
    {
        Model1 db;
        public GioCongChuanDAO()
        {
            db = new Model1();
        }
        public IEnumerable<GioCongChuan> listIndex(int pageNum, int pageSize)
        {
            string q = "SELECT dbo.Week_FirstDay(NgayThucHien) AS 'NgayDauTuan', dbo.Week_LastDay(NgayThucHien) AS 'NgayCuoiTuan', dbo.ThoiGianCongChuan(NgayThucHien) AS 'ThoiGianCongChuan', IIF(dbo.ThoiGianCongChuan(NgayThucHien) = 44, N'Tuần chẵn', N'Tuần lẻ')  AS 'TrangThai' FROM dbo.NhatKySLK GROUP BY dbo.Week_FirstDay(NgayThucHien), dbo.Week_LastDay(NgayThucHien), dbo.ThoiGianCongChuan(NgayThucHien)";
            var lst = db.Database.SqlQuery<GioCongChuan>(q).ToPagedList<GioCongChuan>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<GioCongChuan> listTimKiem(string Ngay, int pageNum, int pageSize)
        {
            string q = "EXEC dbo.TimKiemGioCongChuan @Ngay = '"+ Ngay.Substring(0, 4) + Ngay.Substring(5, 2) + Ngay.Substring(8) + "'";
            var lst = db.Database.SqlQuery<GioCongChuan>(q).ToPagedList<GioCongChuan>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<ThoiGianCaNhan_CongNhan> listVuotGioCongChuan(string Ngay, int pageNum, int pageSize)
        {
            string q = "EXEC dbo.VuotThoiGianCongChuan @Ngay = '" + Ngay.Substring(0, 4) + Ngay.Substring(5, 2) + Ngay.Substring(8) + "'";
            var lst = db.Database.SqlQuery<ThoiGianCaNhan_CongNhan>(q).ToPagedList<ThoiGianCaNhan_CongNhan>(pageNum, pageSize);
            return lst;
        }
    }
}