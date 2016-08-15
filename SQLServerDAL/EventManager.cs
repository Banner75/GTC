using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ZGZY.IDAL;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    public class EventManager : IEvent
    {
        #region 定时器
        decimal BonusReat = (Convert.ToDecimal(new BS_Configuration().GetModel(1).value) / 100);
        decimal cAmtRate = (Convert.ToDecimal(new BS_Configuration().GetModel(16).value) / 100);
        decimal mrcRate =1-(Convert.ToDecimal(new BS_Configuration().GetModel(16).value) / 100);

        #region  计算奖金收益
        public void CalculationBonus(object obj)
        {
            try
            {
                Dictionary<string, string[]> Parent_Customer = new Dictionary<string, string[]>();//"自己,责任人"
                Dictionary<string, int> Parent_Machine = new Dictionary<string, int>();//"自己,矿机"
                Dictionary<string, decimal> Parent_Sum = new Dictionary<string, decimal>();//"自己,今日收益"
                Dictionary<string, decimal> PersonBonus = new Dictionary<string, decimal>();//用来存放自己下线的挖矿收益，用于计算今日所得奖金 

                DataTable dt = new CustomerDA().GetList(" State=1 ").Tables[0]; // and Login_Account='yhl2016'
                if (dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Account = dt.Rows[i]["Login_Account"].ToString();

                        #region 判断今日是否发放过奖金 ==如果已发放跳出循环找下一条
                        if (new BS_DigIncomeDetail().GetDailyIncomeFromToDay(Account, 2) > 0)
                        {
                            continue;
                        }
                        #endregion

                        string sqldui = "exec sp_getTeamDuiPeng '" + Account + "' ";
                        SqlHelper.ExecuteSql(sqldui);
                    }

                }

                #region 每天定时去除额外奖金分发

                string sql = "update BS_Machine set OtherOREBonus=0 ";
                SqlHelper.ExecuteSql(sql);
                #endregion

                UpdateExecuteTimeError("计算奖金收益执行成功", 1);
            }
            catch (Exception e)
            {
                AddExecuteTimeError("计算奖金收益执行失败" + e.Message, 2);
            }
            
        }

        void FindOtherSon(string BonusAccount, string leftAccount, string rightAccount, int leftmachine, int rightmachine, ref Dictionary<string, decimal> PersonBonus,ref int layer)
        {
            // PersonBonus = new Dictionary<string, decimal>();
            layer++;
            string l_account = "";
            string r_account = "";
            decimal l_money = 0;
            decimal r_money = 0;
            int l_machine = 0;
            int r_machine = 0;
            decimal bonus = 0;
            DataTable son_l = new CustomerDA().GetList(" Person_Liable='" + leftAccount + "' ").Tables[0];
            if (son_l != null)
            {
                if (son_l.Rows.Count > 0)
                {
                    for (int i = 0; i < son_l.Rows.Count; i++)
                    {
                        //判断存在运行中的矿机才可以作为分奖金条件
                        if (son_l.Rows[i]["region"].ToString() == "0")
                        {
                            ZGZY.Model.BS_Machine Machine = new BS_Machine().GetModelByAccount(son_l.Rows[i]["Login_Account"].ToString());
                            if (Machine != null)
                            {
                                //就是他
                                l_account = son_l.Rows[i]["Login_Account"].ToString();
                                l_money = new BS_DigIncomeDetail().GetDailyIncome(l_account, 0);
                                l_machine = Machine.type;
                                break;
                            }
                        }
                    }
                }
            }

            DataTable son_r = new CustomerDA().GetList(" Person_Liable='" + rightAccount + "' ").Tables[0];
            if (son_r != null)
            {
                if (son_r.Rows.Count > 0)
                {
                    for (int i = 0; i < son_r.Rows.Count; i++)
                    {
                        //判断存在运行中的矿机才可以作为分奖金条件
                        if (son_r.Rows[i]["region"].ToString() == "0")
                        {
                            ZGZY.Model.BS_Machine Machine = new BS_Machine().GetModelByAccount(son_r.Rows[i]["Login_Account"].ToString());
                            if (Machine != null)
                            {
                                r_account = son_r.Rows[i]["Login_Account"].ToString();
                                r_money = new BS_DigIncomeDetail().GetDailyIncome(r_account, 0);
                                r_machine = Machine.type;
                            }
                            break;
                        }
                    }
                }
            }
            if (l_account != "" && r_account != "")//如果成立
            {
                //判断上级矿机总数
                leftmachine = leftmachine + l_machine;
                rightmachine = rightmachine + r_machine;
                if (leftmachine < rightmachine)
                {
                    if (l_machine < r_machine)//判断机器平衡发放最大还是最小奖金
                    {
                        bonus = l_money;
                    }
                    else
                    {
                        bonus = r_money;
                    }
                }
                else
                {
                    bonus = r_money;
                }
                #region 记录单层收益
                Model.BS_DigIncomeDetail dd = new Model.BS_DigIncomeDetail();
                dd.ID = DateTime.Now.ToString("yyMMddhhssmmffff")+"01";
                dd.Income = 0;
                dd.Kind = "0";
                dd.Machine = 0;
                dd.Occur_Date = DateTime.Now;
                dd.Pay = 0;
                dd.Remain = 0;
                dd.Remark = "第" + layer + "层：【" + l_account + "】【" + r_account + "】产生对碰奖金" + (bonus * BonusReat).ToString("#0.000") + "";
                dd.SubAccount = BonusAccount;
                new BS_DigIncomeDetail().Add(dd);
                #endregion
                //计算第一层收益
                if (PersonBonus.ContainsKey(BonusAccount))
                {
                    decimal commission = PersonBonus[BonusAccount];
                    PersonBonus[BonusAccount] = commission + bonus;
                }
                else
                {
                    PersonBonus[BonusAccount] = bonus;
                }
                FindOtherSon(BonusAccount, l_account, r_account, leftmachine, rightmachine, ref PersonBonus, ref layer);
            }
        }
        #endregion

        #region  计算见点奖金收益
        public void CalculateJianDian(object obj)
        {
            try
            {
                Dictionary<string, string[]> Parent_Customer = new Dictionary<string, string[]>();//"自己,责任人"
                Dictionary<string, int> Parent_Machine = new Dictionary<string, int>();//"自己,矿机"
                Dictionary<string, decimal> Parent_Sum = new Dictionary<string, decimal>();//"自己,今日收益"
                Dictionary<string, decimal> PersonBonus = new Dictionary<string, decimal>();//用来存放自己下线的挖矿收益，用于计算今日见点所得奖金 

                #region 从没有推荐人的会员开始计算
                //正常用户的
                DataTable dt = new CustomerDA().GetList(" State=1 ").Tables[0]; // and Login_Account='yhl2016'
                if (dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Account = dt.Rows[i]["Login_Account"].ToString();

                        #region 判断今日是否发放过见点奖金 ==如果已发放跳出循环找下一条
                        if (new BS_DigIncomeDetail().GetDailyIncomeFromToDay(Account, 5) > 0)
                        {
                            continue;
                        }
                        #endregion

                        string sql="exec sp_getTeamJianDian '" + Account + "' ";
                        SqlHelper.ExecuteSql(sql);

                            //new BS_DigIncomeDetail().AddLssuebonus(kv.Key, bonus, balance, DateTime.Now.ToString("yyMMddhhssmmffff") + iss.ToString(), "矿区今日收成：" + kv.Value + "，获得奖金：" + bonus.ToString("#0.000") + "");
                    }
                }

                UpdateExecuteTimeError("计算见点奖金收益执行成功", 1);
            }
            catch (Exception e)
            {
                AddExecuteTimeError("计算见点奖金收益执行失败" + e.Message, 2);
            }

        }

        #endregion

        #region 自动挖矿收益
        public void DigInCome(object obj) 
        {
            //一天发一次
            //先获取全部的矿机出来
            ZGZY.SQLServerDAL.BS_Machine MachineBLL = new ZGZY.SQLServerDAL.BS_Machine();
            ZGZY.SQLServerDAL.CustomerDA CustomerBL = new ZGZY.SQLServerDAL.CustomerDA();
            ZGZY.SQLServerDAL.BS_DigIncomeDetail DigIncomeDetailBLL = new ZGZY.SQLServerDAL.BS_DigIncomeDetail();
            var MachineList = MachineBLL.GetModelList(string.Format("status=2 and start_run_time<=GETDATE()"));//正在运行的矿机
            //获取全部的矿机出来先
            var MachineTypeList = new ZGZY.SQLServerDAL.BS_MachineConfig().GetModelList("1=1");
            Random rm = new Random();
            if (MachineList == null) { return; }
            if (MachineList.Count <= 0) { return; }
            int ss = 10;
            foreach (var MachineModel in MachineList)
            {
                #region 判断今日是否发放过奖金 ==如果已发放跳出循环找下一条
                if (new BS_DigIncomeDetail().GetDailyIncomeFromToDay(MachineModel.Login_Account, 1) > 0)
                {
                    continue;
                }
                #endregion
                ss++;
                var TmpMachineType = (from MachineType in MachineTypeList where MachineType.id == MachineModel.type select MachineType).ToList();
                var member = CustomerBL.GetCustomerByLoginAccount(MachineModel.Login_Account);
                DateTime StopDate = new DateTime();
                if (member != null && TmpMachineType != null && TmpMachineType.Count > 0)//没到现在已经停止挖矿了
                {
                    if ((MachineModel.end_run_time - DateTime.Now).TotalDays < 0)
                    {
                        StopDate = MachineModel.end_run_time;
                    }
                    else
                    {
                        StopDate = DateTime.Now;
                    }
                    var Hours = (StopDate - MachineModel.count_time).TotalHours;//今天挖的时间
                    if (Hours > 24) 
                    {
                        Hours = 24;//最多算24小时
                    }
                    if (Hours <= 0) 
                    {
                        continue;
                    }
                    decimal ToDayCount = ((decimal)MachineModel.today_count / 24) * (decimal)Hours;//今天的挖矿数量



                    decimal TomoroCount = (decimal)(rm.Next(TmpMachineType[0].MinProfit, TmpMachineType[0].MaxProfit + 1) + MachineModel.OtherOREBonus);
                    string Login_Account = member.Login_Account;
                    decimal MachineCount = ToDayCount;
                    int MachineId = MachineModel.id;
                    string ID = DateTime.Now.ToString("yyMMddhhmmssffff") + ss.ToString();
                    decimal Income = ToDayCount;
                    decimal Pay = 0;
                    decimal Remain = member.MRC +member.cAmt + ToDayCount;
                    string Kind = "1";
                    string Remark = "自动挖矿";
                    int result = MachineBLL.AccountOREByDays(Login_Account, MachineCount, MachineId, ID, Income, Pay, Remain, Kind, Remark, TomoroCount);
                    if (result == 0)
                    {
                        //表示成功
                        if (ss == 999)
                        {
                            ss = 10;
                        }
                        UpdateExecuteTimeError("自动挖矿收益", 2);
                    }
                    else if (result < 0)
                    {
                        //表示储存过程出问题了
                        AddExecuteTimeError("自动挖矿收益储存过程出问题了", 2);
                    }
                    else
                    {
                        //表示参数错误
                        AddExecuteTimeError("自动挖矿收益储存过程出问题了表示参数错误", 2);
                    }
                }
            }
        }



        #endregion

        #region 扫描矿机过期的

        public void MachinePass() 
        {
            ZGZY.SQLServerDAL.BS_Machine MachineBLL = new ZGZY.SQLServerDAL.BS_Machine();
            int result=MachineBLL.MachinePass();
            if (result > 0)
            {
                AddExecuteTimeError(string.Format("矿机过期：{0}(个)", result), 1);
            }
            //UpdateExecuteTimeError("自动冻结过期矿机", 3);
        }


        #endregion

        #region 更新高特币默认设定的价格
        public void UpdateMrcPrice()
        {
            DataSet dt = new BS_appreciation().GetList("DATEDIFF(day,addtime,GETDATE())=0 order by addtime desc");
            if (dt != null && dt.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    if (DateTime.Now >= Convert.ToDateTime(dr["addtime"]))
                    {
                        try
                        {
                            Model.BS_Configuration m = new BS_Configuration().GetModel(5);
                            if (m.value == dr["TodayPrice"].ToString())
                            {
                                break;
                            }
                            m.value = dr["TodayPrice"].ToString();
                            new BS_Configuration().Update(m);

                            UpdateExecuteTimeError("更新高特币价格执行成功", 4);
                            break;
                        }
                        catch (Exception e)
                        {
                            AddExecuteTimeError("更新高特币价格执行失败" + e.Message, 2);
                        }
                       
                    }
                }
            }
        }

        #endregion

        #region 交易三天未打款的冻结账号
        public void FrozenMember()
        {
            int dealday = Common.Utils.StrToInt(new BS_Configuration().GetModel(11).value, 0);

            #region 交易未打款
            string where = "state=2 and DATEDIFF(day,addtime,GETDATE())>=" + dealday + "";
            DataTable dt = new BTtransactionson().GetBTtransactionsonList(where).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                #region 交易金额返回，冻结会员，发送短信
                Model.BTtransaction tion = new BTtransaction().GetBTtransactionModel(dr["BTtransactionID"].ToString());
                if (tion != null)
                {
                    //返回相应的金额
                    decimal dealMoney_son = Convert.ToDecimal(dr["dealmoney"]);   //匹配金额
                    Model.BS_Customers mem = new CustomerDA().GetCustomerByLoginAccount(tion.userID);
                    if (mem != null)
                    {
                        if (new BTtransactionson().AutoCancelOrder(tion.ID, dr["ID"].ToString(), dr["buyuserID"].ToString(), dealMoney_son) == 0)
                        {
                            string result = "";
                            try
                            {
                                //发送短信 通知卖家
                                result = Common.PhoneCode.SendMessage(mem.Mobile, "因买家未能及时打款平台已撤回订单并多买家进行了惩罚！详情请登陆平台查看。");
                                UpdateExecuteTimeError("冻结过时未交易会员成功", 5);
                            }
                            catch (Exception e)
                            {
                                AddExecuteTimeError("冻结过时未交易会员成功执行失败" + e.Message + "短信验证：" + result, 2);
                            }


                        }
                    }
                }
                #endregion
            }
            #endregion

            #region 打款未确认
            int dealday2 = Common.Utils.StrToInt(new BS_Configuration().GetModel(12).value, 0);
            string where1 = "state=2 and DATEDIFF(day,transfertime,GETDATE())>=" + dealday2 + "";
            DataTable dt1 = new BTtransactionson().GetBTtransactionsonList(where).Tables[0];
            foreach (DataRow dr in dt1.Rows)
            {
                //修改状态子订单客服处理
                Model.BTtransactionson son = new BTtransactionson().GetBTtransactionsonModel(dr["ID"].ToString());
                Model.BS_Customers mem = new CustomerDA().GetCustomerByLoginAccount(dr["buyuserID"].ToString());
                if (son != null && mem!=null)
                {
                    string result = "";
                    son.state = 3;
                    try
                    {
                        if (new BTtransactionson().UpdateBTtransactionson(son))
                        {
                            result = Common.PhoneCode.SendMessage(mem.Mobile, "因卖家未能及时确认订单平台已转交至客服部处理！请协助客服人员上传打款凭证.");
                            UpdateExecuteTimeError("交易未确认转人工处理成功", 6);
                        }
                    }
                    catch (Exception e)
                    {
                        AddExecuteTimeError("交易未确认转人工处理成功执行失败" + e.Message + "短信验证：" + result, 2);
                    }
                }
            }
            #endregion
        }
        #endregion

        #endregion

        #region 插入事件问题

        /// <summary>
        /// 获得事件的最后执行时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetEventLastExecuteTimeByKey(string id)
        {

            string commandText = "SELECT TOP 1 [executetime] FROM [BS_eventlogs] WHERE [state]=1 and id=" + id + " ORDER BY [id] DESC";
            DataTable dt = SqlHelper.Query(commandText).Tables[0];
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return DateTime.Parse(dt.Rows[0]["executetime"].ToString());
                }
            }
            return DateTime.Now.AddDays(-1);

        }

        /// <summary>
        /// 插入事件失败执行时间
        /// </summary>
        public void AddExecuteTimeError(string message, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BS_eventlogs(");
            strSql.Append("executetime,state,message,type");
            strSql.Append(") values (");
            strSql.Append("@executetime,@state,@message,0");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@executetime", SqlDbType.DateTime) ,            
                        new SqlParameter("@state", SqlDbType.Int,4) ,  
                        new SqlParameter("@message", SqlDbType.Text)   
            };

            parameters[0].Value = DateTime.Now;
            parameters[1].Value = state;
            parameters[2].Value = message;
            SqlHelper.GetSingle(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 插入事件失败执行时间
        /// </summary>
        public void UpdateExecuteTimeError(string message, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BS_eventlogs set");
            strSql.Append(" executetime=@executetime,");
            strSql.Append(" message=@message");
            strSql.Append(" where  state=1 and id=@id");
            SqlParameter[] parameters = {
			            new SqlParameter("@executetime", SqlDbType.DateTime) ,    
                        new SqlParameter("@id", SqlDbType.Int,32) , 
                        new SqlParameter("@message", SqlDbType.Text)   
            };

            parameters[0].Value = DateTime.Now;
            parameters[1].Value = id;
            parameters[2].Value = message;
            SqlHelper.GetSingle(strSql.ToString(), parameters);
        }
        #endregion

        #endregion


    }


}


