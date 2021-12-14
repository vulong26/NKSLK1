using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class CongController : Controller
    {
        // GET: Cong
        public ActionResult Index(int pageNum = 1, int pageSize = 10)
        {
            CongDAO dao = new CongDAO();
            DateTime dt = DateTime.Now;
            string month = Request["month"];
            if (Session["thang_cong"] == null)
            {
                if (month == null)          //load đầu tiên
                {
                    month = dt.Year.ToString() + "-" + dt.Month.ToString();
                    Session["thang_cong"] = month;
                }
                else                        // chọn tháng lần đầu
                {
                    Session["thang_cong"] = Request["month"];
                    month = Session["thang_cong"].ToString();
                }
            }
            else
            {
                if (month == null)                      // phân trang + đã chọn tháng
                {
                    month = Session["thang_cong"].ToString();
                }
                else                                    // đã chọn tháng + chọn tháng mới
                {
                    Session["thang_cong"] = Request["month"];
                    month = Session["thang_cong"].ToString();
                }
            }

            return View(dao.Cong_Month(pageNum, pageSize, month));
        }

        public ActionResult Detail(int id,int pageNum = 1, int pageSize = 10)
        {
            CongDAO dao = new CongDAO();
            string month = Session["thang_cong"].ToString();
            var lst = dao.Cong_Month(1,100,month);
            var c_cn = lst.Where(cn=>cn.MaCN==id).FirstOrDefault();
            ViewData["cong"] = c_cn;
            return View(dao.ChiTietCong(pageNum,pageSize,id,month));
        }

        public ActionResult Index_VuotCong(int pageNum = 1, int pageSize = 10)
        {
            CongDAO dao = new CongDAO();
            DateTime dt = DateTime.Now;
            string day = Request["day"];
            if (Session["ngay_cong"] == null)
            {
                if ( day == null)          //load đầu tiên
                {
                    day = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
                    Session["ngay_cong"] = day;
                }
                else                        // chọn tháng lần đầu
                {
                    Session["ngay_cong"] = Request["day"];
                    day = Session["ngay_cong"].ToString();
                }
            }
            else
            {
                if (day == null)                      // phân trang + đã chọn tháng
                {
                    day = Session["ngay_cong"].ToString();
                }
                else                                    // đã chọn tháng + chọn tháng mới
                {
                    Session["ngay_cong"] = Request["day"];
                    day = Session["ngay_cong"].ToString();
                }
            }

            return View(dao.VuotCongChuan(pageNum, pageSize, day));
        }

        public ActionResult Detail1(int id, int pageNum = 1, int pageSize = 10)
        {
            CongDAO dao = new CongDAO();
            string day = Session["ngay_cong"].ToString();
            var lst = dao.VuotCongChuan(1, 100, day);
            var c_cn = lst.Where(cn => cn.MaCN == id).FirstOrDefault();
            ViewData["cong1"] = c_cn;
            return View(dao.ChiTietCong1(pageNum, pageSize, id, day));
        }
    }
}