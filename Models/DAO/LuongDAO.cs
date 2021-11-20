using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class LuongDAO
    {
        Model1 db;
        public LuongDAO()
        {
            db = new Model1();
        }

        public IEnumerable<CongNhan_Luong> listLuong_Week(int pageNum, int pageSize, string day)
        {
            
                string q = "EXEC dbo.LuongSP_Tuan @Ngay ='" + day + "'";
                var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList(pageNum, pageSize);
                return lst;
            
        }
        public IEnumerable<CongNhan_Luong> listLuong_Month(int pageNum, int pageSize, string month)
        {
            string nam = month.Substring(0, 4);
            string thang = month.Substring(5, 2);
            string q = "EXEC dbo.LuongSP_Thang @Month = '" + thang + "', @Year = '" + nam + "'";
            var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan_Luong> LuongCaNhan(int pageNum, int pageSize, string month)
        {
            string q = "Select * from luongcongnhan";
            var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }


        public IEnumerable<CongNhan_Luong> listLuong_CaNhan(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.v_LuongCongNhan";
            var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan_Luong> listSortMax_LuongCaNhan(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.v_LuongCongNhan ORDER BY Luong DESC";
            var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList<CongNhan_Luong>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan_Luong> listSortMin_LuongCaNhan(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.v_LuongCongNhan ORDER BY Luong ASC";
            var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan_Luong> listMax_LuongCaNhan(int pageNum, int pageSize)
        {
            string q = "SELECT MAX([Luong]) AS 'Max' FROM dbo.v_LuongCongNhan";
            var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan_Luong> listMin_LuongCaNhan(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.v_LuongCongNhan";
            var lst = db.Database.SqlQuery<CongNhan_Luong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }

    }
}