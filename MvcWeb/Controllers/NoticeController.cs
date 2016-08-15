using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.Common;

namespace MvcWeb.Controllers
{
    /// 重制版人员：DeanWinchester
    public class NoticeController : BaseController
    {

        public ActionResult Notice()
        {
            string page = Request.Params["page"];

            int pageindex;
            if (!string.IsNullOrEmpty(page))
            {
                if (string.IsNullOrEmpty(page) || SqlInjection.GetString(page))
                {
                    return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
                }
                pageindex = Convert.ToInt32(page);
            }
            else
            {
                pageindex = 1;
            }
            int totalCount;   //总记录数
            DataTable noticetable = new ZGZY.BLL.SuperPager().GetPagerList("BS_Notices", "*", "Created_Date  desc", 10, pageindex, "1=1", out totalCount);
            string pagination = new ZGZY.BLL.SuperPager().Getpagination(totalCount, 10, pageindex, "/Notice/Notice");
            ViewBag.pagination = pagination;
            return View(noticetable);
        }


        public ActionResult NoticeDetail()
        {
            int NoticeID = ZGZY.Common.DNTRequest.GetQueryInt("ID",0);
            if (NoticeID==0)
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }

            ZGZY.Model.BS_Notices Notice = new ZGZY.Model.BS_Notices();
            if (NoticeID==0)
            {
                return View(Notice);
            }
            else
            {
                Notice = new ZGZY.BLL.BS_Notices().GetModel(NoticeID);
                return View(Notice);
            }
        }




    }
}
