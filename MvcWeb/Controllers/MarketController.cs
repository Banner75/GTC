using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.Common;
using ZGZY.Model;
using ZGZY.BLL;

namespace MvcWeb.Controllers
{
    /// 重制版人员：DeanWinchester
    public class MarketController : BaseController
    {
        public ActionResult gdmarket()
        {
            return View();
        }

        public ActionResult btmarket()
        {
            //int Counter_fee = Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(3).value); //手续费
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            BS_Customers userFrom = new ZGZY.BLL.CustomerBL().GetCustomerByID(Userid);
            //ViewData["Counter_fee"] = (Counter_fee * 0.01).ToString("##.##%");
            return View(userFrom);
        }


        #region 回收mrc币
        [HttpPost]
        public ActionResult SubmitRecycling(FormCollection frm)
        {
            try
            {
                String salenum = frm["salenum"];
                String password = frm["password"];
                String Userid = ZGZY.Common.LogionCookie.GetUserId();
                int Multiple = Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(8).value); //倍数
                int Minnum = Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(9).value);//最低数量
                int Counter_fee= Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(3).value); //手续费
                #region 数据合法性判断
                if (string.IsNullOrEmpty(salenum) || SqlInjection.GetString(salenum))
                {
                    return JsonValues(0, "出售数量错误");
                }
                if (!ZGZY.Common.Validator.IsNumber(salenum))
                {
                    return JsonValues(0, "出售数量只能填数字");
                }
                Decimal dec_salenum = Convert.ToDecimal(salenum);//预定交易数量
                if (dec_salenum <= 0)
                {
                    return JsonValues(0, "出售数量必须大于0");
                }
                if (dec_salenum < Minnum)
                {
                    return JsonValues(0, "最低销售数必须大于等于" + Minnum + "个！");
                }
                if (dec_salenum % Multiple != 0)
                {
                    return JsonValues(0, "销售数量必须是" + Multiple + "的倍数");
                }
                #region 二级密码判断
                if (string.IsNullOrEmpty(password) || SqlInjection.GetString(password))
                {
                    return JsonValues(0, "二级密码错误");
                }
                ZGZY.Model.BS_Customers UserlistModel = new ZGZY.BLL.CustomerBL().GetCustomerByID(Userid);
                if (UserlistModel.Pay_PWD != ZGZY.Common.Md5.GetMD5String(password))
                {
                    return JsonValues(0, "二级密码错误");
                }
                #endregion
                BS_Customers userFrom = new ZGZY.BLL.CustomerBL().GetCustomerByID(Userid);
                decimal all_mrc = userFrom.MRC;//账户总共mrc
                if (all_mrc == 0)
                {
                    return JsonValues(0, "您的剩余数量为:" + all_mrc.ToString() + ",不能出售");
                }
                if (all_mrc < dec_salenum)
                {
                    return JsonValues(0, "您的剩余数量为:" + all_mrc.ToString() + ",出售数量不能超过剩余数量");
                }
                #endregion
                #region 事务模式出售MRC币提交到回收大厅
                decimal reduce_salenum = dec_salenum - dec_salenum * Counter_fee * Convert.ToDecimal(0.01);  //扣除手续费后的数量 为实际交易数量
                DateTime t = DateTime.Now;
                if (new ZGZY.BLL.BTtransaction().addRecyclingMRC(t.ToString("yyyyMMddHHmmssfff"), Userid, reduce_salenum, dec_salenum, t, t, 1) == 0)
                {
                    return JsonValues(1, "成功提交到回收大厅!");
                }
                else
                {
                    return JsonValues(0, "失败请联系网站管理人员!");
                }
                #endregion
            }
            catch (Exception ex)
            {
                return JsonValues(0, ex.Message);
            }
        }
        #endregion

        #region 查看高特币交易详情
        /// <summary>
        /// 查看高特币交易详情
        /// </summary>
        /// <returns></returns>
        public ActionResult bybtdetail()
        {
            string id = Request.Params["id"];

            if (string.IsNullOrEmpty(id) || SqlInjection.GetString(id))
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }
            DataSet ds = new ZGZY.BLL.BTtransactionson().GetviewBTtransactionsonList("ID='" + id + "'");

            if (ds.Tables[0].Rows.Count <= 0)
            {
                return RedirectToAction("error", "Common", new { errorstr = "不存在此记录！" });
            }

            string usdRate = new ZGZY.BLL.BS_Configuration().GetModel(17).value;
            ViewBag.usdRate = usdRate;

            return View(ds.Tables[0]);
        }
        #endregion

        #region 分页获得卖bt列表
        /// <summary>
        /// 分页获得卖bt列表
        /// </summary>
        /// <returns></returns>
        public ActionResult getbtmarketlist()
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
            DataTable BTtransaction = new ZGZY.BLL.SuperPager().GetPagerList("tbBTtransaction", "*", "addtime  desc", 10, pageindex, "state=2 ", out totalCount);
            string strJson = ZGZY.Common.JsonHelper.ToJson(BTtransaction);
            return Content("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");
        }


        /// <summary>
        /// 获得分页
        /// </summary>
        /// <returns></returns>
        public ActionResult getbtmarketlistpage()
        {
            string page = Request.Params["page"];
            string totalCount = Request.Params["totalCount"];
            string jsaction = Request.Params["jsaction"];
            if (string.IsNullOrEmpty(totalCount) || SqlInjection.GetString(totalCount))
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }
            if (string.IsNullOrEmpty(jsaction) || SqlInjection.GetString(jsaction))
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }
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

            string pagination = new ZGZY.BLL.BTtransaction().GetBTtransactionpagination(Convert.ToInt32(totalCount), 10, pageindex, jsaction);
            return Content(pagination);
        }
        #endregion

        #region 汇款
        /// <summary>
        /// 汇款主页
        /// </summary>
        /// <returns></returns>
        public ActionResult remittanceindex()
        {
            string ID = Request.Params["ID"];
            if (string.IsNullOrEmpty(ID) || SqlInjection.GetString(ID))
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }
            DataSet ds = new ZGZY.BLL.BTtransactionson().GetviewBTtransactionsonList("ID='" + ID + "'");
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }

            string usdRate = new ZGZY.BLL.BS_Configuration().GetModel(17).value;
            ViewBag.usdRate = usdRate;

            return View(ds.Tables[0]);
        }
        /// <summary>
        /// 汇款
        /// </summary>
        /// <returns></returns>
        public ActionResult remittance()
        {
            string ID = Request.Params["ID"];
            string buytype = Request.Params["buytype"];
            string transfertime = Request.Params["transfertime"];
            string transfernum = Request.Params["transfernum"];
            #region  验证
            if (string.IsNullOrEmpty(ID) || SqlInjection.GetString(ID))
            {
                return Content("{\"msg\":\"id参数错误！\",\"success\":false}");
            }
            if (string.IsNullOrEmpty(buytype) || SqlInjection.GetString(buytype))
            {
                return Content("{\"msg\":\"汇款方式参数错误！\",\"success\":false}");
            }
            if (string.IsNullOrEmpty(transfertime) || SqlInjection.GetString(transfertime))
            {
                return Content("{\"msg\":\"汇款时间参数错误！\",\"success\":false}");
            }
            if (string.IsNullOrEmpty(transfernum) || SqlInjection.GetString(transfernum))
            {
                return Content("{\"msg\":\"汇款流水参数错误！\",\"success\":false}");
            }
            #endregion
            ZGZY.Model.BTtransactionson BTtransactionson = new ZGZY.BLL.BTtransactionson().GetBTtransactionsonModel(ID);
            BTtransactionson.buytype = Convert.ToInt32(buytype);
            BTtransactionson.transfertime = Convert.ToDateTime(transfertime);
            BTtransactionson.transfernum = transfernum;
            BTtransactionson.state = 6;
            BTtransactionson.updatetime = DateTime.Now;


            if (new ZGZY.BLL.BTtransactionson().UpdateBTtransactionson(BTtransactionson))
            {
                return Content("{\"msg\":\"汇款成功！等待卖家确认\",\"success\":true}");
            }
            else
            {
                return Content("{\"msg\":\"汇款失败！请联系网站管理人员\",\"success\":true}");
            }

        }


        #endregion

        #region 出售MRC币
        /// <summary>
        /// 出售MRC币
        /// </summary>
        /// <returns></returns>
        public ActionResult BTorder()
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
            DataTable BTtransaction = new ZGZY.BLL.SuperPager().GetPagerList("tbBTtransaction", "*", "addtime  desc", 10, pageindex, "  userID='" + ZGZY.Common.LogionCookie.GetUserId() + "'", out totalCount);
            string strJson = ZGZY.Common.JsonHelper.ToJson(BTtransaction);
            string pagination = new ZGZY.BLL.SuperPager().Getpagination(totalCount, 10, pageindex, "/Market/BTorder");
            ViewBag.pagination = pagination;
            return View(BTtransaction);
        }
        #endregion

        #region 出售MRC币子列表
        /// <summary>
        /// 出售MRC币子列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BTordersonlist()
        {
            string page = Request.Params["page"];
            string BTtransactionID = Request.Params["BTtransactionID"];

            if (string.IsNullOrEmpty(BTtransactionID) || SqlInjection.GetString(BTtransactionID))
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }

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
            DataTable BTtransaction = new ZGZY.BLL.SuperPager().GetPagerList("View_BTtransactionson", "*", "addtime  desc", 10, pageindex, "showuserID='" + ZGZY.Common.LogionCookie.GetUserId() + "' and BTtransactionID='" + BTtransactionID + "'", out totalCount);
            string strJson = ZGZY.Common.JsonHelper.ToJson(BTtransaction);
            string pagination = new ZGZY.BLL.SuperPager().Getpagination(totalCount, 10, pageindex, "/Market/BTordersonlist");
            ViewBag.pagination = pagination;
            return View(BTtransaction);
        }
        #endregion

        #region 收回挂出bt
        /// <summary>
        /// 收回挂出bt
        /// </summary>
        /// <returns></returns>
        public ActionResult backbtorder()
        {
            string BTtransactionId = Request.Params["ID"];//高特币交易主表ID
            if (string.IsNullOrEmpty(BTtransactionId) || SqlInjection.GetString(BTtransactionId))
            {
                return Content("{\"msg\":\"参数错误！\",\"success\":false}");
            }
            ZGZY.Model.BTtransaction BTtransactionModel = new ZGZY.BLL.BTtransaction().GetBTtransactionModel(BTtransactionId);
            if (BTtransactionModel == null)
            {
                return Content("{\"msg\":\"参数错误！\",\"success\":false}");
            }
            if (BTtransactionModel.dealmoney > 0)
            {
                return Content("{\"msg\":\"尚有交易未完成不能收回挂出！\",\"success\":false}");
            }
            if (BTtransactionModel.state == 1)
            {
                return Content("{\"msg\":\"此笔挂单已收回请勿重复收回挂单！\",\"success\":false}");
            }

            decimal tradeRate = Convert.ToDecimal(new ZGZY.BLL.BS_Configuration().GetModel(15).value) /100;


            List<string> list = new List<string>();
            //更新bt主表状态
            list.Add("UPDATE [tbBTtransaction] SET [state] =1,updatetime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where ID='" + BTtransactionModel.ID + "'");
            //更新卖家MRC值
            list.Add("UPDATE [BS_Customers] SET stare=stare-1,MRC=MRC+" + (BTtransactionModel.showmoney+ BTtransactionModel.showmoney * tradeRate)   + " where Login_Account='" + BTtransactionModel.userID + "'");
            //更新买家bt账户流水
            list.Add("INSERT INTO [BS_MRC_Wallet]([Sum],[Type],[Status],[Remark],[CreateDate],[Login_Account])VALUES (" + BTtransactionModel.showmoney + ",2,2,'收回挂出高特币','" + DateTime.Now + "','" + BTtransactionModel.userID + "')");
            list.Add("INSERT INTO [BS_MRC_Wallet]([Sum],[Type],[Status],[Remark],[CreateDate],[Login_Account])VALUES (" + BTtransactionModel.showmoney *tradeRate + ",2,2,'收回挂出高特币,退相应交易费用','" + DateTime.Now + "','" + BTtransactionModel.userID + "')");

            if (new ZGZY.BLL.publiccss().ExecuteSqlTran(list) > 0)
            {
                return Content("{\"msg\":\"收回挂出成功！\",\"success\":true}");
            }
            else
            {
                return Content("{\"msg\":\"确认失败！请联系网站管理人员\",\"success\":false}");
            }
        }
        #endregion

        #region 申诉
        /// <summary>
        /// 申诉主页
        /// </summary>
        /// <returns></returns>
        public ActionResult appealindex()
        {
            string BTtransactionsonID = Request.Params["ID"];
            if (string.IsNullOrEmpty(BTtransactionsonID) || SqlInjection.GetString(BTtransactionsonID))
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }
            ZGZY.Model.BTtransactionson BTtransactionsonModel = new ZGZY.BLL.BTtransactionson().GetBTtransactionsonModel(BTtransactionsonID);
            if (BTtransactionsonModel == null)
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }
            return View(BTtransactionsonModel);

        }

        public ActionResult appeal()
        {
            string BTtransactionsonID = Request.Params["ID"];
            string appealcontent = Request.Params["appealcontent"];
            if (string.IsNullOrEmpty(BTtransactionsonID) || SqlInjection.GetString(BTtransactionsonID))
            {
                return Content("{\"msg\":\"参数错误请返回刷新重试！\",\"success\":false}");

            }
            if (string.IsNullOrEmpty(appealcontent) || SqlInjection.GetString(appealcontent))
            {
                return Content("{\"msg\":\"参数错误请返回刷新重试！\",\"success\":false}");
            }
            ZGZY.Model.BTtransactionson BTtransactionsonModel = new ZGZY.BLL.BTtransactionson().GetBTtransactionsonModel(BTtransactionsonID);
            if (BTtransactionsonModel == null)
            {
                return RedirectToAction("error", "Common", new { errorstr = "参数错误请返回刷新重试！" });
            }
            BTtransactionsonModel.state = 3;
            BTtransactionsonModel.appealcontent = appealcontent;


            if (new ZGZY.BLL.BTtransactionson().UpdateBTtransactionson(BTtransactionsonModel))
            {
                return Content("{\"msg\":\"申请成功！\",\"success\":true}");
            }
            else
            {
                return Content("{\"msg\":\"申请失败！请联系网站管理人员\",\"success\":true}");
            }

        }


        #endregion

        #region 新版交易市场代码

        #region MRC收支流水
        public ActionResult MrcLog()
        {
            return View();
        }
        /// <summary>
        /// MRC币资金流水
        /// </summary>
        /// <returns></returns>
        public ActionResult getmrclist()
        {
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            if (string.IsNullOrEmpty(Userid))
            {
                return RedirectToAction("error", "Common", new { errorstr = "登录状态错误！" });
            }
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
            DataTable BTtransaction = new ZGZY.BLL.SuperPager().GetPagerList("BS_MRC_Wallet", "*", "CreateDate  desc", 10, pageindex, "Login_Account='" + Userid + "' ", out totalCount);
            string strJson = ZGZY.Common.JsonHelper.ToJson(BTtransaction);
            return Content("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");
        }
        #endregion

        #region 出售MRC币 [已修改事务模式]
        /// <summary>
        /// 卖bt
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult shouwbt()
        {
            decimal practical_money = Convert.ToDecimal(ZGZY.Common.DNTRequest.GetFormFloat("practical_money", 0));// Request.Params["num"];//销售数量
            decimal num = Convert.ToDecimal(ZGZY.Common.DNTRequest.GetFormFloat("num", 0));// Request.Params["num"];//销售数量
            string paypwd = ZGZY.Common.DNTRequest.GetFormString("safepwd");  //二级密码
            ZGZY.Model.BS_Customers UserlistModel = new ZGZY.BLL.CustomerBL().GetCustomerByID(ZGZY.Common.LogionCookie.GetUserId());
            int Multiple = Convert.ToInt32(Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(8).value)); //购买倍数
            int Minnum = Convert.ToInt32(Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(9).value));//购买倍数
            #region 验证
            if (num == 0 || practical_money ==0)
            {
                return JsonValues(1, "出售数量错误");
            }
            if (string.IsNullOrEmpty(paypwd) || SqlInjection.GetString(paypwd))
            {
                return JsonValues(1, "二级密码错误");
            }
            if (UserlistModel.Pay_PWD != ZGZY.Common.Md5.GetMD5String(paypwd))
            {
                return JsonValues(1, "二级密码错误");
            }
            if (UserlistModel.MRC < Convert.ToDecimal(practical_money))
            {
                return JsonValues(1, "销售数量大于" + UserlistModel.MRC + "");
            }
            if (num <= 0 || practical_money <=0)
            {
                return JsonValues(1, "销售数量必须大于0个！");
            }
            if (!ZGZY.Common.Validator.IsNumber(num.ToString()))
            {
                return JsonValues(1, "销售数量只能填数字！");
            }
            if (Convert.ToInt32(num) < Minnum)
            {
                return JsonValues(1, "最低销售数必须大于等于" + Minnum + "个！");
            }
            if (Convert.ToInt32(num) % Multiple != 0)
            {
                return JsonValues(1, "销售数量必须是" + Multiple + "的倍数");
            }

            /*对于受限制会员*/

            System.Data.DataSet ds = null;
            DateTime st_run_time;
            if (UserlistModel.Class == 0 || UserlistModel.Class == null )
            {
                ZGZY.Model.BS_Machine aMachine = new ZGZY.BLL.BS_Machine().GetModelByAccount(UserlistModel.Login_Account);
                if (aMachine != null)
                {
                    st_run_time = aMachine.start_run_time;
                    ds = new ZGZY.BLL.BTtransaction().GetBTtransactionList(" UserId='" + UserlistModel.Login_Account + "'  and state !=1 ");
                }
                else
                {
                    return JsonValues(1, "您未租凭矿机，不能卖出GTC！");
                }

                if (st_run_time.AddDays(120) < DateTime.Now) //120天后可自由买卖
                {
                    //;
                }
                else if (st_run_time.AddDays(90) < DateTime.Now) //90天后可50%
                {
                    if (num > UserlistModel.MRC * (decimal)0.5)
                    {
                        return JsonValues(1, "您不能卖出超过您所有GTC的50%！");
                    }

                }
                else if (st_run_time.AddDays(60) < DateTime.Now) //60天后可30%
                {
                    if (num > UserlistModel.MRC * (decimal)0.3)
                    {
                        return JsonValues(1, "您不能卖出超过您所有GTC的30%！");
                    }

                }
                else
                {
                    return JsonValues(1, "租凭矿机60天内不能卖出GTC.！");
                }
            }

            #endregion

            #region 需要修改成事务模式

            //ZGZY.Model.BTtransaction BTtransactionModel = new ZGZY.Model.BTtransaction();
            //BTtransactionModel.ID = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //BTtransactionModel.userID = ZGZY.Common.LogionCookie.GetUserId();
            //BTtransactionModel.allmoney = Convert.ToDecimal(num);
            //BTtransactionModel.showmoney = Convert.ToDecimal(num);
            //BTtransactionModel.dealmoney = 0;
            //BTtransactionModel.salemoney = 0;
            //BTtransactionModel.addtime = DateTime.Now;
            //BTtransactionModel.state = 2;
            //BTtransactionModel.updatetime = DateTime.Now;



            //ZGZY.Model.BTLog BTLog = new ZGZY.Model.BTLog();
            //BTLog.type = 2;
            //BTLog.state = 2;
            //BTLog.logcontent="";
            //BTLog.addtime=DateTime.Now;
            //BTLog.userID = UserlistModel.Login_Account;
            //BTLog.btmoney = Convert.ToDecimal(num);
            //UserlistModel.MRC = UserlistModel.MRC - Convert.ToDecimal(num);


            //if (new ZGZY.BLL.BTtransaction().AddBTtransaction(BTtransactionModel) > 0 && new CustomerBL().UpdateMRCorORE(UserlistModel) > 0 && new ZGZY.BLL.BTLog().AddBTLog(BTLog) > 0)
            //{
            //         return JsonValues(0, "挂单成功!");           
            //}
            //else
            //{
            //    return JsonValues(1, "失败请联系网站管理人员!");
            //}
            #endregion

            #region 事务模式出售MRC币
            if (new ZGZY.BLL.BTtransaction().addSaleMRC(DateTime.Now.ToString("yyMMddHHmmssfff") + ZGZY.Common.Utils.Number(2, false), num, UserlistModel.Login_Account, 2, 2, "矿主出售高特币", practical_money) == 0)
            {
                return JsonValues(0, "挂单成功!");
            }
            else
            {
                return JsonValues(1, "失败请联系网站管理人员!");
            }
            #endregion
        }
        #endregion

        #region 取消高特币订单 [已修改事务模式]
        /// <summary>
        /// 取消bt订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult cancelbtorder()
        {
            string id = Request.Params["id"];
            if (string.IsNullOrEmpty(id) || SqlInjection.GetString(id))
            {
                return JsonValues(1, "参数错误请返回刷新重试");
            }
            ZGZY.Model.BTtransactionson BTtransactionson = new ZGZY.BLL.BTtransactionson().GetBTtransactionsonModel(id);
            if (BTtransactionson.state == 1)
            {

                return JsonValues(1, "已取消请勿重复取消");
            }

            #region 陈旧版代码

            //BTtransactionson.state = 1;

            //ZGZY.Model.BTtransaction BTtransaction = new ZGZY.BLL.BTtransaction().GetBTtransactionModel(BTtransactionson.BTtransactionID);
            //BTtransaction.showmoney = BTtransaction.showmoney + BTtransactionson.dealmoney;
            //BTtransaction.dealmoney = BTtransaction.dealmoney - BTtransactionson.dealmoney;


            //if (new ZGZY.BLL.BTtransactionson().UpdateBTtransactionson(BTtransactionson) && new ZGZY.BLL.BTtransaction().UpdateBTtransaction(BTtransaction))
            //{
            //    return JsonValues(0, "取消成功");
            //}
            //else
            //{
            //    return JsonValues(1, "取消失败请联系网站管理人员");
            //}
            #endregion

            #region 新版事务执行
            if (new ZGZY.BLL.BTtransactionson().CancelOrder(id, BTtransactionson.BTtransactionID, BTtransactionson.dealmoney, BTtransactionson.buyuserID) == 0)
            {
                return JsonValues(0, "取消成功");
            }
            else
            {
                return JsonValues(1, "取消失败请联系网站管理人员");
            }
            #endregion

        }
        #endregion

        #region 确认GTC订单 [测试通过]
        /// <summary>
        /// 确认bt订单
        /// </summary>
        /// <returns></returns>
        public ActionResult affirmbtsonlist()
        {
            string BTtransactionsonID = Request.Params["ID"];//高特币交易子表id
            if (string.IsNullOrEmpty(BTtransactionsonID) || SqlInjection.GetString(BTtransactionsonID))
            {
                return Content("{\"msg\":\"参数错误！\",\"success\":false}");
            }
            ZGZY.Model.BTtransactionson BTtransactionsonmModel = new ZGZY.BLL.BTtransactionson().GetBTtransactionsonModel(BTtransactionsonID);
            if (BTtransactionsonmModel == null)
            {
                return Content("{\"msg\":\"参数错误！\",\"success\":false}");
            }
            string BTtransactionid = BTtransactionsonmModel.BTtransactionID;
            ZGZY.Model.BTtransaction BTtransactionModel = new ZGZY.BLL.BTtransaction().GetBTtransactionModel(BTtransactionid);
            if (BTtransactionModel == null)
            {
                return Content("{\"msg\":\"参数错误！\",\"success\":false}");
            }
            List<string> list = new List<string>();
            int state = 2;
            if (BTtransactionModel.dealmoney - BTtransactionsonmModel.dealmoney == 0 && BTtransactionModel.salemoney + BTtransactionsonmModel.dealmoney == BTtransactionModel.allmoney)
            {
                state = 3;
            }

            //取收入消费钱包比率．

            decimal cAmtRate = Convert.ToDecimal(new ZGZY.BLL.BS_Configuration().GetModel(16).value)/100;
            if (string.IsNullOrEmpty(cAmtRate.ToString())) cAmtRate = 0;

            //更新bt主表
            list.Add("UPDATE [tbBTtransaction] SET dealmoney=dealmoney-" + BTtransactionsonmModel.dealmoney + ",state=" + state + ",salemoney=salemoney+" + BTtransactionsonmModel.dealmoney + " where ID='" + BTtransactionsonmModel.BTtransactionID + "'");
            //更新bt子表
            list.Add("UPDATE [tbBTtransactionson] SET state='4',updatetime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where ID='" + BTtransactionsonmModel.ID + "'");
            //更新买家账户 

            ZGZY.Model.BS_Customers buyCustomer = new ZGZY.BLL.CustomerBL().GetCustomerByLoginAccount(BTtransactionsonmModel.buyuserID);

            if (buyCustomer.Class == 20)
            {
                list.Add("UPDATE [BS_Customers] SET MRC=MRC+" + BTtransactionsonmModel.dealmoney + " where Login_Account='" + BTtransactionsonmModel.buyuserID + "'");
            }
            else
            {
                list.Add("UPDATE [BS_Customers] SET MRC=MRC+" + BTtransactionsonmModel.dealmoney * (1 - cAmtRate) + ", cAmount=isnull(cAmount,0) + " + BTtransactionsonmModel.dealmoney * cAmtRate + "  where Login_Account='" + BTtransactionsonmModel.buyuserID + "'");
            }
            //更新买家账户流水
            list.Add("INSERT INTO [BS_MRC_Wallet]([Sum],[Type],[Status],[Remark],[CreateDate],[Login_Account])VALUES (" + BTtransactionsonmModel.dealmoney + ",2,2,'交易市场购买高特币','" + DateTime.Now + "','" + BTtransactionsonmModel.buyuserID + "')");

            if (new ZGZY.BLL.publiccss().ExecuteSqlTran(list) > 0)
            {
                return Content("{\"msg\":\"确认成功！\",\"success\":true}");
            }
            else
            {
                return Content("{\"msg\":\"确认失败！请联系网站管理人员\",\"success\":false}");
            }


        }
        #endregion

        #region 购买GTC [已修改事务模式]
        /// <summary>
        /// 买bt
        /// </summary>
        /// <returns></returns>
        public ActionResult bybtindex()
        {
            string BTID = Request.Params["BTID"];
            ZGZY.Model.BTtransaction BTtransaction = new ZGZY.BLL.BTtransaction().GetBTtransactionModel(BTID);
            return View(BTtransaction);
        }
        //确认购买GTC
        public ActionResult bybtform()
        {
            string BTID = Request.Params["BTID"];
            string bynum = Request.Params["bynum"];
            int Multiple = Convert.ToInt32(Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(8).value)); //购买倍数
            int Minnum = Convert.ToInt32(Convert.ToInt32(new ZGZY.BLL.BS_Configuration().GetModel(9).value));//购买倍数
            string rate = new ZGZY.BLL.BS_Configuration().GetModel(5).value;
            #region  验证
            if (string.IsNullOrEmpty(BTID) || SqlInjection.GetString(BTID))
            {
                return Content("{\"msg\":\"参数错误！\",\"success\":false}");
            }
            if (string.IsNullOrEmpty(bynum) || SqlInjection.GetString(bynum))
            {
                return Content("{\"msg\":\"购买数不能为空！\",\"success\":false}");
            }
            if (!ZGZY.Common.Validator.IsNumber(bynum))
            {
                return Content("{\"msg\":\"购买数量只能填数字！\",\"success\":false}");
            }
            if (Convert.ToInt32(bynum) <= 0)
            {
                return Content("{\"msg\":\"购买数量必须大于0个！\",\"success\":false}");
            }
            if (Convert.ToInt32(bynum) < Minnum)
            {
                return Content("{\"msg\":\"最低购买数必须大于等于" + Minnum + "个！\",\"success\":false}");
            }
            if (Convert.ToInt32(bynum) % Multiple != 0)
            {
                return Content("{\"msg\":\"购买数量必须是" + Multiple + "的倍数！\",\"success\":false}");
            }
            string buyuserid = ZGZY.Common.LogionCookie.GetUserId();
            ZGZY.Model.BTtransaction bttransaction = new ZGZY.BLL.BTtransaction().GetBTtransactionModel(BTID);
            #endregion

            //#region 需改成事务


            //BTtransactionson.ID = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //BTtransactionson.BTtransactionID = BTtransaction.ID;
            //BTtransactionson.dealmoney =Convert.ToDecimal(bynum);
            //BTtransactionson.state = 2;
            //BTtransactionson.buyuserID = buyuserid;
            //BTtransactionson.addtime = DateTime.Now;
            //BTtransactionson.updatetime = DateTime.Now;
            //BTtransactionson.transfertime = Convert.ToDateTime("1990-01-01");
            //BTtransactionson.buytype = 0;
            if (buyuserid == bttransaction.userID)
            {
                return Content("{\"msg\":\"不能自己跟自己交易\",\"success\":false}");
            }
            if ((bttransaction.allmoney - Convert.ToDecimal(bynum) < 0))
            {
                return Content("{\"msg\":\"购买数错误！请刷新重试！\",\"success\":false}");
            }
            //BTtransaction.showmoney = BTtransaction.showmoney - Convert.ToDecimal(bynum);
            //BTtransaction.dealmoney=Convert.ToDecimal(bynum);

            //if (new ZGZY.BLL.BTtransactionson().AddBTtransactionson(BTtransactionson) > 0 && new ZGZY.BLL.BTtransaction().UpdateBTtransaction(BTtransaction))
            //{

            //    return Content("{\"msg\":\"购买成功请及时打款\",\"success\":true}");
            //}
            //else
            //{
            //    return Content("{\"msg\":\"购买失败请联系网站管理人员\",\"success\":true}");
            //}
            //#endregion
            #region 已改成事务，完整版
            if (new ZGZY.BLL.BTtransactionson().BuyMRC(DateTime.Now.ToString("yyyyMMddHHmmssfff"), bttransaction.ID, Convert.ToInt32(bynum), buyuserid, Convert.ToDecimal(rate), 2) == 0)
            {
                return Content("{\"msg\":\"购买成功请及时打款\",\"success\":true}");
            }
            else
            {
                return Content("{\"msg\":\"购买失败请联系网站管理人员\",\"success\":true}");
            }
            #endregion

        }

        #endregion

        #endregion

        #region 高特币转换比率图
        public ActionResult getMonthRates()
        {
            #region 参数
            string strWhere1 = "1=1 and DATEDIFF(m,GETDATE(),addtime) =0 order by CONVERT(varchar(6),addtime,112) desc, addtime ", strWhere2 = "1=1 ";
            string Months = Request.Params["Months"] == null ? "1" : Request.Params["Months"];  //排序列
            string stDetaMonth = Request.Params["stDetaMonth"] == null ? "1" : Request.Params["stDetaMonth"];  //排序方式 asc或者desc
            string strJson = "";//输出结果
            #endregion

            string strName = "", strData = "";
            string str_series = "";

            System.Data.DataSet ds1, ds2;

            ZGZY.BLL.BS_appreciation bll = new ZGZY.BLL.BS_appreciation();

            ds1 = bll.GetList(strWhere1);
            strWhere2 += " and DATEDIFF(m,dateadd(m,-1*" + stDetaMonth + ",GETDATE()),addtime) <" + Months + " and DATEDIFF(m,dateadd(m,-1*" + stDetaMonth + " ,GETDATE()),addtime)>=0 order by CONVERT(varchar(6),addtime,112) desc, addtime";
            ds2 = bll.GetList(strWhere2);

            foreach (System.Data.DataRow row in ds1.Tables[0].Rows)
            {
                strName = ((DateTime)row["addtime"]).ToString("yyyy年MM月");
                if (((DateTime)row["addtime"]).Day > 1 && strData.Length == 0)
                {
                    for (int i = 1; i < ((DateTime)row["addtime"]).Day; i++)
                    {
                        strData += "null,null,null,";
                    }
                }
                strData += row["TodayPrice"].ToString() + ",";
            }
            if (strData.Length > 0)
                strData = strData.Remove(strData.Length - 1, 1);
            else
            {
                strName = DateTime.Now.ToString("yyyy年MM月");
            }

            str_series += "{\"name\":\"" + strName + "\",\"data\": [" + strData + "] }";

            strData = "";
            strName = "";
            foreach (System.Data.DataRow row in ds2.Tables[0].Rows)
            {
                if (((DateTime)row["addtime"]).ToString("yyyy年MM月") != strName)
                {
                    if (strData.Length > 0) //非第一次进入，换月
                    {
                        strData = strData.Remove(strData.Length - 1, 1);
                        str_series += ",{\"name\":\"" + strName + "\",\"data\": [" + strData + "] }";
                        strName = "";
                        strData = "";
                    }
                    if (((DateTime)row["addtime"]).Day > 1 && strData.Length == 0)
                    {
                        for (int i = 1; i < ((DateTime)row["addtime"]).Day; i++)
                        {
                            strData += "null,null,null,";
                        }
                    }
                    strName = ((DateTime)row["addtime"]).ToString("yyyy年MM月");
                }
                strData += row["TodayPrice"].ToString() + ",";

            }

            if (strName.Length > 0)
            {
                strData = strData.Remove(strData.Length - 1, 1);
                str_series += ",{\"name\":\"" + strName + "\",\"data\": [" + strData + "] }";

            }

            strJson = "{\"success\":true,\"series\":[" + str_series + "]}";
            //strJson = "{\"success\":true,\"series\":[]}";
            //return Content("{\"msg\":\"修改成功！\",\"success\":true }");
            return Content(strJson);

        }
        
        #endregion
    }
}

