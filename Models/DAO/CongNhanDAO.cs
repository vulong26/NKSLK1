using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class CongNhanDAO
    {
        Model1 db;
        public CongNhanDAO()
        {
            db = new Model1();
        }

        public IEnumerable<CongNhan> listCN(int pageNum, int pageSize,string name) //, string maxp,string minp, int idcategory
        {

            string q = "select * from CongNhan where HoTen LIKE '%" + name + "%' or QueQuan LIKE '%" + name + "%'";
            var lst = db.Database.SqlQuery<CongNhan>(q).ToPagedList<CongNhan>(pageNum, pageSize);
            return lst;
        }
        public List<CongNhan> lstCN() 
        {

            string q = "select * from CongNhan ";
            var lst = db.Database.SqlQuery<CongNhan>(q).ToList<CongNhan>();
            return lst;
        }
        public void Delete(int id)
        {
            CongNhan congnhan = db.CongNhans.Find(id);
            if (congnhan != null)
            {
                db.CongNhans.Remove(congnhan);
                db.SaveChanges();
            }
        }

        public int Create(string name, DateTime? dob, bool gt, string phongban, string chucvu, string quequan,decimal luonghd , decimal luongbh)
        {

            CongNhan cn = new CongNhan();
            cn.MaCN = db.CongNhans.Max(i => i.MaCN) + 1;
            cn.HoTen = name;
            cn.NgaySinh = dob;
            cn.GioiTinh = gt;
            cn.PhongBan = phongban;
            cn.ChucVu = chucvu;
            cn.QueQuan = quequan;
            cn.LuongHD = luonghd;
            cn.LuongBaoHiem = luongbh;
            db.CongNhans.Add(cn);
            db.SaveChanges();
            return cn.MaCN;
        }
        public CongNhan getById(int id)
        {
            return db.CongNhans.Single(i => i.MaCN == id);
        }
        public void Edit(CongNhan tmp)
        {
            CongNhan cn = db.CongNhans.Find(tmp.MaCN);
            if (cn != null)
            {
                cn.HoTen = tmp.HoTen;
                cn.NgaySinh = tmp.NgaySinh;
                cn.GioiTinh = tmp.GioiTinh;
                cn.PhongBan = tmp.PhongBan;
                cn.ChucVu = tmp.ChucVu;
                cn.QueQuan = tmp.QueQuan;
                cn.LuongHD = tmp.LuongHD;
                cn.LuongBaoHiem = tmp.LuongBaoHiem;

                db.SaveChanges();

            }
        }
        public void Add(CongNhan cn)
        {
            db.CongNhans.Add(cn);
            db.SaveChanges();
        }
        public IEnumerable<CongNhan> listCN_VeHuu(int pageNum, int pageSize) //, string maxp,string minp, int idcategory
        {

            string q = "SELECT * FROM dbo.CongNhan WHERE(GioiTinh = 1 AND (DATEDIFF(DAY, NgaySinh, GETDATE()) >= 54 * 365) AND(DATEDIFF(DAY, NgaySinh, GETDATE()) <= 55 * 365)) OR (GioiTinh = 0 AND (DATEDIFF(DAY, NgaySinh, GETDATE()) >= 49 * 365) AND(DATEDIFF(DAY, NgaySinh, GETDATE()) <= 50 * 365))";
            var lst = db.Database.SqlQuery<CongNhan>(q).ToPagedList<CongNhan>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan> listCN_Tuoi30_45(int pageNum, int pageSize) //, string maxp,string minp, int idcategory
        {

            string q = "SELECT* FROM dbo.CongNhan WHERE((YEAR(GETDATE()) -YEAR(NgaySinh)) > 30 OR(((YEAR(GETDATE()) - YEAR(NgaySinh)) = 30) AND(MONTH(GETDATE()) > MONTH(NgaySinh))) OR(((YEAR(GETDATE()) - YEAR(NgaySinh)) = 30) AND(MONTH(GETDATE()) = MONTH(NgaySinh)) AND(DAY(GETDATE()) >= DAY(NgaySinh))) ) AND((YEAR(GETDATE()) - YEAR(NgaySinh)) < 45 OR(((YEAR(GETDATE()) - YEAR(NgaySinh)) = 45) AND(MONTH(GETDATE()) < MONTH(NgaySinh))) OR(((YEAR(GETDATE()) - YEAR(NgaySinh)) = 45) AND(MONTH(GETDATE()) = MONTH(NgaySinh)) AND(DAY(GETDATE()) <= DAY(NgaySinh))))";
            var lst = db.Database.SqlQuery<CongNhan>(q).ToPagedList<CongNhan>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan> listCN_PhongBan(int pageNum, int pageSize,string phongban) //, string maxp,string minp, int idcategory
        {

            string q = "Select * from CongNhan where PhongBan like '%" + phongban + "%' ";
            var lst = db.Database.SqlQuery<CongNhan>(q).ToPagedList<CongNhan>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongNhan> listCN_ChucVu(int pageNum, int pageSize,string chucvu) //, string maxp,string minp, int idcategory
        {

            string q = "Select * from CongNhan where ChucVu like '%" + chucvu + "%' ";
            var lst = db.Database.SqlQuery<CongNhan>(q).ToPagedList<CongNhan>(pageNum, pageSize);
            return lst;
        }

        public int SoTuoi(int MaCN)
        {
            string q = "SELECT DATEDIFF(DAY, NgaySinh, GETDATE())/365 FROM dbo.CongNhan where MaCN = '" + MaCN + "'";
            int n = db.Database.SqlQuery<int>(q).FirstOrDefault();
            return n;
        }
        //public Category getCategoryname(Products pro)
        //{
        //    return db.Category.Single(i => i.ID == pro.IDCATEGORY);
        //}


    }
}