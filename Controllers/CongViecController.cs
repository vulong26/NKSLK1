using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class CongViecController : Controller
    {
        Model1 db;
        // GET: CongViec
        public ActionResult Index(int pageNum = 1, int pageSize = 10, string name = "")
        {
            CongViecDAO dao = new CongViecDAO();
            //ViewBag.SoNKSLK = dao.SoNKSLK();
            return View(dao.listCV(pageNum, pageSize, name));
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CV_NhieuSLKNhat(int pageNum = 1, int pageSize = 10)
        {
            CongViecDAO dao = new CongViecDAO();
            return View("Index", dao.list_CV_NhieuSLKNhat(pageNum, pageSize));
        }
        public ActionResult CV_DonGiaCaoNhat(int pageNum = 1, int pageSize = 10)
        {
            CongViecDAO dao = new CongViecDAO();
            return View("Index", dao.list_CV_DonGiaCaoNhat(pageNum, pageSize));
        }
        public ActionResult CV_DonGiaThapNhat(int pageNum = 1, int pageSize = 10)
        {
            CongViecDAO dao = new CongViecDAO();
            return View("Index", dao.list_CV_DonGiaThapNhat(pageNum, pageSize));
        }
        public ActionResult CV_DonGiaCaoHon(int pageNum = 1, int pageSize = 10)
        {
            CongViecDAO dao = new CongViecDAO();
            ViewBag.DonGiaTB = 1;
            return View("Index", dao.list_CV_DonGiaCaoHon(pageNum, pageSize));
        }
        public ActionResult CV_DonGiaNhoHon(int pageNum = 1, int pageSize = 10)
        {
            CongViecDAO dao = new CongViecDAO();
            ViewBag.DonGiaTB = 1;
            return View("Index", dao.list_CV_DonGiaNhoHon(pageNum, pageSize));
        }

        public ActionResult XemChiTiet(int id, int pageNum = 1, int pageSize = 10)
        {
            CongViecDAO dao = new CongViecDAO();
            ViewBag.cv = dao.getById(id);
            return View(dao.list_CV_NhatKy(id, pageNum, pageSize));
        }

        [HttpPost]
        public ActionResult Create(string TenCV, decimal DMK, string DVK, int HSK, decimal DMLD)
        {
            db = new Model1();
            CongViec cv = new CongViec();
            cv.MaCV = db.CongViecs.Max(i => i.MaCV) + 1;
            cv.TenCV = TenCV;
            cv.DinhMucKhoan = Convert.ToDecimal(DMK);
            cv.DonViKhoan = DVK;
            cv.HeSoKhoan = Convert.ToInt32(HSK);
            cv.DinhMucLD = Convert.ToDecimal(DMLD);

            CongViecDAO dao = new CongViecDAO();
            dao.Add(cv);

            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            CongViecDAO dao = new CongViecDAO();
            ViewBag.cv = dao.getById(id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, string TenCV, decimal DMK, string DVK, int HSK, decimal DMLD)
        {

            CongViecDAO dao = new CongViecDAO();
            CongViec cv = dao.getById(id);

            cv.TenCV = TenCV;
            cv.DinhMucKhoan = Convert.ToDecimal(DMK);
            cv.DonViKhoan = DVK;
            cv.HeSoKhoan = Convert.ToInt32(HSK);
            cv.DinhMucLD = Convert.ToDecimal(DMLD);
            dao.Edit(cv);
            return RedirectToAction("index");

        }
    }
}