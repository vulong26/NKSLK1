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
                if (month == null)          //load đầu tiên
                {
                    month = dt.Year.ToString() + "-" + dt.Month.ToString();
                    Session["thang"] = month;
                }
                else                        // chọn tháng lần đầu
                {
                    Session["thang"] = Request["month"];
                    month = Session["thang"].ToString();
                }
            }
            else                            
            {
                if (month == null)                      // phân trang + đã chọn tháng
                {
                    month = Session["thang"].ToString();
                }
                else                                    // đã chọn tháng + chọn tháng mới
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

        public ActionResult Luong_CaNhan(int pageNum = 1, int pageSize = 10)
        {
            Session["max"] = null;
            Session["min"] = null;
            LuongDAO dao = new LuongDAO();
            
            return View(dao.listLuong_CaNhan(pageNum, pageSize));
        }

        // ------------------SAP XEP----------------------------------
        //----------------------------------------------------------
        public ActionResult SortMax_LuongCaNhan(int pageNum = 1, int pageSize = 10)
        {
            
            Session["max"] = 1 ;
            Session["min"] = null;
            LuongDAO dao = new LuongDAO();

            return View("Luong_CaNhan", dao.listSortMax_LuongCaNhan(pageNum, pageSize));
        }
        public ActionResult SortMin_LuongCaNhan(int pageNum = 1, int pageSize = 10)
        {
            Session["min"] = 2;
            Session["max"] = null;
            LuongDAO dao = new LuongDAO();
            return View("Luong_CaNhan", dao.listSortMin_LuongCaNhan(pageNum, pageSize));
        }

        //------------------------------------------------------------------
        //------------------------------------------------------------------


        public ActionResult Max_LuongCaNhan(int pageNum = 1, int pageSize = 10)
        {
            LuongDAO dao = new LuongDAO();

            return View(dao.listMax_LuongCaNhan(pageNum, pageSize));
        }
        public ActionResult Min_LuongCaNhan(int pageNum = 1, int pageSize = 10)
        {
            LuongDAO dao = new LuongDAO();

            return View(dao.listMin_LuongCaNhan(pageNum, pageSize));
        }
    }
}