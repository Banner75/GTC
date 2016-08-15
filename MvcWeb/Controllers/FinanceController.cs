using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ZGZY.Model;
using ZGZY.BLL;
using ZGZY.Common;

namespace MvcWeb.Controllers
{
    /// <summary>
    /// 功能说明：财务管理
    /// 创建人员：林 红 刚
    /// 创建日期：2016/06/20
    /// 重制版人员：DeanWinchester
    /// </summary>
    public class FinanceController : BaseController
    {
        #region 矿机币转高特币

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderCoin()
        {            
            return View();
        }
        /// <summary>
        /// 兑换高特币
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExchangeMRC()
        {
            int Fee = Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(3).value);
            int minnum = Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(10).value); //最低兑换价格
            string userid = ZGZY.Common.LogionCookie.GetUserId();
            string safepwd = DNTRequest.GetFormString("pwd");
            ZGZY.Model.BS_Customers mem = new ZGZY.BLL.CustomerBL().GetCustomerByID(userid);
            int num = DNTRequest.GetFormInt("num", 0);
            if (string.IsNullOrEmpty(safepwd))
            {
                return JsonValues(1, "请输入交易密码！");
            }
            if (num <= 0 || num < minnum)
            {
                return JsonValues(1, "兑换数量必须大于" + minnum + "个起！");
            }
            if (mem == null)
            {
                return JsonValues(1, "登录状态失效！");
            }
            if (mem.ORE < num)
            {
                return JsonValues(1, "会员的矿币不足！");
            }
            if (ZGZY.Common.Md5.GetMD5String(safepwd) != mem.Pay_PWD)
            {
                return JsonValues(1, "交易密码错误！");
            }
            //兑换数量扣除手续费实际获得数量

            int MRC = num - (num * (Fee / 100));//实际到账金额
            if (new ZGZY.BLL.CustomerBL().ConversionMRC(num, MRC, userid, (mem.ORE - Convert.ToDecimal(num)), DateTime.Now.ToString("yyyyMMddHHmmssffff"), Fee) == 0)
            {
                return JsonValues(0, "换购成功！");
            }
            return JsonValues(1, "换购失败！");
        }

        #endregion

        #region
        
        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult CAmtTran()
        {
            return View();
        }

        /// <summary>
        /// 消费币转账
        /// </summary>
        /// <returns></returns>
        public ActionResult TransferCAmt()
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();//获取当前登录账号
            if (string.IsNullOrEmpty(Userid)) { return JsonValues(1, "登录状态失效，请重新登录!"); }//判断是否已登录账号
            ZGZY.Model.BS_Customers modelByUserid = new CustomerBL().GetCustomerByID(Userid);//根据当前登录账号判断用户是否存在
            if (modelByUserid == null) { return JsonValues(1, "登录状态失效，请重新登录!"); }

            string zhangHao = DNTRequest.GetFormString("zhangHao");//获取对方账号
            string num = DNTRequest.GetFormString("num");//获取转账的高特币数量
            string pwd = DNTRequest.GetFormString("pwd");//获取当前登录账号的交易密码

            #region 防SQL注入
            if (SqlInjection.GetString(zhangHao) || string.IsNullOrEmpty(zhangHao)) { return JsonValues(1, "对方账号为空或者含有非法字符，请重新输入！"); }
            if (SqlInjection.GetString(num) || string.IsNullOrEmpty(num)) { return JsonValues(1, "数量为空或者含有非法字符，请重新输入！"); }
            if (SqlInjection.GetString(pwd) || string.IsNullOrEmpty(pwd)) { return JsonValues(1, "交易密码为空或者含有非法字符，请重新输入！"); }
            #endregion

            if (modelByUserid.Pay_PWD != ZGZY.Common.Md5.GetMD5String(pwd))//判断输入的交易密码是否和当前登录账号的交易密码相同
            {
                return JsonValues(1, "交易密码错误，请重新输入！");
            }
            if (!ZGZY.Common.Utils.IsInt(num)) { return JsonValues(1, "数量必须是正整数，请重新输入！"); }//判断填写的数量是否为正整数

            ZGZY.Model.BS_Customers modelByzhangHao = new CustomerBL().GetCustomerByID(zhangHao);//根据填写的对方账号获取账号信息
            if (modelByzhangHao == null) { return JsonValues(1, "对方账户不存在，请重新输入！"); }//判断对方账号是否存在
            if (modelByzhangHao.Login_Account == modelByUserid.Login_Account) { return JsonValues(1, "对方账户不能是自己，请重新输入！"); }//转账人与被转账人不能为同一人

            if (Convert.ToDecimal(num) <= 0)
            {
                return JsonValues(1, "转账个数必须大于0！");
            }


            decimal tradeRate = 0; //Convert.ToDecimal(new ZGZY.BLL.BS_Configuration().GetModel(15).value) / 100; //暂时不减手续费．
            decimal cAmtRate = Convert.ToDecimal(new ZGZY.BLL.BS_Configuration().GetModel(16).value) / 100;

            if (modelByUserid.cAmt < Convert.ToDecimal(num) * (1 + tradeRate))
            {
                return JsonValues(1, "会员的可交易消费币(" + modelByUserid.cAmt + ")不足！");
            }

            if (Convert.ToInt32(ZGZY.Common.SqlHelper.GetSingle("select dbo.[fx_IsTeamRelation]('" + Userid + "','" + zhangHao + "' ")) == 0)
            {
                return JsonValues(1, "只能在上下级之间转帐，请参考安置图重新输入！");
            }

            ViewData["xingming"] = modelByzhangHao.Truly_Name;

            decimal newCAmtByUserid = modelByUserid.cAmt - decimal.Parse(num) * (1 + tradeRate);//当前登录账号的高特币数量 = 原有的高特币数量 - 转出去的高特币数量(包含交易费用）
//          decimal newCAmtByzhangHao = modelByzhangHao.cAmt + decimal.Parse(num) * (1 - cAmtRate);//对方账号的高特币数量 = 原有的高特币数量 + 转进去的高特币数量*rate
            decimal newcAmtByzhangHao = modelByzhangHao.cAmt + decimal.Parse(num); // *cAmtRate; //对方账号的高特币数量 = 原有的高特币数量 + 转进去的高特币数量*rate

            List<string> sqlList = new List<string>();//定义一个泛型，装执行的SQL语句
            //更新当前登录账号的高特币
            sqlList.Add("update BS_Customers set  CAmount = " + newCAmtByUserid + " where Login_Account = '" + modelByUserid.Login_Account + "'");
            //更新对方账号的消费币,,
            sqlList.Add("update BS_Customers set cAmount = " + newcAmtByzhangHao + " where Login_Account = '" + modelByzhangHao.Login_Account + "'");
            //插入当前登录账号的消费币流水表数据，交易类型为1支出
            sqlList.Add("INSERT INTO BS_MRC_Wallet (Sum,Type,Status,Remark,CreateDate,Login_Account) VALUES(" + decimal.Parse(num) * (1 + tradeRate) + ",1,0,'消费币转账支出,转入帐号：" + zhangHao + "','" + DateTime.Now + "','" + modelByUserid.Login_Account + "')");
            //插入对方账号的消费币流水表数据，交易类型为2收入
            sqlList.Add("INSERT INTO BS_MRC_Wallet (Sum,Type,Status,Remark,CreateDate,Login_Account) VALUES(" + Convert.ToInt32(num) + ",2,0,'消费币转账收入，转出帐号：" + Userid + "','" + DateTime.Now + "','" + modelByzhangHao.Login_Account + "')");

            if (new ZGZY.BLL.publiccss().ExecuteSqlTran(sqlList) > 0)
            {
                return JsonValues(0, "转账成功！");
            }
            else
            {
                return JsonValues(1, "转账失败！");
            }
        }
        #endregion


        #region 高特币转帐

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult CoinMoveToAccount()
        {
            return View();
        }

        /// <summary>
        /// 高特币转账
        /// </summary>
        /// <returns></returns>
        public ActionResult TransferMRC()
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();//获取当前登录账号
            if (string.IsNullOrEmpty(Userid)) { return JsonValues(1, "登录状态失效，请重新登录!"); }//判断是否已登录账号
            ZGZY.Model.BS_Customers modelByUserid = new CustomerBL().GetCustomerByID(Userid);//根据当前登录账号判断用户是否存在
            if (modelByUserid == null) { return JsonValues(1, "登录状态失效，请重新登录!"); }

            string zhangHao = DNTRequest.GetFormString("zhangHao");//获取对方账号
            string num = DNTRequest.GetFormString("num");//获取转账的高特币数量
            string pwd = DNTRequest.GetFormString("pwd");//获取当前登录账号的交易密码

            #region 防SQL注入
            if (SqlInjection.GetString(zhangHao) || string.IsNullOrEmpty(zhangHao)) { return JsonValues(1, "对方账号为空或者含有非法字符，请重新输入！"); }
            if (SqlInjection.GetString(num) || string.IsNullOrEmpty(num)) { return JsonValues(1, "数量为空或者含有非法字符，请重新输入！"); }
            if (SqlInjection.GetString(pwd) || string.IsNullOrEmpty(pwd)) { return JsonValues(1, "交易密码为空或者含有非法字符，请重新输入！"); }
            #endregion

            if (modelByUserid.Pay_PWD != ZGZY.Common.Md5.GetMD5String(pwd))//判断输入的交易密码是否和当前登录账号的交易密码相同
            {
                return JsonValues(1, "交易密码错误，请重新输入！");
            }
            if (!ZGZY.Common.Utils.IsInt(num)) { return JsonValues(1, "数量必须是正整数，请重新输入！"); }//判断填写的数量是否为正整数

            ZGZY.Model.BS_Customers modelByzhangHao = new CustomerBL().GetCustomerByID(zhangHao);//根据填写的对方账号获取账号信息
            if (modelByzhangHao == null) { return JsonValues(1, "对方账户不存在，请重新输入！"); }//判断对方账号是否存在
            if (modelByzhangHao.Login_Account == modelByUserid.Login_Account) { return JsonValues(1, "对方账户不能是自己，请重新输入！"); }//转账人与被转账人不能为同一人

            if (Convert.ToDecimal(num) <= 0)
            {
                return JsonValues(1, "转账个数必须大于0！");
            }

            if (Convert.ToInt32(ZGZY.Common.SqlHelper.GetSingle("select dbo.[fx_IsTeamRelation]('" + Userid + "','" + zhangHao + "' ")) == 0)
            {
                return JsonValues(1, "只能在上下级之间转帐，请参考安置图重新输入！");
            }


            decimal tradeRate = 0; //Convert.ToDecimal(new ZGZY.BLL.BS_Configuration().GetModel(15).value) / 100; //暂时不减手续费．
            decimal cAmtRate = Convert.ToDecimal(new ZGZY.BLL.BS_Configuration().GetModel(16).value)/100; 

            if (modelByUserid.MRC < Convert.ToDecimal(num) * (1+tradeRate))
            {
                return JsonValues(1, "会员的可交易高特币(" +modelByUserid.MRC +")不足！" );
            }


            ViewData["xingming"] = modelByzhangHao.Truly_Name;

            decimal newMRCByUserid = modelByUserid.MRC - decimal.Parse(num)*(1 + tradeRate);//当前登录账号的高特币数量 = 原有的高特币数量 - 转出去的高特币数量(包含交易费用）

            decimal newMRCByzhangHao = 0, newcAmtByzhangHao = 0;
            if (modelByzhangHao.Class == 20)
            {
                newMRCByzhangHao = modelByzhangHao.MRC + decimal.Parse(num); //对方账号的高特币数量 = 原有的高特币数量 + 转进去的高特币数量
                newcAmtByzhangHao = modelByzhangHao.cAmt ; 
            }
            else
            {
                 newMRCByzhangHao = modelByzhangHao.MRC + decimal.Parse(num) * (1 - cAmtRate);//对方账号的高特币数量 = 原有的高特币数量 + 转进去的高特币数量*rate
                 newcAmtByzhangHao = modelByzhangHao.cAmt + decimal.Parse(num) * cAmtRate; //对方账号的高特币数量 = 原有的高特币数量 + 转进去的高特币数量*rate
            }
            


            List<string> sqlList = new List<string>();//定义一个泛型，装执行的SQL语句
            //更新当前登录账号的高特币
            sqlList.Add("update BS_Customers set  MRC = " + newMRCByUserid + " where Login_Account = '" + modelByUserid.Login_Account + "'");
            //更新对方账号的高特币
            sqlList.Add("update BS_Customers set  MRC = " + newMRCByzhangHao + " , cAmount = " + newcAmtByzhangHao + " where Login_Account = '" + modelByzhangHao.Login_Account + "'");
            //插入当前登录账号的高特币流水表数据，交易类型为1支出
            sqlList.Add("INSERT INTO BS_MRC_Wallet (Sum,Type,Status,Remark,CreateDate,Login_Account) VALUES(" + decimal.Parse(num) * (1 + tradeRate) + ",1,0,'高特币转账支出,转入帐号：" + zhangHao + "','" + DateTime.Now + "','" + modelByUserid.Login_Account + "')");
            //插入对方账号的高特币流水表数据，交易类型为2收入
            sqlList.Add("INSERT INTO BS_MRC_Wallet (Sum,Type,Status,Remark,CreateDate,Login_Account) VALUES(" + Convert.ToInt32(num) + ",2,0,'高特币转账收入，转出帐号：" + Userid + "','" + DateTime.Now + "','" + modelByzhangHao.Login_Account + "')");

            if (new ZGZY.BLL.publiccss().ExecuteSqlTran(sqlList) > 0)
            {
                return JsonValues(0, "转账成功！");
            }
            else
            {
                return JsonValues(1, "转账失败！");
            }
        }

        #endregion

        #region 财务明细报告

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ViewResult FinanceDetail(int page = 1)
        {

            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            //获取工单列表
            int pageSize = 10;
            int totalCount = 0;

            DataTable Income = new ZGZY.BLL.SuperPager().GetPagerList("BS_DigIncomeDetail", "*", " Occur_Date desc", pageSize, page, "  SubAccount='" + Userid + "' and Kind<>'2' and Kind<>'0' and Kind<>'5' ", out totalCount);//g("p2p_article", "", pageSize, page, "id", 1, "*");
            page = ZGZY.Common.DNTRequest.GetQueryInt("page", 1);// int.Parse(Request.QueryString["page"]);

            //totalCount = WT.Common.Utils.StrToInt(Article.Tables[1].Rows[0]["RecordCount"], 0);
            PageModel pageModel = new PageModel(pageSize, page, totalCount);

            DigIncomeDetaiModel model = new DigIncomeDetaiModel()
            {
                IncomeList = Income,
                PageModel = pageModel
            };
            return View(model);
        }

        #endregion

        #region 每日收益报告

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ViewResult InCome(int page = 1)
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            //获取工单列表
            int pageSize = 10;
            int totalCount = 0;

            DataTable Income = new ZGZY.BLL.SuperPager().GetPagerList("BS_DigIncomeDetail", "*", " Occur_Date desc", pageSize, page, "  SubAccount='" + Userid + "' and (Kind='2' or Kind='0' or Kind='5' ) ", out totalCount);//g("p2p_article", "", pageSize, page, "id", 1, "*");
            page = ZGZY.Common.DNTRequest.GetQueryInt("page", 1);// int.Parse(Request.QueryString["page"]);

            //totalCount = WT.Common.Utils.StrToInt(Article.Tables[1].Rows[0]["RecordCount"], 0);
            PageModel pageModel = new PageModel(pageSize, page, totalCount);

            DigIncomeDetaiModel model = new DigIncomeDetaiModel()
            {
                IncomeList = Income,
                PageModel = pageModel
            };
            return View(model);
        }

        #endregion

        #region 充值列表申请

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        public ActionResult RechangeList()
        {
            return View();
        }

        #endregion

    }
}
