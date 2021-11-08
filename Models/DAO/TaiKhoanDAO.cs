using NKSLK.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class TaiKhoanDAO
    {
        Model1 db;
        public TaiKhoanDAO()
        {
            db = new Model1();
        }

        public IEnumerable<TaiKhoan> listTK(int pageNum, int pageSize, string name) 
        {

            string q = "select * from TaiKhoan where TaiKhoan1 LIKE '%" + name + "%' or PhanQuyen LIKE '%" + name + "%'";
            var lst = db.Database.SqlQuery<TaiKhoan>(q).ToPagedList<TaiKhoan>(pageNum, pageSize);
            return lst;
        }
        public void Delete(int id)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan != null)
            {
                db.TaiKhoans.Remove(taikhoan);
                db.SaveChanges();
            }
        }

        public int Create(int matk, string tentk, string mk, string phanquyen, int macn)
        {

            TaiKhoan tk = new TaiKhoan();
            tk.MaTK = db.TaiKhoans.Max(i => i.MaTK) + 1;
            tk.TaiKhoan1 = tentk;
            tk.MatKhau = mk;
            tk.PhanQuyen= phanquyen;
            tk.MaCN = macn;
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            return tk.MaTK;
        }
        public TaiKhoan getById(int id)
        {
            return db.TaiKhoans.Single(i => i.MaTK == id);
        }
        public void Edit(TaiKhoan tmp)
        {
            TaiKhoan tk = db.TaiKhoans.Find(tmp.MaTK);
            if (tk != null)
            {
                tk.MaTK = tmp.MaTK;
                tk.TaiKhoan1 = tmp.TaiKhoan1;
                tk.MatKhau = tmp.MatKhau;
                tk.PhanQuyen = tmp.PhanQuyen;
                tk.MaCN = tmp.MaCN;

                db.SaveChanges();

            }
        }

        public void Add(TaiKhoan tk)
        {
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
        }
        
        //public Category getCategoryname(Products pro)
        //{
        //    return db.Category.Single(i => i.ID == pro.IDCATEGORY);
        //}
    }
}