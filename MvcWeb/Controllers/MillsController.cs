using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
namespace MvcWeb.Controllers
{
    /// <summary>
    /// 功能说明：矿机架构图
    /// 创建人员： 林红刚
    /// 创建日期： 2016/06/20
    /// 重制版人员：DeanWinchester
    /// </summary>
    public class MillsController : Controller
    {
        #region 系统安置图

        /// <summary>
        /// 页面启动
        /// </summary>
        /// <returns></returns>
        //int layCnt = 0;
        int maxLaycnt = 3;
        public ActionResult SetSystem()
        {
            string Userid=ZGZY.Common.LogionCookie.GetUserId();

            if (!string.IsNullOrEmpty(Request.Params["theAccId"]))
            {
                Userid = Request.Params["theAccId"].ToString();
            }

            ViewBag.theAccId = Userid;

            StringBuilder sb = new StringBuilder("");
            ViewData["SON"] = FindAllSon(Userid,0);
            //DataTable dt = new ZGZY.BLL.CustomerBL().GetList("  Person_Liable='" + Userid + "'").Tables[0];
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        sb.Append("<div class=\"line-v\"><span></span></div><div class=\"strt-block\">");                    	
	
            //        if (dt.Rows.Count > 1)//存在两个，HTML为左右线
            //        {
            //            string Left = "";
            //            string Right = "";
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                if (dt.Rows[i]["Region"].ToString() == "0")
            //                { 
            //                   //左边
            //                    Left += "<div class=\"strt-part\"><span class=\"line-h line-h-r\"></span><div class=\"line-v\"><span></span></div><span class=\"strt-name\">" + dt.Rows[i]["Nick_Name"] + "<br />中矿机<br />收益：2个</span>";
            //                        //<div class="line-v"><span></span></div> 继续循环下级使用
            //                   Left += "</div>";
            //                }else if (dt.Rows[i]["Region"].ToString() == "1")
            //                { 
            //                   //右边
            //                    Right += "<div class=\"strt-part\"><span class=\"line-h line-h-l\"></span><div class=\"line-v\"><span></span></div><span class=\"strt-name\">" + dt.Rows[i]["Nick_Name"] + "<br />大矿机<br />收益：3个</span>";
            //                        //<div class="line-v"><span></span></div> 继续循环下级使用
            //                    Right += "</div>";
            //                }
                            
            //            }
            //                sb.Append(Left).Append(Right);
            //        }
            //        else if (dt.Rows.Count == 1)//存在一个，HTML中线
            //        {
            //            sb.Append("<div class=\"strt-part\"><span class=\"strt-name\">" + dt.Rows[0]["Nick_Name"].ToString() + "</span></div>");
            //        }
            //        sb.Append("</div>");
            //    }
            //}
            //ViewData["SON"] = sb.ToString();
            return View();
        }



        public string FindAllSon(string Person_Liable,int layCnt)
        {
            StringBuilder sb = new StringBuilder("");
            DataTable dt = new ZGZY.BLL.CustomerBL().GetList("  Person_Liable='" + Person_Liable + "'").Tables[0];

            layCnt += 1;

            if (layCnt >= maxLaycnt)
            {
                //layCnt = 1;
                return "";
            }

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    sb.Append("<div class=\"line-v\"><span></span></div><div class=\"strt-block\">");

                    if (dt.Rows.Count > 1)//存在两个，HTML为左右线
                    {
                        string Left = "";
                        string Right = "";
                        
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataTable dt_sta =(DataTable) ZGZY.Common.SqlHelper.Query("exec sp_getTeamStatistics '" + dt.Rows[i]["login_Account"].ToString() + "' ").Tables[0];
                            string sSta = "";
                            if (dt_sta != null)
                            {
                                sSta = "<div>左矿机：" + dt_sta.Rows[0]["lm"].ToString() + "，业绩：" + dt_sta.Rows[0]["lIncome"].ToString() + "</div><div>右矿机：" + dt_sta.Rows[0]["rm"].ToString() + "，业绩：" + dt_sta.Rows[0]["rIncome"].ToString() + "</div>";
                            }
                            else
                            {
                                sSta = "";
                            }
                            if (dt.Rows[i]["Region"].ToString() == "0")
                            {
                                //左边
                                Left += "<div class=\"strt-part\"><span class=\"line-h line-h-r\"></span><div class=\"line-v\"><span></span></div><div><span class=\"strt-name\"><a href='javascript:void(0);' onclick=\"javascript:SubMenuItemClick(24,'安置系统图','业务管理','/Mills/SetSystem?theAccId=" + dt.Rows[i]["login_Account"] + "');\" >" + dt.Rows[i]["login_Account"] + "</a><br />" + ZGZY.BLL.BS_Machine.FinMachine(dt.Rows[i]["Login_Account"].ToString()) + sSta + "</span>" + "</div>";
                                DataTable dt_son = new ZGZY.BLL.CustomerBL().GetList("  Person_Liable='" + dt.Rows[i]["Login_Account"].ToString() + "'").Tables[0];
                                if (dt_son != null)
                                {
                                    if (dt_son.Rows.Count > 0)
                                    {
                                        Left += "<div class=\"line-v\"><span></span></div>"; // 继续循环下级使用
                                        Left += FindAllSon(dt.Rows[i]["Login_Account"].ToString(),layCnt);
                                    }
                                }
                                Left += "</div>";
                            }
                            else if (dt.Rows[i]["Region"].ToString() == "1")
                            {
                                //右边
                                Right += "<div class=\"strt-part\"><span class=\"line-h line-h-l\"></span><div class=\"line-v\"><span></span></div><div><span class=\"strt-name\"><a href='javascript:void(0);' onclick=\"javascript:SubMenuItemClick(24,'安置系统图','业务管理','/Mills/SetSystem?theAccId=" + dt.Rows[i]["login_Account"] + "');\" >" + dt.Rows[i]["login_Account"] + "</a><br />" + ZGZY.BLL.BS_Machine.FinMachine(dt.Rows[i]["Login_Account"].ToString()) + sSta + "</span>" + "</div>";
                                DataTable dt_son = new ZGZY.BLL.CustomerBL().GetList("  Person_Liable='" + dt.Rows[i]["Login_Account"].ToString() + "'").Tables[0];
                                if (dt_son != null)
                                {
                                    if (dt_son.Rows.Count > 0)
                                    {
                                        Right += "<div class=\"line-v\"><span></span></div>"; // 继续循环下级使用
                                        Right += FindAllSon(dt.Rows[i]["Login_Account"].ToString(),layCnt);
                                    }
                                }
                                Right += "</div>";
                            }

                        }
                        sb.Append(Left).Append(Right);
                    }
                    else if (dt.Rows.Count == 1)//存在一个，HTML中线
                    {
                        DataTable dt_sta = (DataTable)ZGZY.Common.SqlHelper.Query("exec sp_getTeamStatistics '" + dt.Rows[0]["login_Account"].ToString() + "' ").Tables[0];
                        string sSta = "";
                        if (dt_sta != null)
                        {
                            sSta = "<div>左矿机：" + dt_sta.Rows[0]["lm"].ToString() + "，业绩：" + dt_sta.Rows[0]["lIncome"].ToString() + "</div><div>右矿机：" + dt_sta.Rows[0]["rm"].ToString() + "，业绩：" + dt_sta.Rows[0]["rIncome"].ToString() + "</div>";
                        }
                        else
                        {
                            sSta = "";
                        }

                        sb.Append("<div class=\"strt-part\"><div><span class=\"strt-name\"><a href='javascript:void(0);' onclick=\"javascript:SubMenuItemClick(24,'安置系统图','业务管理','/Mills/SetSystem?theAccId=" + dt.Rows[0]["login_Account"] + "');\" >" + dt.Rows[0]["login_Account"] + "</a><br />" + ZGZY.BLL.BS_Machine.FinMachine(dt.Rows[0]["Login_Account"].ToString()) + sSta + "</span>" + "</div>");
                        DataTable dt_son = new ZGZY.BLL.CustomerBL().GetList("  Person_Liable='" + dt.Rows[0]["Login_Account"].ToString() + "'").Tables[0];
                        if (dt_son != null)
                        {
                            if (dt_son.Rows.Count > 0)
                            {
                                sb.Append("<div class=\"line-v\"><span></span></div>"); // 继续循环下级使用
                                sb.Append(FindAllSon(dt.Rows[0]["Login_Account"].ToString(),layCnt));
                            }
                        }
                        sb.Append("</div>");
                    }
                    sb.Append("</div>");
                }
            }
            return sb.ToString() ;
        }

        #endregion
    }
}
