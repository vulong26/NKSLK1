using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class CongNhanController : Controller
    {
        Model1 db;

        public ActionResult Index(int pageNum = 1, int pageSize = 10, string name="")
        {
            Session["CongNhan_Index"] = "index";
            CongNhanDAO dao = new CongNhanDAO();
            return View(dao.listCN(pageNum, pageSize,name));
        }
        public ActionResult CN_VeHuu(int pageNum = 1, int pageSize = 10)
        {
            CongNhanDAO dao = new CongNhanDAO();
            return View(dao.listCN_VeHuu(pageNum, pageSize));
        }
        public ActionResult CN_Tuoi30_45(int pageNum = 1, int pageSize = 10)
        {
            CongNhanDAO dao = new CongNhanDAO();
            return View( dao.listCN_Tuoi30_45(pageNum, pageSize));
        }
        public ActionResult CN_ChucVu(int pageNum = 1, int pageSize = 10, string chucvu = "")
        {
            db = new Model1();
            CongNhanDAO dao = new CongNhanDAO();
            List<CongNhan> lst = dao.lstCN();
            var cv = from cn in lst
                     group cn by cn.ChucVu into cvgroup
                     select cvgroup.Key;
            ViewBag.listChucVu = cv;
            return View(dao.listCN_ChucVu(pageNum, pageSize,chucvu));
        }
        public ActionResult CN_PhongBan(int pageNum = 1, int pageSize = 10,string phongban="")
        {
            db = new Model1();
            CongNhanDAO dao = new CongNhanDAO();
            List<CongNhan> lst = dao.lstCN();
            var pb = from cn in lst
                     group cn by cn.PhongBan into pbgroup
                     select pbgroup.Key;
            ViewBag.listPhongban = pb;
            return View(dao.listCN_PhongBan(pageNum, pageSize,phongban));
        }
        public ActionResult Delete(int id)
        {
            CongNhanDAO dao = new CongNhanDAO();
            dao.Delete(id);
            return Redirect("~/CongNhan/Index");
        }

        public ActionResult Create()
        {
            db = new Model1();
            CongNhanDAO dao = new CongNhanDAO();
            List<CongNhan> lst = dao.lstCN();
            var cv = from cn in lst group cn by cn.ChucVu into cvgroup
                    select cvgroup.Key;
            var pb = from cn in lst
                     group cn by cn.PhongBan into pbgroup
                     select pbgroup.Key;
            ViewBag.listChucVu = cv;
            ViewBag.listPhongban = pb;
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
             
                return RedirectToAction("Index");


        }
        public ActionResult Edit(int id)
        {
            db = new Model1();
            CongNhanDAO dao = new CongNhanDAO();
            ViewBag.cn = dao.getById(id);
            List<CongNhan> lst = dao.lstCN();
            var cv = from cn in lst
                     group cn by cn.ChucVu into cvgroup
                     select cvgroup.Key;
            var pb = from cn in lst
                     group cn by cn.PhongBan into pbgroup
                     select pbgroup.Key;
            ViewBag.listChucVu = cv;
            ViewBag.listPhongban = pb;
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
            return RedirectToAction("Index");
            
        }
    }
}