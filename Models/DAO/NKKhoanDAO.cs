using NKSLK.Models;
using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class NKKhoanDAO
    {
        Model1 db;
        public NKKhoanDAO()
        {
            db = new Model1();
        }

        public IEnumerable<NhatKySLK> listNKSLK(int pageNum, int pageSize) 
        {

            string q = "select * from NhatKySLK";
            var lst = db.Database.SqlQuery<NhatKySLK>(q).ToPagedList<NhatKySLK>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<NKK_CongNhan> listNKSLK_Week(int pageNum, int pageSize, string day,string name) 
        {
            if (name == null || name == "")
            {
                string q = "EXEC dbo.NKSLK_Tuan_TatCaCN @Ngay = '" + day + "'";
                var lst = db.Database.SqlQuery<NKK_CongNhan>(q).ToPagedList(pageNum, pageSize);
                return lst;
            }
            else
            {
                string q = "EXEC dbo.NKSLK_Tuan @HoTen = '" + name + "', @Ngay = '" + day + "'";
                var lst = db.Database.SqlQuery<NKK_CongNhan>(q).ToPagedList(pageNum, pageSize);
                return lst;
            }
        }
        public IEnumerable<NKK_CongNhan> listNKSLK_Month(int pageNum, int pageSize,string month,string name) 
        {
            string nam = month.Substring(0,4);
            string thang = month.Substring(5, 2);
            string q = "SELECT d.MaCN, d.HoTen, a.* FROM dbo.NhatKySLK AS a, dbo.ToNhanCong AS b, dbo.DanhMucCongNhan AS c, dbo.CongNhan AS d WHERE a.MaNhatKy = b.MaNhatKy AND b.MaToNhanCong = c.MaToNhanCong AND c.MaCN = d.MaCN AND d.HoTen LIKE '%" + name + "%' and MONTH(a.NgayThucHien) =" + int.Parse(thang)+"  AND YEAR(a.NgayThucHien) =" + int.Parse(nam);
            var lst = db.Database.SqlQuery<NKK_CongNhan>(q).ToPagedList(pageNum, pageSize);
            return lst;
        }

        public void Delete(int id)
        {
            NhatKySLK nkk = db.NhatKySLKs.Find(id);
            if (nkk != null)
            {
                db.NhatKySLKs.Remove(nkk);
                db.SaveChanges();
            }
        }

        //public int Create(string name, DateTime? dob, bool gt, string phongban, string chucvu, string quequan, decimal luonghd, decimal luongbh)
        //{

        //    CongNhan cn = new CongNhan();
        //    cn.MaCN = db.CongNhans.Max(i => i.MaCN) + 1;
        //    cn.HoTen = name;
        //    cn.NgaySinh = dob;
        //    cn.GioiTinh = gt;
        //    cn.PhongBan = phongban;
        //    cn.ChucVu = chucvu;
        //    cn.QueQuan = quequan;
        //    cn.LuongHD = luonghd;
        //    cn.LuongBaoHiem = luongbh;
        //    db.CongNhans.Add(cn);
        //    db.SaveChanges();
        //    return cn.MaCN;
        //}
        public NhatKySLK getById(int id)
        {
            return db.NhatKySLKs.Single(i => i.MaNhatKy == id);
        }
        //public void Edit(CongNhan tmp)
        //{
        //    CongNhan cn = db.CongNhans.Find(tmp.MaCN);
        //    if (cn != null)
        //    {
        //        cn.HoTen = tmp.HoTen;
        //        cn.NgaySinh = tmp.NgaySinh;
        //        cn.GioiTinh = tmp.GioiTinh;
        //        cn.PhongBan = tmp.PhongBan;
        //        cn.ChucVu = tmp.ChucVu;
        //        cn.QueQuan = tmp.QueQuan;
        //        cn.LuongHD = tmp.LuongHD;
        //        cn.LuongBaoHiem = tmp.LuongBaoHiem;

        //        db.SaveChanges();

        //    }
        //}
        public void Add(NhatKySLK nkk)
        {
            db.NhatKySLKs.Add(nkk);
            db.SaveChanges();
        }
        //public Category getCategoryname(Products pro)
        //{
        //    return db.Category.Single(i => i.ID == pro.IDCATEGORY);
        //}

        //------------------------------------------------HUY----------------------------------------------------
        public IEnumerable<NhatKySLK> list_NKSLK_Ca(int pageNum, int pageSize, string ca)
        {
            string BatDau = "";
            if (ca == "1")
            {
                BatDau = "6:00";
            }
            else if (ca == "2")
            {
                BatDau = "14:00";
            }
            else if (ca == "3")
            {
                BatDau = "22:00";
            }

            string q = "SELECT * FROM dbo.NhatKySLK";
            if (BatDau != "")
            {
                q = "SELECT * FROM dbo.NhatKySLK WHERE BatDau = '" + BatDau + "'";
            }

            var lst = db.Database.SqlQuery<NhatKySLK>(q).ToPagedList<NhatKySLK>(pageNum, pageSize);
            return lst;
        }
        public DateTime NgayThucHienKhoan(int MaNhatKy)
        {
            string q = "SELECT NgayThucHien FROM dbo.NhatKySLK WHERE MaNhatKy = '" + MaNhatKy + "'";
            DateTime d = db.Database.SqlQuery<DateTime>(q).FirstOrDefault();
            return d;
        }
        public int NKSLK_Ca(int MaNhatKy)
        {
            string q = "SELECT IIF(BatDau = '6:00', 1, IIF(BatDau = '14:00', 2, 3)) FROM dbo.NhatKySLK WHERE MaNhatKy = '" + MaNhatKy + "'";
            int ca = db.Database.SqlQuery<int>(q).FirstOrDefault();
            return ca;
        }
        public IEnumerable<NKSLK_ChiTietCongNhan> list_NKSLK_chiTietCN(int pageNum, int pageSize, int MaNhatKy)
        {
            string q = "EXEC dbo.ChiTietNhatKy_CN @MaNhatKy = " + MaNhatKy;
            var lst = db.Database.SqlQuery<NKSLK_ChiTietCongNhan>(q).ToPagedList<NKSLK_ChiTietCongNhan>(pageNum, pageSize);
            return lst;
        }
    }
}