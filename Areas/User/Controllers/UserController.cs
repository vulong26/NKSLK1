using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NKSLK.Areas.User.Data.DAO;

namespace NKSLK.Areas.User.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            ViewBag.ThongBao = "Đăng xuất để cập nhật mật khẩu";
            return View();
        }
        // GET: User/User
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaikhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();

            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(n => n.TaiKhoan1 == sTaikhoan && n.MatKhau == sMatKhau);
            if (tk != null && tk.PhanQuyen=="admin")
            {
                
                Session["admin"] = tk;
                ViewBag.ThongBao = "Đăng nhập thành công!!";


                //dao.getById(tk.MaTK).MaCN= 

                 return Redirect("~/Home/admin");
            }
            else if (tk != null && tk.PhanQuyen == "user")
            {
                UserDAO dao = new UserDAO();
                Session["congnhan"] = tk;
                ViewBag.MaCongnhan = dao.getById(tk.MaCN);
                ViewBag.ThongBao = "Đăng nhập thành công!!";
                return RedirectToAction("Index");
            }
            else if (tk==null)
            {
                ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng!";
                return View();
            }
            return RedirectToAction("Index");
        }
        public ActionResult DangXuat()
        {
            Session["congnhan"] = null;
          
            
             return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult TrangCaNhan(int MaCNs)
        {
            
            TaiKhoan cn = db.TaiKhoans.SingleOrDefault(n => n.MaCN == MaCNs );
            if (cn == null)
            {
                Response.StatusCode = 404;
                return null;

            }

            return View();
    }
        public ActionResult Edit(int MaTk)
        {
            CongNhanDAO dao = new CongNhanDAO();
            ViewBag.cn = dao.getById(MaTk);
            return View();
            

        }
        public ActionResult EditTK(int MaTk)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            ViewBag.tk = dao.getById(MaTk);
            return View();


        }
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]

        public ActionResult DangKy(TaiKhoan kh)
        {
            if (ModelState.IsValid)
            {

                db.TaiKhoans.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
                ViewBag.TbDKi("Đăng kí thành công");
            }
            
            return View();
        }



    }
}