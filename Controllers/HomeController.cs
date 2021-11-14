using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class HomeController : Controller
    {
        Model1 db;

        public ActionResult admin(int pageNum = 1, int pageSize = 10, string name="")
        {
            CongNhanDAO dao = new CongNhanDAO();
            return View(dao.listCN(pageNum, pageSize,name));
        }
        public ActionResult Delete(int id)
        {
            CongNhanDAO dao = new CongNhanDAO();
            dao.Delete(id);
            return Redirect("~/Home/admin");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string dob, string gt, string phongban, string chucvu, string quequan, string luonghd, string luongbh)
        {
            db = new Model1();
            CongNhan cn = new CongNhan();
            cn.MaCN = db.CongNhans.Max(i => i.MaCN) + 1;
            cn.HoTen = name;
            cn.NgaySinh = DateTime.Parse(dob);
            cn.GioiTinh = Convert.ToBoolean(gt);
            cn.PhongBan = phongban;
            cn.ChucVu = chucvu;
            cn.QueQuan = quequan;
            cn.LuongHD = Convert.ToDecimal(luonghd);
            cn.LuongBaoHiem = Convert.ToDecimal(luongbh);
            CongNhanDAO dao = new CongNhanDAO();
            dao.Add(cn);
             
                return RedirectToAction("admin");


        }
        public ActionResult Edit(int id)
        {
            CongNhanDAO dao = new CongNhanDAO();
            ViewBag.cn = dao.getById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string dob, string gt, string phongban, string chucvu, string quequan, string luonghd, string luongbh)
        {

            CongNhanDAO dao = new CongNhanDAO();
            CongNhan cn = dao.getById(id);
            cn.HoTen = name;
            cn.NgaySinh = DateTime.Parse(dob);
            cn.GioiTinh = Convert.ToBoolean(gt);
            cn.PhongBan = phongban;
            cn.ChucVu = chucvu;
            cn.QueQuan = quequan;
            cn.LuongHD = Convert.ToDecimal(luonghd);
            cn.LuongBaoHiem = Convert.ToDecimal(luongbh);
            dao.Edit(cn);
            return RedirectToAction("admin");
            
        }
    }
}