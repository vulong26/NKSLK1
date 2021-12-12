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
    public class NhatKySLKController : Controller
    {
        private Model1 db = new Model1();
        
        // GET: NhatKySLK
        public ActionResult Index(int pageNum = 1, int pageSize = 10)
        {
            Session["Controller"] = "NhatKySLK";
            Session["NhatKySLK_Index"] = "index";
            NKKhoanDAO dao = new NKKhoanDAO();
            return View(dao.listNKSLK(pageNum, pageSize));
        }
        public ActionResult Ca1_NKSLK(int pageNum = 1, int pageSize = 10)
        {
            Session["NhatKySLK_Index"] = "1";
            NKKhoanDAO dao = new NKKhoanDAO();
            return View("Index", dao.list_NKSLK_Ca(pageNum, pageSize, "1"));
        }
        public ActionResult Ca2_NKSLK(int pageNum = 1, int pageSize = 10)
        {
            Session["NhatKySLK_Index"] = "2";
            NKKhoanDAO dao = new NKKhoanDAO();
            return View("Index", dao.list_NKSLK_Ca(pageNum, pageSize, "2"));
        }
        public ActionResult Ca3_NKSLK(int pageNum = 1, int pageSize = 10)
        {
            Session["NhatKySLK_Index"] = "3";
            NKKhoanDAO dao = new NKKhoanDAO();
            return View("Index", dao.list_NKSLK_Ca(pageNum, pageSize, "3"));
        }
        public ActionResult NKSLK_All_Month(int pageNum = 1, int pageSize = 10)
        {
            NKKhoanDAO dao = new NKKhoanDAO();
            DateTime dt = DateTime.Now;
            string month = Request["month"];
            string name = Request["name"];
            if (Session["thang"] == null)
            {
                if (month == "" || month == null)
                {
                    month = dt.Year.ToString() + "-" + dt.Month.ToString();
                }
                else
                {
                    Session["thang"] = Request["month"];
                    month = Session["thang"].ToString();
                }
            }
            else
            {
                if (month == "" || month == null)
                {
                    month = Session["thang"].ToString();
                }
                else
                {
                    Session["thang"] = Request["month"];
                    month = Session["thang"].ToString();
                }
            }
            if(Session["name"]==null)
            {
                if(name == null)
                {
                    name = "";
                    Session["name"] = "";
                }
                else
                {
                    Session["name"] = Request["name"];
                    name = Session["name"].ToString();
                }
            }
            else
            {
                if (name == null)
                {
                    name = Session["name"].ToString();
                }
                else
                {
                    Session["name"] = Request["name"];
                    name = Session["name"].ToString();
                }
            }

            return View(dao.listNKSLK_Month(pageNum, pageSize, month,name));

        }
        public ActionResult NKSLK_All_Week(int pageNum = 1, int pageSize = 10)
        {
            NKKhoanDAO dao = new NKKhoanDAO();
            DateTime dt = DateTime.Now;
            string name = Request["name"];
            string day = Request["day"];
            if (Session["ngay"] == null)
            {
                if (day == null)
                {
                    day = dt.Year.ToString() + "-" + dt.Month.ToString()+ "-" + dt.Day.ToString();
                }
                else
                {
                    Session["ngay"] = Request["day"];
                    day = Session["ngay"].ToString();
                }
            }
            else
            {
                if (day == null)
                {
                    day = Session["ngay"].ToString();
                }
                else
                {
                    Session["ngay"] = Request["day"];
                    day = Session["ngay"].ToString();
                }
            }
            if (Session["name"] == null)
            {
                if (name == null)
                {
                    name = "";
                    Session["name"] = "";
                }
                else
                {
                    Session["name"] = Request["name"];
                    name = Session["name"].ToString();
                }
            }
            else
            {
                if (name == null)
                {
                    name = Session["name"].ToString();
                }
                else
                {
                    Session["name"] = Request["name"];
                    name = Session["name"].ToString();
                }
            }

            return View(dao.listNKSLK_Week(pageNum, pageSize, day,name));
        }

        // GET: NhatKySLK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhatKySLK nhatKySLK = db.NhatKySLKs.Find(id);
            if (nhatKySLK == null)
            {
                return HttpNotFound();
            }
            return View(nhatKySLK);
        }

        // GET: NhatKySLK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhatKySLK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhatKy,NgayThucHien,BatDau,KetThuc")] NhatKySLK nhatKySLK)
        {
            if (ModelState.IsValid)
            {
                db.NhatKySLKs.Add(nhatKySLK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhatKySLK);
        }

        // GET: NhatKySLK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhatKySLK nhatKySLK = db.NhatKySLKs.Find(id);
            if (nhatKySLK == null)
            {
                return HttpNotFound();
            }
            return View(nhatKySLK);
        }

        // POST: NhatKySLK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhatKy,NgayThucHien,BatDau,KetThuc")] NhatKySLK nhatKySLK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhatKySLK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhatKySLK);
        }

        // GET: NhatKySLK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhatKySLK nhatKySLK = db.NhatKySLKs.Find(id);
            if (nhatKySLK == null)
            {
                return HttpNotFound();
            }
            return View(nhatKySLK);
        }

        // POST: NhatKySLK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhatKySLK nhatKySLK = db.NhatKySLKs.Find(id);
            db.NhatKySLKs.Remove(nhatKySLK);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //--------------------------------------------HUY---------------------------------------------
        public ActionResult ChiTietCongNhan_NKSLK(int id, int pageNum = 1, int pageSize = 10)
        {
            NKKhoanDAO dao = new NKKhoanDAO();
            ViewBag.NgayThucHien = dao.NgayThucHienKhoan(id);
            ViewBag.Ca = dao.NKSLK_Ca(id);

            return View(dao.list_NKSLK_chiTietCN(pageNum, pageSize, id));
        }
    }
}
