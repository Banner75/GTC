using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.Common;
using ZGZY.Model;
using ZGZY.BLL;

namespace MvcWeb.Controllers
{
    /// <summary>
    /// 功能说明：资讯管理
    /// 创建人员：林红刚
    /// 创建日期：2016/06/20
    /// 重制版人员：DeanWinchester
    /// </summary>
    public class InformationController : Controller
    {
        //#region 控制器私有方法

        


        //#endregion

        //#region 公用方法(公司公告/行业新闻/文件列表/系统消息/我的留言)

        //public ActionResult Notice(int kind)
        //{
        //    List<BS_Notices> datas = GetNotices(kind);
        //    ViewBag.NoticeList = datas;

        //    switch (kind)
        //    {
        //        case 1:
        //            ViewBag.Title = "公司公告";
        //            ViewBag.Kind = 1;
        //            break;

        //        case 2:
        //            ViewBag.Title = "行业新闻";
        //            ViewBag.Kind = 2; 
        //            break;

        //        case 3:
        //            ViewBag.Title = "文件列表";
        //            ViewBag.Kind = 3;
        //            break;

        //        case 4:
        //            ViewBag.Title = "系统消息";
        //            ViewBag.Kind = 4;
        //            break;

        //        case 5:
        //            ViewBag.Title = "我的留言";
        //            ViewBag.Kind = 5;
        //            break;

        //        case 6:
        //            ViewBag.Title = "帮助中心";
        //            ViewBag.Kind = 6;
        //            break;
        //    }

        //    return View();
        //}

        //public ActionResult DoNotice(int kind, int id)
        //{
        //    if (id <= 0)
        //    {
        //        return null;
        //    }

        //    switch (kind)
        //    {
        //        case 1:
        //            ViewBag.Title = "公司公告";
        //            break;

        //        case 2:
        //            ViewBag.Title = "行业新闻";
        //            break;

        //        case 3:
        //            ViewBag.Title = "文件列表";
        //            break;

        //        case 4:
        //            ViewBag.Title = "系统消息";
        //            break;

        //        case 5:
        //            ViewBag.Title = "我的留言";
        //            break;

        //        case 6:
        //            ViewBag.Title = "帮助中心";
        //            break;
        //    }

        //    BS_Notices data = GetNoticeByID(id);
        //    ViewBag.MyNotice = data;

        //    return PartialView("NoticeContent");
        //}

        //#endregion

        //#region 活动照片

        ///// <summary>
        ///// 页面启动
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult ActivityPhoto()
        //{
        //    return View();
        //}

        //#endregion

        //#region 视频花絮

        ///// <summary>
        ///// 页面启动
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult VideoPiece()
        //{
        //    return View();
        //}

        //#endregion

        //#region 帮助中心

        ///// <summary>
        ///// 首页启动
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult HelpCenter()
        //{
        //    return View();
        //}

        //#endregion
    }
}
