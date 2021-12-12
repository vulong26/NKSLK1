using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class GioCongChuanController : Controller
    {
        private Model1 db = new Model1();
        // GET: ThongKe
        public ActionResult Index(int pageNum = 1, int pageSize = 10)
        {
            Session["GioCongChuan"] = "index";

            GioCongChuanDAO dao = new GioCongChuanDAO();

            return View(dao.listIndex(pageNum, pageSize));
        }
        public ActionResult TimKiem(int pageNum = 1, int pageSize = 10)
        {
            Session["GioCongChuan"] = "TimKiem";

            GioCongChuanDAO dao = new GioCongChuanDAO();

            string Ngay;
            if (Request["Ngay"] == null || Request["Ngay"].ToString() == "")
            {
                if(Session["Ngay"] == null)
                {
                    return View("Index", dao.listIndex(pageNum, pageSize));
                }
                else
                {
                    Ngay = Session["Ngay"].ToString();
                }
            }
            else
            {
                Ngay = Request["Ngay"].ToString();
                Session["Ngay"] = Ngay;
            }

            return View("Index", dao.listTimKiem(Ngay, pageNum, pageSize));
        }
        public ActionResult ChiTietGioCongChuan(int pageNum = 1, int pageSize = 10)
        {
            Session["GioCongChuan"] = "ChiTietGioCongChuan";

            GioCongChuanDAO dao = new GioCongChuanDAO();

            string Ngay;
            if (Request["Ngay"] == null || Request["Ngay"].ToString() == "")
            {
                if (Session["Ngay"] == null)
                {
                    return View("Index", dao.listIndex(pageNum, pageSize));
                }
                else
                {
                    Ngay = Session["Ngay"].ToString();
                }
            }
            else
            {
                Ngay = Request["Ngay"].ToString();
                Session["Ngay"] = Ngay;
            }

            return View(dao.listVuotGioCongChuan(Ngay, pageNum, pageSize));
        }
    }
}