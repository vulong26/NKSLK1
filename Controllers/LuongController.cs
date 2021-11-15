using NKSLK.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class LuongController : Controller
    {
        public ActionResult Luong_Month(int pageNum = 1, int pageSize = 10)
        {
            LuongDAO dao = new LuongDAO();
            DateTime dt = DateTime.Now;
            string month = Request["month"];
            if (Session["thang"] == null)
            {
                if (month == null)
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
                if (month == null)
                {
                    month = Session["thang"].ToString();
                }
                else
                {
                    Session["thang"] = Request["month"];
                    month = Session["thang"].ToString();
                }
            }
          
            return View(dao.listLuong_Month(pageNum, pageSize, month));

        }
        public ActionResult Luong_Week(int pageNum = 1, int pageSize = 10)
        {
            LuongDAO dao = new LuongDAO();
            DateTime dt = DateTime.Now;
            string day = Request["day"];
            if (Session["ngay"] == null)
            {
                if (day == null)
                {
                    day = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
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
            
            return View(dao.listLuong_Week(pageNum, pageSize, day));
        }
    }
}