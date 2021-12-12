using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class ThongKeController : Controller
    {
        private Model1 db = new Model1();
        // GET: ThongKe
        public ActionResult Index(int pageNum = 1, int pageSize = 10)
        {
            Session["Controller"] = "ThongKe";

            if(Session["CongViec_NhatKy"] == null)
            {
                Session["CongViec_NhatKy"] = "index";
            }

            Session["Ca"] = "TatCa";
            Session["ThoiGian"] = "TatCa";
            Session["CongNhan"] = "TatCa";

            ThongKeDAO dao = new ThongKeDAO();

            ViewBag.CongNhan = dao.listCN();

            return View(dao.listIndex(pageNum, pageSize));
        }
        public ActionResult Loc(int pageNum = 1, int pageSize = 10)
        {
            Session["Controller"] = "ThongKe";
            Session["CongViec_NhatKy"] = "Loc";

            string Ca;

            if(Request["Ca"] == null)
            {
                Ca = Session["Ca"].ToString(); 
            }
            else
            {
                Ca = Request["Ca"].ToString();
                Session["Ca"] = Ca;
            }

            string ThoiGian;
            if(Request["ThoiGian"] == null)
            {
                ThoiGian = Session["ThoiGian"].ToString();
            }
            else
            {
                ThoiGian = Request["ThoiGian"].ToString();
                Session["ThoiGian"] = ThoiGian;
            }

            string Ngay = "";

            if (ThoiGian != "TatCa")
            {
                if (ThoiGian == "Tuan")
                {
                    if(Request["Calendar_Tuan"] == null || Request["Calendar_Tuan"].ToString() == "")
                    {
                        Ngay = Session["Calendar_Tuan"].ToString();
                    }
                    else
                    {
                        Ngay = Request["Calendar_Tuan"];
                        Session["Calendar_Tuan"] = Ngay;
                    }  
                }
                else if (ThoiGian == "Thang")
                {
                    if (Request["Calendar_Thang"] == null || Request["Calendar_Thang"].ToString() == "")
                    {
                        Ngay = Session["Calendar_Thang"].ToString();
                    }
                    else
                    {
                        Ngay = Request["Calendar_Thang"];
                        Session["Calendar_Thang"] = Ngay;
                    }
                }
            }

            string CongNhan;
            if (Request["CongNhan"] == null)
            {
                CongNhan = Session["CongNhan"].ToString();
            }
            else
            {
                CongNhan = Request["CongNhan"].ToString();
                Session["CongNhan"] = CongNhan;
            }

            ThongKeDAO dao = new ThongKeDAO();
            ViewBag.CongNhan = dao.listCN();

            return View("Index", dao.listIndex_Ca_TuanThang(Ca, ThoiGian, Ngay, CongNhan, pageNum, pageSize));
        }
    }
}