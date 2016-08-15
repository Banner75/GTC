using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.Model;
using ZGZY.Common;
using ZGZY.BLL;

namespace MvcWeb.Controllers
{
    //[MvcWeb.App_Start.CalculationBonus]
    /// 重制版人员：DeanWinchester
    public class HomeController : Controller
    {
        #region 用户登录

        /// <summary>
        /// 登录窗口启动
        /// </summary>
        /// <returns></returns>
        //[MvcWeb.App_Start.CalculationBonus]
        public ActionResult Login()
        {
            string id=ZGZY.Common.LogionCookie.GetUserId();
            if(string.IsNullOrEmpty(id)){ return View();}
            BS_Customers m = new CustomerBL().GetCustomerByID(id);
            if (m == null)
            {
                ZGZY.Common.LogionCookie.DeleteVouCookie();
                return View();
            }
            else
            {
                return Content("<script>top.location.href='/home/index'</script>");
            }
        }

        /// <summary>
        /// 动作功能： 用户登录验证
        /// 编写人员： 林红刚
        /// 编写日期： 2016/06/11
        /// 重置版人员：DeanWinchester
        /// </summary>
        /// <returns></returns>
        public ActionResult DoLogin()
        {
            int res = 0;
            string mes = "";

            #region 输入验证

            string strAccount = (Request["acc"] == null) ? string.Empty : Convert.ToString(Request["acc"]);
            string strPassword = (Request["pwd"] == null) ? string.Empty : Convert.ToString(Request["pwd"]);
            string strCode = (Request["code"] == null) ? string.Empty : Convert.ToString(Request["code"]);

            if (string.IsNullOrWhiteSpace(strAccount))
            {
                res = 0;
                mes = "登录帐号空！";
                return Json(new { res = res, mes = mes });
            }

            if (string.IsNullOrWhiteSpace(strPassword))
            {
                res = 0;
                mes = "登录密码空！";
                return Json(new { res = res, mes = mes });
            }

            if (string.IsNullOrWhiteSpace(strCode))
            {
                res = 0;
                mes = "验证码为空！";
                return Json(new { res = res, mes = mes });
            }

            if (Session["ValidateCode"] == null)
            {
                res = 0;
                mes = "验证码错误,刷新后再登录！";
                return Json(new { res = res, mes = mes });
            }

            if (Session["ValidateCode"].ToString().ToLower() != strCode.Trim().ToLower())
            {
                res = 0;
                mes = "验证码错误！";
                return Json(new { res = res, mes = mes });
            }

            #endregion

            #region 用户身份验证

            string newPwd = ZGZY.Common.Md5.GetMD5String(strPassword);
            CustomerBL cbl = new CustomerBL();
            BS_Customers data = cbl.GetCustomerByUserNameAndPWD(strAccount, newPwd);
            if (data != null)
            {
                res = 1;
                mes = string.Empty;

                if (data.State > 1)
                {
                    res = 0;
                    return Json(new { res = res, mes = "此账号失效，不可登录" });
                }
                ViewBag.UserName = data.Truly_Name;
                ZGZY.Common.LogionCookie.WriteMutualCookie(data.Login_Account, data.Nick_Name);
                new CustomerBL().UpdatedLastDate(data.Login_Account);//最后登录时间
                // 读取用户列表信息
                //System.Web.HttpContext.Current.Session["userlist"] = data;

                return Json(new { res = res, mes = mes });
            }
            else
            {
                mes = "帐号或密码错误！";
                return Json(new { res = res, mes = mes });
            }

            #endregion
        }

        /// <summary>
        /// 动作功能： 用户登录验证
        /// 编写人员： 
        /// 编写日期： 2016/06/11
        /// 重置版人员：DeanWinchester
        /// </summary>
        /// <returns></returns>
        public ActionResult loginInSecuret()
        {
            int res = 0;
            string mes = "";

            #region 输入验证

            string strAccount = (Request["loginAccount"] == null) ? string.Empty : Convert.ToString(Request["loginAccount"]);
            string strPassword = (Request["loginPwd"] == null) ? string.Empty : Convert.ToString(Request["loginPwd"]);
//          string strCode = (Request["code"] == null) ? string.Empty : Convert.ToString(Request["code"]);

            if (string.IsNullOrWhiteSpace(strAccount))
            {
                res = 0;
                mes = "登录帐号空！";
                return Json(new { res = res, mes = mes });
            }

            if (string.IsNullOrWhiteSpace(strPassword))
            {
                res = 0;
                mes = "登录密码空！";
                return Json(new { res = res, mes = mes });
            }

            #endregion

            #region 用户身份验证

            string newPwd = strPassword; //ZGZY.Common.Md5.GetMD5String(strPassword);
            CustomerBL cbl = new CustomerBL();
            BS_Customers data = cbl.GetCustomerByUserNameAndPWD(strAccount, newPwd);
            if (data != null)
            {
                res = 1;
                mes = string.Empty;

                if (data.State > 1)
                {
                    res = 0;
                    return Json(new { res = res, mes = "此账号失效，不可登录" });
                }
                ViewBag.UserName = data.Truly_Name;
                ZGZY.Common.LogionCookie.WriteMutualCookie(data.Login_Account, data.Nick_Name);
                new CustomerBL().UpdatedLastDate(data.Login_Account);//最后登录时间
                // 读取用户列表信息
                //System.Web.HttpContext.Current.Session["userlist"] = data;
                return Content("<script>top.location.href='/home/index'</script>");
                //return Json(new { res = res, mes = mes });
            }
            else
            {
                mes = "帐号或密码错误！";
                return Content("<script>top.location.href='/home/login'</script>");
                //return Json(new { res = res, mes = mes });
            }

            #endregion
        }

        public ActionResult OutLogion()
        {
            ZGZY.Common.LogionCookie.DeleteVouCookie();
            return Content("<Script>location.href='/Home/Login'</script>");
        }
        #endregion

        #region 首页显示

        public ActionResult Index()
        {
            BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            
            if (ZGZY.Common.LogionCookie.GetUserId().Trim() == "" || data == null)
            {
                return Content("<Script>location.href='/Home/Login'</script>");
            }
            // 读取会员用户信息
            BS_Customers custData = (new CustomerBL()).GetCustomerByID(data.Login_Account);
            ViewBag.CustomerInfo = custData;
            DataTable Notices = new ZGZY.BLL.BS_Notices().GetList(5, "", " Created_Date desc").Tables[0];
            ViewBag.NoticeList = Notices;

            ZGZY.BLL.BS_DigIncomeDetail bllDig = new ZGZY.BLL.BS_DigIncomeDetail();

            decimal lastInCome = bllDig.GetBonus(custData.Login_Account, 1);
            ViewBag.LastInCome = lastInCome;
            ViewBag.GQty = custData.MRC;
            ViewBag.ORE = custData.ORE;
            ViewBag.TeamNumbers = (new CustomerBL()).getTeamNumbers(custData.Login_Account);

            ZGZY.BLL.BS_MRC_Wallet bllWallet = new ZGZY.BLL.BS_MRC_Wallet();
            ViewBag.PaySum=bllWallet.GetMRCPaySum(custData.Login_Account);
            
            ZGZY.BLL.BS_Configuration bllConfig=new ZGZY.BLL.BS_Configuration();
            ZGZY.Model.BS_Configuration mConfig=new ZGZY.Model.BS_Configuration();
            mConfig=bllConfig.GetModel(5);
            ViewBag.TodayPrice = mConfig.value;

            //读取用户矿机信息
            var CusMachineList=new ZGZY.BLL.BS_Machine().GetList(string.Format("status=2 and Login_Account='{0}'",custData.Login_Account,DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))).Tables[0];
            if (CusMachineList != null && CusMachineList.Rows.Count > 0)
            {
                ViewBag.CusMachineTable = CusMachineList;
                ViewBag.Count_Time =CusMachineList.Rows[0]["count_time"];
                ViewBag.Today_Count = CusMachineList.Rows[0]["today_count"].ToString();
                ViewBag.End_Run_Time = CusMachineList.Rows[0]["end_run_time"];
                ViewBag.DataNow = DateTime.Now;
            }
            else 
            {
                ViewBag.Count_Time = DateTime.Now;
                ViewBag.Today_Count = 0;
                ViewBag.DataNow = DateTime.Now;
                ViewBag.End_Run_Time = DateTime.Now;
            }

            // 读取公告信息(参数：数据类别，最新数量)
            //List<BS_Notices> noticeDatas = (new InformationBL()).GetNotices(Convert.ToInt32(Information_Notice.nmNotice), Constants.NEAREST_NOTICE_NUMS);


            return View();
        }

        public ActionResult Head()
        {
            return View();
        }

        /// <summary>
        /// 导航页面起始显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Left()
        {
            return View();
        }

        #endregion
    }
}
