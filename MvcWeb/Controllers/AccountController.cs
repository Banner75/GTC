using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.Model;
using ZGZY.BLL;
using ZGZY.Common;
namespace MvcWeb.Controllers
{
    /// <summary>
    /// 功能说明：帐户管理
    /// 创建人员：林 红 刚
    /// 创建时间：2016/06/20
    /// 重制版人员：DeanWinchester
    /// </summary>
    public class AccountController : BaseController
    {
        #region 私有方法

        /// <summary>
        /// 检查帐号安全等级
        /// 返回值，0:低； 1：中； 2：高；
        /// 密码安全问题，手机绑定，邮箱绑定，1个或以下为低，2个为中，3个为高
        /// </summary>
        /// <param name="loginAccount"></param>
        /// <returns></returns>
        public int CheckAccountSafeGrade(string loginAccount)
        {
            int result = 0;
            int count = 0;

            BS_Customers newData = (new CustomerBL()).GetSafeAccountInfo(loginAccount);

            if (newData != null)
            {
                if (!string.IsNullOrWhiteSpace(newData.Email.Trim()))
                {
                    count++;
                }

                if (!string.IsNullOrWhiteSpace(newData.Mobile.Trim()))
                {
                    count++;
                }
            }

            List<BS_Safe_Problems> safeDatas = (new CustomerBL()).GetSafeProblems(loginAccount);
            if (safeDatas != null && safeDatas.Count > 0)
            {
                count++;
            }

            if (count <= 1)
            {
                result = 0;
            }
            else if (count == 2)
            {
                result = 1;
            }
            else if (count == 3)
            {
                result = 2;
            }

            return result;
        }

        /// <summary>
        /// 检查密码设置难易程度
        /// 0：低；1：高
        /// </summary>
        /// <param name="loginAccount"></param>
        /// <returns></returns>
        public int CheckTradePwdResult(string loginAccount)
        {
            return 0;
        }

        #endregion

        #region 账户安全中心

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult SafeCenter()
        {
            // 读取用户手机号和邮箱
            BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            string loginAccount = data.Login_Account;

            // 用户账号安全等级
            var AccountSafeGrade = CheckAccountSafeGrade(loginAccount);

            // 交易密码简易结果
            var TradePwdResult = CheckTradePwdResult(loginAccount);

            ViewBag.AccountSafeGrade = AccountSafeGrade;
            ViewBag.TradePwdResult = TradePwdResult;

            // 根据帐号读取帐号安全信息
            BS_Customers newData = (new CustomerBL()).GetSafeAccountInfo(loginAccount);
            ViewBag.MySafeAccount = newData;

            // 根据帐号读取帐号安全问题信息
            List<BS_Safe_Problems> safeDatas = (new CustomerBL()).GetSafeProblems(loginAccount);
            ViewBag.SafeProblemList = safeDatas;


            return View();
        }

        #endregion

        #region 我的祥细资料

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult MyDetailData()
        {
           
            BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            if (data != null)
            {
                string account = data.Login_Account;
                BS_Customers newData = (new CustomerBL()).GetCustomerByID(account);
                ViewBag.CustomerList = newData;
            }

            return View();
        }

        /// <summary>
        /// 帐号名字
        /// </summary>
        /// <returns></returns>
        public ActionResult getBankUser(string loginAccount)
        {
            string bankUser = "";

            if (loginAccount == null)
            {
                loginAccount = Request.Params["loginAccount"].ToString();
            }

            BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(loginAccount);
            if (data != null)
            {
                bankUser = data.Bank_User;
            }

            return Content("{\"BankUser\":\"" + bankUser +"\"}");
        }

        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditMyDetail()
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            if (string.IsNullOrEmpty(Userid)) { return JsonValues(1, "登录状态失效，请重新登录!"); }
            ZGZY.Model.BS_Customers m = new CustomerBL().GetCustomerByID(Userid);
            if (m == null) { return JsonValues(1, "登录状态失效，请重新登录!"); }

            string nickname = DNTRequest.GetFormString("n");
            string TrulyName = DNTRequest.GetFormString("t");
            //string Email = DNTRequest.GetFormString("em");
            string Mobile = DNTRequest.GetFormString("m");
            string BankUser = DNTRequest.GetFormString("bu");
            string BankAccount = DNTRequest.GetFormString("ba");
            string BankBranch = DNTRequest.GetFormString("bb");
            string Alipay = DNTRequest.GetFormString("al");
            string Bank = DNTRequest.GetFormString("bk");
            int sex = DNTRequest.GetFormInt("s",3);

            #region 参数检测
            if (
                string.IsNullOrEmpty(BankUser) ||
                string.IsNullOrEmpty(BankAccount) || string.IsNullOrEmpty(BankBranch) ||
                string.IsNullOrEmpty(Alipay) || string.IsNullOrEmpty(Bank)                
                ) { return JsonValues(1, "不可为空！"); }

            //if (!ZGZY.Common.Validator.IsOnllyChinese(TrulyName)) { return JsonValues(1, "真实姓名只能是汉字！"); }
            //if (!ZGZY.Common.Validator.IsEmail(Email)) { return JsonValues(1, "请输入真实的邮箱地址！"); }
            //if (!ZGZY.Common.Validator.IsMobile(Mobile)) { return JsonValues(1, "请输入真实的手机号码！"); }
            #endregion

            m.Alipay = Alipay;
            m.Bank = Bank;
            m.Bank_Account = BankAccount;
            m.Bank_Branch = BankBranch;
            m.Bank_User = BankUser;
           // m.Email = Email;
            m.Mobile = Mobile;
            m.Sex = sex;
            m.Nick_Name = nickname;
            m.Truly_Name = TrulyName;

            if (new CustomerBL().Update(m)>0)
            {
               return JsonValues(0, "修改成功");
            }

            return JsonValues(1, "修改失败");
        }

        #endregion

        #region 修改查询密码

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult EditQueryPwd(int kind)
        {
            BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            ViewBag.LoginAccount = data;
            if (kind == Convert.ToInt32(ZGZY.Common.Account_Pwd_Kind.nmQueryPwd))
            {
                ViewBag.PWDKind = kind;
                ViewBag.Title = ZGZY.Common.Constants.QUERY_PWD_MODIFY;
            }
            else if (kind == Convert.ToInt32(ZGZY.Common.Account_Pwd_Kind.nmPayPwd))
            {
                ViewBag.PWDKind = kind;
                ViewBag.Title = ZGZY.Common.Constants.PAY_PWD_MODIFY;
            }

           

            return View();

        }

        public ActionResult DoCheckOldPwd(int kind, string oldPwd)
        {
            int res = 1;
            string mes = "";
            BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            

            return Json( new { res = res, mes = mes});
        }

        public ActionResult DoModifyPwd(int kind,  string oldPwd,string pwd)
        {
            int res = 1;
            string mes = "修改失败!";
            if (string.IsNullOrEmpty(oldPwd))
            {
                res = 0;
                mes = "旧密码不能为空，请重新输入！";
                return Json(new { res = res, mes = mes });
            }
            if (string.IsNullOrEmpty(pwd))
            {
                res = 0;
                mes = "新密码不能为空，请重新输入！";
                return Json(new { res = res, mes = mes });
            }
            BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            string dbPwd = (new CustomerBL()).CheckOldPwd(kind, data.Login_Account);
            if (string.IsNullOrEmpty(dbPwd)) { res = 0; mes = "旧密码不对，请重新输入！"; }
            string md5_oldpwd = ZGZY.Common.Md5.GetMD5String((oldPwd.Trim())).ToLower();
            if (!dbPwd.Trim().ToLower().Equals(md5_oldpwd.Trim()))
            {
                res = 0;
                mes = "旧密码不对，请重新输入！";
                return Json(new { res = res, mes = mes });
            }
            pwd = ZGZY.Common.Md5.GetMD5String(pwd);
            if (kind == 1)
            {
                res = new ZGZY.BLL.CustomerBL().UpdateQueryPwd(pwd, data.Login_Account);
            }
            else
            {
                res = new ZGZY.BLL.CustomerBL().UpdatePayPwd(pwd, data.Login_Account);                
            }
            if (res > 0) { mes = ""; }
            return Json(new { res = res, mes = mes });
        }
        #endregion

        #region 修改交易密码

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult EditTradePwd()
        {
            return View();
        }

        #endregion
    }
}
