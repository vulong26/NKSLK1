using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NKSLK.Controllers
{
    //[Authorize(Roles = "admin")]
    public class TaiKhoanController : Controller
    {
        Model1 db;
        public ActionResult Index()
        {
            return View();
        }

   
        public ActionResult phantrang(int pageNum = 1, int pageSize = 10,string name="")
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            return View(dao.listTK(pageNum, pageSize,name));
        }
        public ActionResult Delete(int id)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            dao.Delete(id);
            return Redirect("~/TaiKhoan/phantrang");
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            ViewBag.tk = dao.getById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Create( string tentk, string mk, string phanquyen, int macn)
        {
            db = new Model1();
            TaiKhoan tk = new TaiKhoan();
            tk.MaTK = db.TaiKhoans.Max(i => i.MaTK) + 1;
            tk.TaiKhoan1 = tentk;
            tk.MatKhau = mk;
            tk.PhanQuyen = phanquyen;
            tk.MaCN = macn;
            TaiKhoanDAO dao = new TaiKhoanDAO();
            dao.Add(tk);
            return RedirectToAction("phantrang");


        }

        [HttpPost]
        public ActionResult Edit(int id, string tentk, string mk, string phanquyen, int macn)
        {

            TaiKhoanDAO dao = new TaiKhoanDAO();
            TaiKhoan tk = dao.getById(id);
            
            tk.TaiKhoan1 = tentk;
            tk.MatKhau = mk;
            tk.PhanQuyen = phanquyen;
            tk.MaCN = macn;
            dao.Edit(tk);
            if (Session["admin"] != null)
            {
                return RedirectToAction("phantrang");
            }
            else if (Session["congnhan"] != null)
            {
                return Redirect("~/User/User/Index");
                ViewBag.ThongBao = " Mật khẩu sẽ được cập nhật sau ";
            }
            return View();

        }

        public ActionResult DangXuat()
        {
            
            Session["admin"] = null;

            return Redirect("~/User/User/DangNhap");

        }
    }
}