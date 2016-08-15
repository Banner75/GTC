using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.BLL;
using ZGZY.Model;

namespace MvcWeb.Controllers
{
    /// <summary>
    /// 功能说明：业务管理
    /// 创建人员：林 红 刚
    /// 创建日期：2016/06/20
    /// 重制版人员：DeanWinchester
    /// </summary>
    public class BusinessController : BaseController
    {
        private Random rm = new Random();


        #region 注册新矿主

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 接收并保存注册信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoRegister()
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            if (string.IsNullOrEmpty(Userid)) { return JsonValues(1, "登录状态失效，请重新登录!"); }
            ZGZY.Model.BS_Customers m = new CustomerBL().GetCustomerByID(Userid);
            if (m == null) { return JsonValues(1, "登录状态失效，请重新登录!"); }

            string loginAccount = ZGZY.Common.DNTRequest.GetFormString("loginaccount"); ;
            string Personliable = ZGZY.Common.DNTRequest.GetFormString("Personliable");
            //int Region = ZGZY.Common.DNTRequest.GetFormInt("Region", 0);
            string nickName = ZGZY.Common.DNTRequest.GetFormString("nickname");
            //int sex = ZGZY.Common.DNTRequest.GetFormInt("sex", 0);
            // string cardNo = (Request["cardno"] == null) ? "" : Request["cardno"].ToString();
            string email = ZGZY.Common.DNTRequest.GetFormString("email");
            string mobile = ZGZY.Common.DNTRequest.GetFormString("mobile");
            string bank = ZGZY.Common.DNTRequest.GetFormString("bank");
            string bankUser = ZGZY.Common.DNTRequest.GetFormString("bankuser");
            string bankAccount = ZGZY.Common.DNTRequest.GetFormString("bankaccount");
            string bankBranch = ZGZY.Common.DNTRequest.GetFormString("bankbranch");
            string alipay = ZGZY.Common.DNTRequest.GetFormString("alipay");

            #region 参数检测,邮箱，手机是否重复，是否有SQL注入嫌疑
            if (string.IsNullOrEmpty(loginAccount)) { return Json(new { res = 0, mes = "用户名不能为空！" }); }
            //if (string.IsNullOrEmpty(nickName)) { return Json(new { res = 0, mes = "昵称不能为空！" }); }
            //if (string.IsNullOrEmpty(email)) { return Json(new { res = 0, mes = "邮箱不能为空！" }); }
            //if (!ZGZY.Common.Validator.IsEmail(email)) { return Json(new { res = 0, mes = "邮箱格式错误！" }); }
            if (string.IsNullOrEmpty(mobile)) { return Json(new { res = 0, mes = "手机号不能为空！" }); }
            if (!ZGZY.Common.Validator.IsMobile(mobile)) { return Json(new { res = 0, mes = "手机号格式错误！" }); }
            if (string.IsNullOrEmpty(bank)) { return Json(new { res = 0, mes = "请选择银行！" }); }
            if (string.IsNullOrEmpty(bankUser)) { return Json(new { res = 0, mes = "开户人不能为空！" }); }
            if (string.IsNullOrEmpty(bankAccount)) { return Json(new { res = 0, mes = "银行卡号不能为空！" }); }
            if (string.IsNullOrEmpty(bankBranch)) { return Json(new { res = 0, mes = "开户行不能为空！" }); }
            //if (string.IsNullOrEmpty(alipay)) { return Json(new { res = 0, mes = "支付宝不能为空！" }); }
            if (ZGZY.Common.SqlInjection.GetString(loginAccount) || ZGZY.Common.SqlInjection.GetString(nickName) || ZGZY.Common.SqlInjection.GetString(bank) || ZGZY.Common.SqlInjection.GetString(bankUser) || ZGZY.Common.SqlInjection.GetString(bankAccount) || ZGZY.Common.SqlInjection.GetString(bankBranch) || ZGZY.Common.SqlInjection.GetString(alipay))
            { return Json(new { res = 0, mes = "资料中含有危险字符，请检查后提交！" }); }
            if (new CustomerBL().Exists(loginAccount)) { return Json(new { res = 0, mes = "用户名已存在！" }); }
            //if (new CustomerBL().ExistsEmail(email)) { return Json(new { res = 0, mes = "邮箱已存在！" }); }
            //if (new CustomerBL().ExistsMobile(mobile)) { return Json(new { res = 0, mes = "手机号已存在！" }); }
            #endregion

            #region 判断手机号最多注册两个
            DataTable Checkmobile = new CustomerBL().GetList(" mobile='" + mobile + "'").Tables[0];
            if (Checkmobile != null)
            {
                if (Checkmobile.Rows.Count == 3)
                {
                    return Json(new { res = 0, mes = "每个手机号最多只能注册三个会员！" });
                }
            }
            #endregion

            #region 判断上级会员是否有邀请过会员邀请超过2个会员后就不可以继续邀请
            DataTable dt = new CustomerBL().GetList(" Parent='" + m.Login_Account + "'").Tables[0];
            #endregion
            // 准备提交数据到数据库
            BS_Customers data = new BS_Customers();
            //区域
            if (dt != null)
            {
                if (dt.Rows.Count == 0) { data.Region = 0; }
                else if (dt.Rows.Count == 1) { data.Region = 1; }
                else if (dt.Rows.Count == 2)
                {
                    if (string.IsNullOrEmpty(Personliable))
                    {
                        return Json(new { res = 0, mes = "推荐名额已满，请安排责任人！" });
                    }
                }
            }
            if (!string.IsNullOrEmpty(Personliable))
            {
                if (Personliable == m.Login_Account) { return Json(new { res = 0, mes = "责任人不可以是自己！" }); }
                if (!new CustomerBL().Exists(Personliable)) { return Json(new { res = 0, mes = "责任人不存在,请核对信息！" }); }

                #region 判断责任人是否为我团队里面的人
                int true_team = 0; //0：不是团队的人，1：是团队的人
                ArrayList dt_sonlist = new CustomerBL().GetSonLists(m.Login_Account);
                for (int i = 0; i < dt_sonlist.Count; i++)
                {
                    if (dt_sonlist[i].ToString() == Personliable)
                    {
                        true_team = 1;
                        break;
                    }
                    continue;
                }
                if (true_team == 0) { return Json(new { res = 0, mes = "责任人必须是团队里的人！" }); }

                #endregion

                ZGZY.Model.BS_Machine mPerson = new ZGZY.Model.BS_Machine();
                mPerson = new ZGZY.BLL.BS_Machine().GetMachineByAccount(Personliable);
                if (mPerson == null)
                {
                    return Json(new { res = 0, mes = "此责任人未租赁矿机，请重新安排！" });
                }

                DataTable dt_son = new CustomerBL().GetList(" Person_Liable='" + Personliable + "'").Tables[0];
                if (dt_son != null)
                {
                    if (dt_son.Rows.Count == 2)
                    {
                        return Json(new { res = 0, mes = "此责任人名额已满，请重新安排！" });
                    }
                    if (dt_son.Rows.Count == 0) { data.Region = 0; }
                    if (dt_son.Rows.Count == 1) { data.Region = 1; }
                    data.Person_Liable = Personliable;
                }
            }
            else
            {
                ZGZY.Model.BS_Machine myMachine = new ZGZY.BLL.BS_Machine().GetMachineByAccount(m.Login_Account);
                if (myMachine == null)
                {
                    return Json(new { res = 0, mes = "您未租赁矿机，请重购买后再进行新会员的注册！" });
                }
                data.Person_Liable = m.Login_Account;
                DataTable dt_son = new CustomerBL().GetList(" Person_Liable='" + m.Login_Account + "'").Tables[0];
                if (dt_son != null)
                {
                    if (dt_son.Rows.Count == 2)
                    {
                        return Json(new { res = 0, mes = "此责任人名额已满，请重新安排！" });
                    }
                    if (dt_son.Rows.Count == 0) { data.Region = 0; }
                    if (dt_son.Rows.Count == 1) { data.Region = 1; }
                }

            }
            data.Login_Account = loginAccount;
            data.Parent = m.Login_Account;
            data.Nick_Name = nickName;                                                                // 昵称
            data.Email = email;                                                                       // 邮件 
            data.Mobile = mobile;                                                                     // 移动电话
            data.Bank = bank;                                                                         // 开户银行
            data.Bank_User = bankUser;                                                                // 开户名
            data.Bank_Account = bankAccount;                                                          // 银行卡号
            data.Bank_Branch = bankBranch;                                                            // 开户分行
            data.Alipay = alipay;                                                                     // 支付宝账号
            data.Register_Date = DateTime.Now; ;                                                      // 注册时间            
            data.Login_PWD = ZGZY.Common.Md5.GetMD5String("123456");                                  // 登录密码
            data.Pay_PWD = ZGZY.Common.Md5.GetMD5String("123456");                                    // 支付密码

            int result = new ZGZY.BLL.CustomerBL().Insert(data);

            if (result > 0)
            {
                #region 短信接口
                ZGZY.Common.PhoneCode.SendMessage(data.Mobile, "【高特币】恭喜您成功注册会员！请登录www.gotter.cc　帐号" + loginAccount + "密码123456并及时修改密码完善账户信息");
                #endregion

                return Json(new { res = 1, mes = "" });
            }
            else
            {
                return Json(new { res = 0, mes = "会员注册失败！" });
            }
        }
        #endregion

        #region 我的矿机
        /// <summary>
        /// 查看矿机信息
        /// </summary>
        /// <returns></returns>
        public ActionResult MyMachine()
        {
            
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            if (string.IsNullOrEmpty(Userid)) { return JsonValues(1, "登录状态失效，请重新登录!"); }
            ZGZY.Model.BS_Customers m = new CustomerBL().GetCustomerByID(Userid);
            if (m == null) { return JsonValues(1, "登录状态失效，请重新登录!"); }

            var MyMachine = new ZGZY.BLL.BS_Machine().GetList(string.Format("Login_Account='{0}'", m.Login_Account)).Tables[0];
            if (MyMachine != null && MyMachine.Rows.Count > 0)
            {
                ViewBag.MyMachine = MyMachine;
                ViewBag.Cus = m;
                ViewBag.Userid = m.Login_Account;
            }
            return View();
        }
        #endregion

        #region 购买新矿机
        /// <summary>
        /// 购买新矿机
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BuyMachine()
        {
            string type = Request.Form["type"].ToString();

            #region 校验

            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            if (string.IsNullOrEmpty(Userid)) { return JsonValues(1, "登录状态失效，请重新登录!"); }
            ZGZY.Model.BS_Customers m = new CustomerBL().GetCustomerByID(Userid);
            if (m == null) { return JsonValues(1, "登录状态失效，请重新登录!"); }
            if (string.IsNullOrWhiteSpace(type))
            {
                return JsonValues(1, "请选择矿机!");
            }
            var MyMachine = new ZGZY.BLL.BS_Machine().GetList(string.Format("Login_Account='{0}'", m.Login_Account)).Tables[0];
            if (MyMachine != null && MyMachine.Rows.Count > 0)
            {
                return JsonValues(1, "已有矿机！无法购买！");
            }
            var MachineType = new ZGZY.BLL.BS_MachineConfig().GetModel(ZGZY.Common.TypeConverter.StrToInt(type, 0));
            if (MachineType == null)
            {
                return JsonValues(1, "没有此矿机类型！");
            }
            if (m.MRC +m.cAmt < MachineType.MachinePrice)
            {
                return JsonValues(1, "高特币不足！无法购买！");
            }

            #endregion

            #region 添加
            
            int types = ZGZY.Common.TypeConverter.StrToInt(type, 0);
            string Login_Account = m.Login_Account;
            DateTime start_run_time = DateTime.Now;
            DateTime end_run_time = DateTime.Now.AddDays(MachineType.Tenancy);
            int MachinePrice = MachineType.MachinePrice;
            int TodayCount = rm.Next(MachineType.MinProfit,MachineType.MaxProfit+1)+m.OtherOREBonus;
            string Remark = string.Format("购买新矿机，矿机类型为：{0}，消耗高特币：{1}", MachineType.MachineName, MachineType.MachinePrice);
            int result=new ZGZY.BLL.BS_Machine().BuyMachine(types, Login_Account, start_run_time, end_run_time, MachinePrice, Remark,TodayCount);
            if (result == 0) 
            {
                //成功
                return JsonValues(0, "租赁成功!");
            }
            else if (result > 0)
            {
                //参数错误
                return JsonValues(1, "租赁失败!");
            }
            else 
            {
                //参数错误
                return JsonValues(1, "租赁失败!");
            }
            
            #endregion
        }

        #endregion

        #region 续租矿机
        /// <summary>
        /// 续租矿机
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult KeepMachine()
        {
            var MachineID = Request.Form["ID"].ToString();
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            if (string.IsNullOrEmpty(Userid)) { return JsonValues(1, "登录状态失效，请重新登录!"); }
            ZGZY.Model.BS_Customers m = new CustomerBL().GetCustomerByID(Userid);
            if (m == null) { return JsonValues(1, "登录状态失效，请重新登录!"); }

            #region 校验
            var MachineModel = new ZGZY.BLL.BS_Machine().GetModel(ZGZY.Common.TypeConverter.StrToInt(MachineID, 0));
            if (MachineModel == null) { return JsonValues(1, "找不到此矿机！"); }
            if (MachineModel.Login_Account != m.Login_Account) { return JsonValues(1, "续租失败！请联系管理员！"); }
            var MachineTypeModel = new ZGZY.BLL.BS_MachineConfig().GetModel(MachineModel.type);
            if (MachineTypeModel == null) { return JsonValues(1, "此矿机类型已被删除！请联系管理员！"); }
            if (m.MRC + m.cAmt < MachineTypeModel.MachinePrice) { return JsonValues(1, "高特币不足！无法续租！"); }

            #endregion


            DateTime EndTime = new DateTime();
            DateTime StartTime = new DateTime();
            DateTime Count_Time = new DateTime();
            if (MachineModel.end_run_time <= DateTime.Now)//判断是否已经过期
            {
                StartTime = DateTime.Now;
                EndTime = DateTime.Now.AddDays(MachineTypeModel.Tenancy);
                Count_Time = DateTime.Now;

            }
            else
            {
                StartTime = MachineModel.start_run_time;
                EndTime = MachineModel.end_run_time.AddDays(MachineTypeModel.Tenancy);
                Count_Time = MachineModel.count_time;
            }
            
            MachineModel.start_run_time = StartTime;
            MachineModel.end_run_time = EndTime;
            MachineModel.status = 2;
            m.MRC = m.MRC - MachineTypeModel.MachinePrice;
            string remark=string.Format("续租矿机，矿机类型为：{0}，消耗高特币：{1}", MachineTypeModel.MachineName, MachineTypeModel.MachinePrice);
            int result=new ZGZY.BLL.BS_Machine().ReletMachine(StartTime, EndTime, Count_Time, 2, MachineModel.id, MachineTypeModel.MachinePrice, m.Login_Account, remark);
            if (result == 0)
            {
                return JsonValues(0, "续租成功!");
            }
            else 
            {
                return JsonValues(1, "续租失败!");
            }
            


        }


        #endregion

        #region 钱包地址

        public ActionResult WalletAddress() 
        {
            return View();
        }


        #endregion



    }
}
