using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using PagedList;

namespace NKSLK.Controllers
{
    public class SanPhamController : Controller
    {
        Model1 db;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult phantrang(int pageNum = 1, int pageSize = 5, string name = "")
        {
            SanPhamDAO dao = new SanPhamDAO();
            return View(dao.listSP(pageNum, pageSize, name));
        }
        public ActionResult SP_NDK(int pageNum = 1, int pageSize = 5)
        {
            SanPhamDAO dao = new SanPhamDAO();
            //ViewBag.SoNKSLK = dao.SoNKSLK();
            //string ThoiGian;
            //if (Request["ThoiGian"] == null)
            //{
            //    ThoiGian = Session["ThoiGian"].ToString();
            //}
            //else
            //{
            //    ThoiGian = Request["ThoiGian"].ToString();
            //    Session["ThoiGian"] = ThoiGian;
            //}

            //string Ngay = "";

            //if (ThoiGian != "TatCa")
            //{
            //    if (ThoiGian == "Tuan")
            //    {
            //        if (Request["Calendar_Tuan"] == null)
            //        {
            //            Ngay = Session["Calendar_Tuan"].ToString();
            //        }
            //        else
            //        {
            //            Ngay = Request["Calendar_Tuan"];
            //            Session["Calendar_Tuan"] = Ngay;
            //        }
            //    }
            //    else if (ThoiGian == "Thang")
            //    {
            //        if (Request["Calendar_Thang"] == null)
            //        {
            //            Ngay = Session["Calendar_Thang"].ToString();
            //        }
            //        else
            //        {
            //            Ngay = Request["Calendar_Thang"];
            //            Session["Calendar_Thang"] = Ngay;
            //        }
            //    }
            //}

            return View("phantrang", dao.listSP_NDK(pageNum, pageSize));
        }
        public ActionResult SP_HSD(int pageNum = 1, int pageSize = 5)
        {
            SanPhamDAO dao = new SanPhamDAO();
            //ViewBag.SoNKSLK = dao.SoNKSLK();
            return View("phantrang", dao.listSP_HSD(pageNum, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        public ActionResult Delete(int id)
        {
            SanPhamDAO dao = new SanPhamDAO();
            dao.Delete(id);
            return Redirect("~/SanPham/phantrang");
        }

     
        public ActionResult Edit(int id)
        {
            SanPhamDAO dao = new SanPhamDAO();
            ViewBag.sp = dao.getById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(string tensp, int sodk, DateTime hsd, string quycach, DateTime ngaydk)
        {
            db = new Model1();
            SanPham sp = new SanPham();
            sp.MaSP = db.SanPhams.Max(i => i.MaSP) + 1;
            sp.TenSP = tensp;
            sp.SoDangKy = sodk;
            sp.HanSD = hsd;
            sp.QuyCach = quycach;
            sp.NgayDangKy = ngaydk;
            SanPhamDAO dao = new SanPhamDAO();
            dao.Add(sp);
            return RedirectToAction("phantrang");


        }

        [HttpPost]
        public ActionResult Edit(int id, string tensp, int sodk, DateTime hsd, string quycach, DateTime ngaydk)
        {

            SanPhamDAO dao = new SanPhamDAO();
            SanPham sp = dao.getById(id);

            sp.TenSP = tensp;
            sp.SoDangKy = sodk;
            sp.HanSD = hsd;
            sp.QuyCach = quycach;
            sp.NgayDangKy = ngaydk;
            dao.Edit(sp);
            return RedirectToAction("phantrang");
        }

    }
}

