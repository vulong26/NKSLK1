using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Areas.User.Data.DAO
{
    public class UserDAO
    {
        Model1 db;
        public UserDAO()
        {
            db = new Model1();
        }
        public CongNhan getById(int MaCn)
        {
            return db.CongNhans.Single(n => n.MaCN == MaCn);
            
      
        }
        public TaiKhoan getByIdTK(int MaTk)
        {
            return db.TaiKhoans.Single(n => n.MaTK == MaTk);

        }
        public void Detail(int MaTk)
        {
            TaiKhoan tk = db.TaiKhoans.Find(MaTk);
            if (tk != null)
            {
                string q = "select * from CongNhan where CongNhan.MaCN=TaiKhoan.MaCN and TaiKhoan.MaTK LIKE '%" + MaTk + "%' ";
                db.SaveChanges();
            }
        }

        public int Create(int matk, string tentk, string mk, string phanquyen, int macn)
        {

            TaiKhoan tk = new TaiKhoan();
            tk.MaTK = db.TaiKhoans.Max(i => i.MaTK) + 1;
            tk.TaiKhoan1 = tentk;
            tk.MatKhau = mk;
            tk.PhanQuyen = phanquyen;
            tk.MaCN = macn;
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            return tk.MaTK;
        }
        //public void listCT(int MaTK)
        //{
        //    string q = "select * from CongNhan where CongNhan.MaCN=TaiKhoan.MaCN and TaiKhoan.MaTK==''+'";
        //    var lst = db.Database.SqlQuery<CongNhan>(q);
        //}

    }
}