using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class ThongKeDAO
    {
        Model1 db;
        public ThongKeDAO()
        {
            db = new Model1();
        }

        public IEnumerable<CongNhan_NhatKy> listIndex(int pageNum, int pageSize)
        {
            string q = "SELECT d.MaCN, d.HoTen, a.* FROM dbo.NhatKySLK AS a, dbo.ToNhanCong AS b, dbo.DanhMucCongNhan AS c, dbo.CongNhan AS d WHERE a.MaNhatKy = b.MaNhatKy AND b.MaToNhanCong = c.MaToNhanCong AND c.MaCN = d.MaCN";
            var lst = db.Database.SqlQuery<CongNhan_NhatKy>(q).ToPagedList<CongNhan_NhatKy>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan_NhatKy> listIndex_Ca_TuanThang(string Ca, string ThoiGian, string Ngay, string CongNhan, int pageNum, int pageSize)
        {
            string q = "SELECT d.MaCN, d.HoTen, a.* FROM dbo.NhatKySLK AS a, dbo.ToNhanCong AS b, dbo.DanhMucCongNhan AS c, dbo.CongNhan AS d WHERE a.MaNhatKy = b.MaNhatKy AND b.MaToNhanCong = c.MaToNhanCong AND c.MaCN = d.MaCN";

            if(Ca != "TatCa")
            {
                if(Ca == "Ca1")
                {
                    q = q + " AND a.BatDau = '6:00'";
                }
                else if(Ca == "Ca2")
                {
                    q = q + " AND a.BatDau = '14:00'";
                }
                else if(Ca == "Ca3")
                {
                    q = q + " AND a.BatDau = '22:00'";
                }
            }

            if(ThoiGian != "TatCa" && Ngay != "")
            {
                if(ThoiGian == "Thang")
                {
                    q = q + " AND MONTH(a.NgayThucHien) = " + Ngay.Substring(5, 2) + " AND YEAR(a.NgayThucHien) = " + Ngay.Substring(0, 4);
                }
                else if(ThoiGian == "Tuan")
                {
                    q = q + " AND a.NgayThucHien >= dbo.Week_FirstDay('" + Ngay.Substring(0, 4) + Ngay.Substring(5, 2) + Ngay.Substring(8) + "') AND a.NgayThucHien <= dbo.Week_LastDay('" + Ngay.Substring(0, 4) + Ngay.Substring(5, 2) + Ngay.Substring(8) + "')";
                }
            }

            if(CongNhan != "TatCa")
            {
                q = q + " AND d.MaCN = " + CongNhan;
            }

            var lst = db.Database.SqlQuery<CongNhan_NhatKy>(q).ToPagedList<CongNhan_NhatKy>(pageNum, pageSize);
            return lst;
        }


        //------------------------------------CÔNG NHÂN------------------------------
        public IEnumerable<CongNhan> listCN()
        {
            string q = "SELECT * FROM dbo.CongNhan";
            var lst = db.Database.SqlQuery<CongNhan>(q).ToList<CongNhan>();
            return lst;
        }
    }
}