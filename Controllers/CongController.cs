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
            var lst = dao.Cong_Month(1,10,month);
            var c_cn = lst.Where(cn=>cn.MaCN==id).FirstOrDefault();
            ViewData["cong"] = c_cn;
            return View(dao.ChiTietCong(pageNum,pageSize,id,month));
        }
    }
}