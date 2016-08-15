using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.Common;
using ZGZY.Model;

namespace MvcWeb.Controllers
{
    /// 重制版人员：DeanWinchester
    public class MessageController : Controller
    {
        #region 我的留言
        /// <summary>
        /// 我的留言
        /// </summary>
        /// <returns></returns>
        public ActionResult MyMessage() 
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            var List=new ZGZY.BLL.Message().GetMessageList(string.Format("Login_Account='{0}'", Userid)).Tables[0];
            return View(List);
        }


        #region 添加留言

        public ActionResult AddMessage() 
        {
            return View();
        }

        public ActionResult Add() 
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            var title = Request.Form["title"];
            var content = Request.Form["content"];
            if (title == null) { return Content("标题不能为空"); }
            if (content == null) { return Content("内容不能为空"); }

            ZGZY.Model.Message Model = new Message();
            Model.ID = DateTime.Now.ToString("yyyyMMddhhmmssffff");
            Model.Title = title;
            Model.Content = content;
            Model.CreateDate = DateTime.Now;
            Model.Login_Account = Userid;
            Model.Type = 4;
            Model.State = 1;
            Model.ReplyDate = DateTime.Now;
            if (new ZGZY.BLL.Message().AddMessage(Model) > 0)
            {
                return Content("留言成功");
            }
            else 
            {
                return Content("留言失败");
            }
        }


        #endregion

        public ActionResult MessageDetail()
        {
            string NoticeID = ZGZY.Common.DNTRequest.GetQueryString("ID");
            if (NoticeID =="0" || NoticeID.Length == 0)
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }

            ZGZY.Model.Message msg = new ZGZY.Model.Message();
            if (NoticeID == "0" || NoticeID.Length == 0)
            {
                return View(msg);
            }
            else
            {
                msg = new ZGZY.BLL.Message().GetMessageModel(NoticeID);
                return View(msg);
            }
        }

        #endregion


    }
}
