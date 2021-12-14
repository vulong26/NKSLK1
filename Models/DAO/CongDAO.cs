using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class CongDAO
    {
        Model1 db;
        public CongDAO()
        {
            db = new Model1();
        }
        //public List<CongNhan_Cong> getById(int id)
        //{
        //    var lst = db.Database.SqlQuery<CongNhan_Cong>("").ToList();    // phan trang thay cho limit va offset trong sql
        //    return lst;
        //}
        //public float NgayCong(int MaCN,string month)
        //{
        //    string nam = month.Substring(0, 4);
        //    string thang = month.Substring(5, 2);
        //    string q = "select dbo.Tinh_SoNgayCong('" + MaCN + "','" + thang + "','" + nam + "') ";
        //    float n = db.Database.SqlQuery<float>(q).FirstOrDefault();
        //    return n;
        //}

        public IEnumerable<CongNhan_Cong> Cong_Month(int pageNum, int pageSize, string month)
        {
            string nam = month.Substring(0, 4);
            string thang = month.Substring(5, 2);
            string q = "EXEC dbo.Cong_TatCaCN '" + thang + "','" + nam + "'";
            var lst = db.Database.SqlQuery<CongNhan_Cong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }

        public IEnumerable<CTCong> ChiTietCong(int pageNum, int pageSize, int MaCN,string month)
        {
            string nam = month.Substring(0, 4);
            string thang = month.Substring(5, 2);
            string q = "exec ChiTietCong '" + MaCN + "','" + thang + "','" + nam + "'";
            var lst = db.Database.SqlQuery<CTCong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }

        public IEnumerable<CTCong> ChiTietCong1(int pageNum, int pageSize, int MaCN, string day)
        {
            string q = "exec ChiTietCong1 '" + MaCN + "','" + day + "'";
            var lst = db.Database.SqlQuery<CTCong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }
        

        public int ThoiGianCongChuan(string day)
        {
            string q = "SELECT dbo.ThoiGianCongChuan('" + day + "')";
            var t = db.Database.SqlQuery<int>(q).FirstOrDefault();
            return t;
        }

        public IEnumerable<CongNhan_Cong> VuotCongChuan(int pageNum, int pageSize, string day)
        {
            string q = "EXEC dbo.VuotThoiGianCongChuan '" + day + "'";
            var lst = db.Database.SqlQuery<CongNhan_Cong>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }

        public DateTime NgayDauTuan(string day)
        {
            string q = "SELECT dbo.Week_FirstDay('" + day + "')";
            var t = db.Database.SqlQuery<DateTime>(q).FirstOrDefault();
            return t;
        }

        public DateTime NgayCuoiTuan(string day)
        {
            string q = "SELECT dbo.Week_LastDay('" + day + "')";
            var t = db.Database.SqlQuery<DateTime>(q).FirstOrDefault();
            return t;
        }
    }
}