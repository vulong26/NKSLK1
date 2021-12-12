using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class SanPhamDAO
    {
        Model1 db;
        public SanPhamDAO()
        {
            db = new Model1();
        }

        public IEnumerable<SanPham> listSP(int pageNum, int pageSize, string name) //, string maxp,string minp, int idcategory
        {

            string q = "select * from SanPham where TenSP LIKE '%" + name + "%' or SoDangKy LIKE '%" + name + "%'";
            var lst = db.Database.SqlQuery<SanPham>(q).ToPagedList<SanPham>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<SanPham> listSP_NDK(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.SanPham WHERE NgayDangKy < '20210815'";
            var lst = db.Database.SqlQuery<SanPham>(q).ToPagedList<SanPham>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<SanPham> listSP_HSD(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.SanPham WHERE (DATEDIFF(DAY, NgayDangKy, HanSD)) > 365";
            var lst = db.Database.SqlQuery<SanPham>(q).ToPagedList<SanPham>(pageNum, pageSize);
            return lst;
        }
        
        public void Delete(int id)
        {
            SanPham sp = db.SanPhams.Find(id);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
            }
        }

        public int Create(string tensp, int sodk, DateTime hsd, string quycach, DateTime ngaydk)
        {

            SanPham sp = new SanPham();
            sp.MaSP = db.SanPhams.Max(i => i.MaSP) + 1;
            sp.TenSP = tensp;
            sp.SoDangKy = sodk;
            sp.HanSD = hsd;
            sp.QuyCach = quycach;
            sp.NgayDangKy = ngaydk;
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return sp.MaSP;
        }
        public SanPham getById(int id)
        {
            return db.SanPhams.Single(i => i.MaSP == id);
        }
        public void Edit(SanPham tmp)
        {
            SanPham sp = db.SanPhams.Find(tmp.MaSP);
            if (sp != null)
            {
                sp.TenSP = tmp.TenSP;
                sp.SoDangKy = tmp.SoDangKy;
                sp.HanSD = tmp.HanSD;
                sp.QuyCach = tmp.QuyCach;
                sp.NgayDangKy = tmp.NgayDangKy;

                db.SaveChanges();

            }
        }
        public void Add(SanPham sp)
        {
            db.SanPhams.Add(sp);
            db.SaveChanges();
        }

    }
}