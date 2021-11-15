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

        //public void Delete(int id)
        //{
        //    NhatKySLK nkk = db.NhatKySLKs.Find(id);
        //    if (nkk != null)
        //    {
        //        db.NhatKySLKs.Remove(nkk);
        //        db.SaveChanges();
        //    }
        //}

        ////public int Create(string name, DateTime? dob, bool gt, string phongban, string chucvu, string quequan, decimal luonghd, decimal luongbh)
        ////{

        ////    CongNhan cn = new CongNhan();
        ////    cn.MaCN = db.CongNhans.Max(i => i.MaCN) + 1;
        ////    cn.HoTen = name;
        ////    cn.NgaySinh = dob;
        ////    cn.GioiTinh = gt;
        ////    cn.PhongBan = phongban;
        ////    cn.ChucVu = chucvu;
        ////    cn.QueQuan = quequan;
        ////    cn.LuongHD = luonghd;
        ////    cn.LuongBaoHiem = luongbh;
        ////    db.CongNhans.Add(cn);
        ////    db.SaveChanges();
        ////    return cn.MaCN;
        ////}
        //public NhatKySLK getById(int id)
        //{
        //    return db.NhatKySLKs.Single(i => i.MaNhatKy == id);
        //}
        ////public void Edit(CongNhan tmp)
        ////{
        ////    CongNhan cn = db.CongNhans.Find(tmp.MaCN);
        ////    if (cn != null)
        ////    {
        ////        cn.HoTen = tmp.HoTen;
        ////        cn.NgaySinh = tmp.NgaySinh;
        ////        cn.GioiTinh = tmp.GioiTinh;
        ////        cn.PhongBan = tmp.PhongBan;
        ////        cn.ChucVu = tmp.ChucVu;
        ////        cn.QueQuan = tmp.QueQuan;
        ////        cn.LuongHD = tmp.LuongHD;
        ////        cn.LuongBaoHiem = tmp.LuongBaoHiem;

        ////        db.SaveChanges();

        ////    }
        ////}
        //public void Add(NhatKySLK nkk)
        //{
        //    db.NhatKySLKs.Add(nkk);
        //    db.SaveChanges();
        //}
        ////public Category getCategoryname(Products pro)
        ////{
        ////    return db.Category.Single(i => i.ID == pro.IDCATEGORY);
        ////}
    }
}