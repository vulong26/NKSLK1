using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class CongViecDAO
    {
        Model1 db;
        public CongViecDAO()
        {
            db = new Model1();
        }
        //public IEnumerable<CongViec> listCV(int pageNum, int pageSize) //, string maxp,string minp, int idcategory
        //{

        //    string q = "select * from CongViec";
        //    var lst = db.CongViec.SqlQuery(q).ToPagedList<CongViec>(pageNum, pageSize);
        //    return lst;
        //}
        public IEnumerable<CongViec> listCV(int pageNum, int pageSize, string name) //, string maxp,string minp, int idcategory
        {
            string q = "select * from CongViec where TenCV LIKE '%" + name + "%'";
            var lst = db.Database.SqlQuery<CongViec>(q).ToPagedList<CongViec>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongViec> list_CV_NhieuSLKNhat(int pageNum, int pageSize)
        {
            string q = "SELECT TOP(1) WITH TIES MaCV, TenCV, DinhMucKhoan, DonViKhoan, HeSoKhoan, DinhMucLD FROM dbo.v_MaxCV ORDER BY SoLuong DESC";
            var lst = db.Database.SqlQuery<CongViec>(q).ToPagedList<CongViec>(pageNum, pageSize);
            return lst;
        }

        public IEnumerable<CongViec> list_CV_DonGiaCaoNhat(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.CongViec WHERE (126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) = (SELECT MAX(126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) FROM dbo.CongViec)";
            var lst = db.Database.SqlQuery<CongViec>(q).ToPagedList<CongViec>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongViec> list_CV_DonGiaThapNhat(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.CongViec WHERE (126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) = (SELECT MIN(126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) FROM dbo.CongViec)";
            var lst = db.Database.SqlQuery<CongViec>(q).ToPagedList<CongViec>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongViec> list_CV_DonGiaCaoHon(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.CongViec WHERE (126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) >= (SELECT AVG(126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) FROM dbo.CongViec)";
            var lst = db.Database.SqlQuery<CongViec>(q).ToPagedList<CongViec>(pageNum, pageSize);
            return lst;
        }
        public IEnumerable<CongViec> list_CV_DonGiaNhoHon(int pageNum, int pageSize)
        {
            string q = "SELECT * FROM dbo.CongViec WHERE (126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) < (SELECT AVG(126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) FROM dbo.CongViec)";
            var lst = db.Database.SqlQuery<CongViec>(q).ToPagedList<CongViec>(pageNum, pageSize);
            return lst;
        }

        public IEnumerable<NhatKySLK> list_CV_NhatKy(int MaCV, int pageNum, int pageSize)
        {
            string q = "SELECT a.* FROM dbo.NhatKySLK AS a, dbo.ToNhanCong AS b, dbo.DanhMucCongViec AS c, dbo.CongViec AS d WHERE a.MaNhatKy = b.MaNhatKy AND b.MaToNhanCong = c.MaToNhanCong AND c.MaCV = d.MaCV AND d.MaCV = '" + MaCV + "' GROUP BY a.MaNhatKy, a.NgayThucHien, a.BatDau, a.KetThuc";
            var lst = db.Database.SqlQuery<NhatKySLK>(q).ToPagedList<NhatKySLK>(pageNum, pageSize);
            return lst;
        }
        public int SoNKSLK(int MaCV)
        {
            string q = "SELECT COUNT(a.MaNhatKy) FROM dbo.NhatKySLK AS a, dbo.ToNhanCong AS b, dbo.DanhMucCongViec AS c WHERE a.MaNhatKy = b.MaNhatKy AND b.MaToNhanCong = c.MaToNhanCong AND c.MaCV = '" + MaCV + "'";
            int n = db.Database.SqlQuery<int>(q).FirstOrDefault();
            return n;
        }
        public decimal AVG()
        {
            string q = "SELECT AVG(126360 * HeSoKhoan * DinhMucLD / DinhMucKhoan) FROM dbo.CongViec";
            decimal n = db.Database.SqlQuery<Decimal>(q).FirstOrDefault();
            return n;
        }
        public void Delete(int id)
        {
            CongViec congviec = db.CongViecs.Find(id);
            if (congviec != null)
            {
                db.CongViecs.Remove(congviec);
                db.SaveChanges();
            }
        }
        public void Add(CongViec cv)
        {
            db.CongViecs.Add(cv);
            db.SaveChanges();
        }
        public CongViec getById(int id)
        {
            return db.CongViecs.Single(i => i.MaCV == id);
        }
        public void Edit(CongViec congviec)
        {
            CongViec cv = db.CongViecs.Find(congviec.MaCV);
            if (cv != null)
            {
                cv.TenCV = congviec.TenCV;
                cv.DinhMucKhoan = congviec.DinhMucKhoan;
                cv.DonViKhoan = congviec.DonViKhoan;
                cv.HeSoKhoan = congviec.HeSoKhoan;
                cv.DinhMucLD = congviec.DinhMucLD;

                db.SaveChanges();
            }
        }
    }
}