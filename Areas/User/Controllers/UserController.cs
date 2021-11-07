using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NKSLK.Areas.User.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
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
            if (tk != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công!!";
                Session["congnhan"] = tk;
                return RedirectToAction("Index");
            }
            else if (tk==null)
            {
                ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng!";
                return View();
            }
            //ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng!";
            return RedirectToAction("Index");
        }
        public ActionResult DangXuat()
        {
            Session["congnhan"] = null;

            return RedirectToAction("Index");

        }
        //[HttpPost]
        ////public ActionResult TrangCaNhan(FormCollection f)
        //{
        //    TaiKhoan tk = db.TaiKhoans.SingleOrDefault(n=> n.MaCN==MaCn)
        //    tk..HoTen = f["txtHoTen"].ToString();
        //    kh.DiaChi = f["txtDiaChi"].ToString();
        //    kh.DienThoai = f["txtSdt"].ToString();
        //    //Sach sach = db.Saches.SingleOrDefault(n => n.MaS == MaSach);
        //    //if (sach == null)
        //    //{
        //    //    Response.StatusCode = 404;
        //    //    return null;

        //    //}
        //    //ViewBag.TenChuDe = db.TheLoais.Single(n => n.MaTL == sach.MaTL).TenTL;
        //    //ViewBag.TenNXB = db.NhaXuatBans.Single(n => n.MaNXB == sach.MaNXB).TenNXB;
        //    //ViewBag.TenTacGia = db.TacGias.Single(n => n.MaTG == sach.MaTG).TenTG;
        //    //return View(sach);
        //    return View();
        //}
    }
}