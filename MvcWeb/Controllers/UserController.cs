using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.BLL;
using ZGZY.Common;
using ZGZY.Model;

namespace MvcWeb.Controllers
{
    /// 重制版人员：DeanWinchester
    public class UserController : BaseController
    {        
        #region 信息更新
        /// <summary>
        /// 信息更新
        /// </summary>
        /// <returns></returns>
        public ActionResult InfoEdit()
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            BS_Customers userFrom = new CustomerBL().GetCustomerByID(Userid);
            return View(userFrom);
        }


      
        public ActionResult SetInfo()
        {
            string ID = Request.Form["ID"];
            string nickname = Request.Form["nickname"];
            string sex = Request.Form["sex"];
            string cardnum = Request.Form["cardnum"];
            string Email = Request.Form["Email"];
            string mobile = Request.Form["mobile"];
            string bank = Request.Form["bank"];
            string bankuser = Request.Form["bankuser"];
            string banknum = Request.Form["banknum"];
            string alipay = Request.Form["alipay"];
            string bankname = Request.Form["bankname"];

            #region 验证
            if (string.IsNullOrEmpty(ID) || SqlInjection.GetString(ID))
            {
                 return Content("<script>alert('ID格式或不能为空');location.href='/User/InfoEdit';</script>");
            }

            /*
            if (string.IsNullOrEmpty(nickname) || SqlInjection.GetString(nickname))
            {
                  return Content("<script>alert('昵称格式或不能为空');location.href='/User/InfoEdit';</script>");
            }
             * */
            if (string.IsNullOrEmpty(sex) || SqlInjection.GetString(sex))
            {
                 return Content("<script>alert('性别格式或不能为空');location.href='/User/InfoEdit';</script>");
            }
            if (!Validator.IsNumber(cardnum) || !Validator.IsIDCard18(cardnum))
            {
                
                 return Content("<script>alert('证件号码格式或不能为空');location.href='/User/InfoEdit';</script>");
            }
            if (string.IsNullOrEmpty(Email) || SqlInjection.GetString(Email) ||!Validator.IsEmail(Email))
            {

                  return Content("<script>alert('邮件格式或不能为空');location.href='/User/InfoEdit';</script>");
            }

            if (string.IsNullOrEmpty(mobile) || SqlInjection.GetString(mobile) || !Validator.IsMobile(mobile))
            {
                
                 return Content("<script>alert('移动电话格式或不能为空');location.href='/User/InfoEdit';</script>");
            }
            if (string.IsNullOrEmpty(bank) || SqlInjection.GetString(bank))
            {
               
                 return Content("<script>alert('开户银行格式或不能为空');location.href='/User/InfoEdit';</script>");
            }
            if (string.IsNullOrEmpty(bankuser) || SqlInjection.GetString(bankuser))
            {
               
                  return Content("<script>alert('开户名格式或不能为空');location.href='/User/InfoEdit';</script>");
            }
            if (string.IsNullOrEmpty(banknum) || SqlInjection.GetString(banknum)||!Validator.IsNumber(banknum))
            {
                 return Content("<script>alert('银行卡号格式或不能为空');location.href='/User/InfoEdit';</script>");
             
            }
            if (string.IsNullOrEmpty(bankname) || SqlInjection.GetString(bankname) || !Validator.IsOnllyChinese(bankname))
            {
                return Content("<script>alert('开户分行格式或不能为空');location.href='/User/InfoEdit';</script>");
               
            }
            if (string.IsNullOrEmpty(alipay) || SqlInjection.GetString(alipay)||!Validator.IsNotChinese(alipay))
            {
                return Content("<script>alert('支付宝账号格式或不能为空');location.href='/User/InfoEdit';</script>");
            }
            #endregion

            ZGZY.BLL.CustomerBL Userlist=new ZGZY.BLL.CustomerBL ();
            BS_Customers UserlistModel=Userlist.GetCustomerByID(ID);
            UserlistModel.Login_Account = nickname;
            UserlistModel.Nick_Name = nickname;
            UserlistModel.Sex = Convert.ToInt32(sex);
            UserlistModel.Card_No = cardnum;
            UserlistModel.Email= Email;
            UserlistModel.Mobile = mobile;
            UserlistModel.Bank = bank;
            UserlistModel.Bank_User = bankuser;
            UserlistModel.Bank_Account = banknum;
            UserlistModel.Alipay = alipay;
            UserlistModel.Bank_Branch = bankname;
            if(Userlist.Update(UserlistModel) > 0)
            {
                return Content("<script>alert('更新成功');location.href='/User/InfoEdit';</script>");
            }
            else
            {
                 return Content("<script>alert('更新失败请联系管理员');location.href='/User/InfoEdit';</script>");
            }
         
          
        } 
        #endregion

        #region 查看矿机
        /// <summary>
        /// 查看矿机
        /// </summary>
        /// <returns></returns>
        public ActionResult miner()
        {
            return View();
        } 
        #endregion

        #region 我的佣金
        /// <summary>
        /// 我的佣金
        /// </summary>
        /// <returns></returns>
        public ActionResult Commission()
        {
            return View();
        } 
        #endregion

        #region 审核记录
        /// <summary>
        /// 审核记录
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckLog()
        {
            return View();
        } 
        #endregion

        #region 注册审核
        /// <summary>
        /// 注册审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Check()
        {
            return View();
        } 
        #endregion

        #region 升级账户
        /// <summary>
        /// 升级账户
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateType()
        {
            return View();
        } 
        #endregion

        #region 注册新矿主

        /// <summary>
        /// 注册新矿主
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Registerfrom()
        {
            string loginAccount = (Request["loginaccount"] == null) ? "" : Request["loginaccount"].ToString();
            string userGrade = (Request["usergrade"] == null) ? "" : Request["usergrade"].ToString();
            string indirectParent = (Request["indirectparent"] == null) ? "" : Request["indirectparent"];
            string nickName = (Request["nickname"] == null) ? "" : Request["nickname"];
            int sex = (Request["sex"] == null) ? 0 : Convert.ToInt32(Request["sex"]);
            string cardNo = (Request["cardno"] == null) ? "" : Request["cardno"].ToString();
            string email = (Request["email"] == null) ? "" : Request["email"].ToString();
            string mobile = (Request["mobile"] == null) ? "" : Request["mobile"].ToString();
            string bank = (Request["bank"] == null) ? "" : Request["bank"].ToString();
            string bankUser = (Request["bankuser"] == null) ? "" : Request["bankuser"].ToString();
            string bankAccount = (Request["bankaccount"] == null) ? "" : Request["bankaccount"].ToString();
            string bankBranch = (Request["bankbranch"] == null) ? "" : Request["bankbranch"].ToString();
            string alipay = (Request["alipay"] == "") ? "" : Request["alipay"].ToString();
           
           // 准备提交数据到数据库
           BS_Customers data = new BS_Customers();
           data.Login_Account = loginAccount;
           data.Parent = indirectParent;                                                   //间接父级会员

           
           data.Nick_Name = nickName;                                                               // 昵称
           data.Sex = Convert.ToInt32(sex);                                                        // 性别
           data.Card_No = cardNo;                                                                   // 证件号码
           data.Email = email;                                                                     // 邮件 
           data.Mobile = mobile;                                                                   // 移动电话
           data.Bank = bank;                                                                       // 开户银行
           data.Bank_User = bankUser;                                                               // 开户名
           data.Bank_Account = bankAccount;                                                         // 银行卡号
           data.Bank_Branch = bankBranch;                                                           // 开户分行
           data.Alipay = alipay;                                                                   // 支付宝账号
           data.Register_Date = DateTime.Now; ;                                                      // 注册时间
           data.Login_PWD = ZGZY.Common.Md5.GetMD5String("123456");                                  // 登录密码
           data.Pay_PWD = ZGZY.Common.Md5.GetMD5String("123456");                                    // 支付密码

           if (new ZGZY.BLL.CustomerBL().Insert(data) > 0)
           {
               return Content("{\"msg\":\"添加成功！\",\"success\":true}");
           }
           else
           {
               return Content("{\"msg\":\"添加失败！请联系网站管理人员\",\"success\":false}");
           }
        } 

        #endregion

        #region 更改密码
        /// <summary>
        /// 更改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Setpwd()
        {
            return View();
        }


        public ActionResult Setpwdform()
        {
            string loginpwd = Request.Form["loginpwd"];
            string reloginpwd = Request.Form["reloginpwd"];
            string paypwd = Request.Form["paypwd"];
            string repaypwd = Request.Form["repaypwd"];
            BS_Customers Setpwdform = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            if (string.IsNullOrEmpty(loginpwd) || SqlInjection.GetString(loginpwd))
            {
                return Content("{\"msg\":\"原一级密码不能为空或非法参数！\",\"success\":false}");
            }
            if (string.IsNullOrEmpty(reloginpwd) || SqlInjection.GetString(reloginpwd))
            {
                return Content("{\"msg\":\"一级新密码不能为空或非法参数！\",\"success\":false}");
            }
            if (string.IsNullOrEmpty(paypwd) || SqlInjection.GetString(paypwd))
            {
                return Content("{\"msg\":\"原二级密码不能为空或非法参数！\",\"success\":false}");
            }
            if (string.IsNullOrEmpty(repaypwd) || SqlInjection.GetString(repaypwd))
            {
                return Content("{\"msg\":\"二级新密码不能为空或非法参数！\",\"success\":false}");
            }
            if (Setpwdform.Login_PWD != ZGZY.Common.Md5.GetMD5String(loginpwd))
            {
                return Content("{\"msg\":\"原一级密码错误！\",\"success\":false}");
            }
            if (!ZGZY.Common.Validator.IsNotChinese(loginpwd) || loginpwd.Length<6)
            {
                return Content("{\"msg\":\"新一级密码必须至少六位英文加数字！\",\"success\":false}");
            }
            if (Setpwdform.Pay_PWD != ZGZY.Common.Md5.GetMD5String(paypwd))
            {
                return Content("{\"msg\":\"原二级密码错误！\",\"success\":false}");
            }
            if (!ZGZY.Common.Validator.IsNotChinese(paypwd) || paypwd.Length < 6)
            {
                return Content("{\"msg\":\"新二级密码必须至少六位英文加数字！\",\"success\":false}");
            }

            Setpwdform.Login_PWD = ZGZY.Common.Md5.GetMD5String(reloginpwd);
            Setpwdform.Pay_PWD = ZGZY.Common.Md5.GetMD5String(repaypwd);
            if ((new ZGZY.BLL.CustomerBL().Update(Setpwdform)) > 0)
            {
                System.Web.HttpContext.Current.Session.RemoveAll();
                return Content("{\"msg\":\"修改成功！\",\"success\":true}");
            }
            else
            {
                return Content("{\"msg\":\"更新失败请联系管理人员！\",\"success\":false}");
            }
        } 
        #endregion

        #region BT
        /// <summary>
        /// BT
        /// </summary>
        /// <returns></returns>
        public ActionResult BTIndex()
        {
            return View();
        } 
        #endregion

        #region BT1
        /// <summary>
        /// BT1
        /// </summary>
        /// <returns></returns>
        public ActionResult BT1Index()
        {
            return View();
        } 
        #endregion

        #region BT2
        /// <summary>
        /// BT2
        /// </summary>
        /// <returns></returns>
        public ActionResult BT2Index()
        {
            return View();
        } 
        #endregion

        #region GT
        /// <summary>
        /// GT
        /// </summary>
        /// <returns></returns>
        public ActionResult GTIndex()
        {
            return View();
        } 
        #endregion

        #region GT1
        /// <summary>
        /// GT1
        /// </summary>
        /// <returns></returns>
        public ActionResult GT1Index()
        {
            return View();
        } 
        #endregion

        #region 我的GD2Log
        /// <summary>
        /// 我的GD2Log
        /// </summary>
        /// <returns></returns>
        public ActionResult GD2Log()
        {
            return View();
        } 
        #endregion

        #region 我的GD1Log
        /// <summary>
        /// 我的GD1Log
        /// </summary>
        /// <returns></returns>
        public ActionResult GD1Log()
        {
            return View();
        } 
        #endregion

        #region GD预约订单列表
        /// <summary>
        /// GD预约订单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BookGD()
        {
            return View();
        } 
        #endregion


        #region  BT购买记录
        /// <summary>
        /// BT购买记录
        /// </summary>
        /// <returns></returns>
        public ActionResult BybtLog()
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
            DataTable BTtransactionsontable = new ZGZY.BLL.BTtransactionson().GetBTtransactionsonPager("View_BTtransactionson", "*", "addtime  desc", 10, pageindex, "buyuserID='" + ZGZY.Common.LogionCookie.GetUserId() + "'", out totalCount);
            string pagination = new ZGZY.BLL.BTtransactionson().GetBTtransactionsonpagination(totalCount, 10, pageindex, "/User/BybtLog");
            ViewBag.pagination = pagination;
            return View(BTtransactionsontable);
        } 
        #endregion

        #region BT卖记录
        /// <summary>
        /// BT卖记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowbtLog()
        {
            return View();
        } 
        #endregion

        #region  BT账户转账
        /// <summary>
        /// BT账户转账
        /// </summary>
        /// <returns></returns>
        public ActionResult BTturn()
        {
            return View();
        } 
        #endregion

       


        #region  BT1账户转账
        /// <summary>
        /// BT1账户转账
        /// </summary>
        /// <returns></returns>
        public ActionResult BT1turn()
        {
            return View();
        } 
        #endregion

        #region BT2账户转账
        /// <summary>
        /// BT2账户转账
        /// </summary>
        /// <returns></returns>
        public ActionResult BT2turn()
        {
            return View();
        } 
        #endregion

        #region GT账户转账
        /// <summary>
        /// GT账户转账
        /// </summary>
        /// <returns></returns>
        public ActionResult GTturn()
        {
            return View();
        } 
        #endregion

    }
}
