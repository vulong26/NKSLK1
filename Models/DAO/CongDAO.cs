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
        public IEnumerable<CongNhan_Cong> Cong_Month1(string month)
        {
            string nam = month.Substring(0, 4);
            string thang = month.Substring(5, 2);
            string q = "EXEC dbo.Cong_TatCaCN '" + thang + "','" + nam + "'";
            var lst = db.Database.SqlQuery<CongNhan_Cong>(q).ToList();
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
    }
}