using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.App_Start
{
    /// <summary>
    /// 动作功能： 奖金分发
    /// 编写人员： DeanWinchester
    /// 编写日期： 2016/07/08
    /// </summary>
    /// <returns></returns>
    public class CalculationBonus : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            new ZGZY.BLL.EventInfo().DigInCome();
            new ZGZY.BLL.EventInfo().CalculationBonus();
            //Dictionary<string, string[]> Parent_Customer = new Dictionary<string, string[]>();//"自己,责任人"
            //Dictionary<string, int> Parent_Machine = new Dictionary<string, int>();//"自己,矿机"
            //Dictionary<string, decimal> Parent_Sum = new Dictionary<string, decimal>();//"自己,今日收益"
            //Dictionary<string, decimal> PersonBonus = new Dictionary<string, decimal>();//用来存放自己下线的挖矿收益，用于计算今日所得奖金 

            //#region 从没有推荐人的会员开始计算
            ////正常用户的
            //DataTable dt = new ZGZY.BLL.CustomerBL().GetList(" State=1 ").Tables[0];
            //if (dt != null)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        string Account = dt.Rows[i]["Login_Account"].ToString();

            //        #region 判断今日是否发放过奖金 ==如果已发放跳出循环找下一条
            //        if (new ZGZY.BLL.BS_DigIncomeDetail().GetDailyIncomeFromToDay(Account, 2)>0)
            //        {
            //            continue;
            //        }
            //        #endregion

            //        //首先判断是否有两个下线，
            //        DataTable first_son = new ZGZY.BLL.CustomerBL().GetList("State=1 and Person_Liable='" + Account + "' ").Tables[0];
            //        if (first_son != null)
            //        {
            //            if (first_son.Rows.Count == 2)
            //            {
            //                ZGZY.Model.BS_Machine Machine0 = new ZGZY.BLL.BS_Machine().GetModelByAccount(first_son.Rows[0]["Login_Account"].ToString());
            //                ZGZY.Model.BS_Machine Machine1 = new ZGZY.BLL.BS_Machine().GetModelByAccount(first_son.Rows[1]["Login_Account"].ToString());
            //                if (Machine0!=null &&Machine1!=null)
            //                {
            //                    PersonBonus.Add(Account, new ZGZY.BLL.BS_DigIncomeDetail().GetDailyIncome(Account, 0));
            //                    //判断分发那台矿机的收益
            //                    int m0 = Machine0.type;
            //                    int m1 = Machine1.type;
            //                    decimal money = 0;
            //                    if (m0 > m1)
            //                    {
            //                        money =new ZGZY.BLL.BS_DigIncomeDetail().GetDailyIncome(first_son.Rows[1]["Login_Account"].ToString(), 0) ;
            //                        //发M1
            //                    }
            //                    else if (m0 < m1 || m0 == m1)
            //                    {
            //                        money = new ZGZY.BLL.BS_DigIncomeDetail().GetDailyIncome(first_son.Rows[0]["Login_Account"].ToString(), 0) ;
            //                        //发M0
            //                    }
            //                    //计算第一层收益
            //                    if (PersonBonus.ContainsKey(Account))
            //                    {
            //                        decimal commission = PersonBonus[Account];
            //                        PersonBonus[Account] = commission + money;
            //                    }
            //                    else
            //                    {
            //                        PersonBonus[Account] = money;
            //                    }
            //                    //后面计算一下几层的

            //                    FindOtherSon(Account, first_son.Rows[0]["Login_Account"].ToString(), first_son.Rows[1]["Login_Account"].ToString(), m0, m1, ref  PersonBonus);

            //                    //循环可以分发的会员--分发奖金

            //                }
            //            }
            //        }
            //        continue;
            //    }
            //    //循环所有用户所得的金额
            //    int iss = 10;
            //    foreach (KeyValuePair<string, decimal> kv in PersonBonus)
            //    {
            //        ZGZY.Model.BS_Customers m = new ZGZY.BLL.CustomerBL().GetCustomerByID(kv.Key);
            //        if (m != null)
            //        {
            //            if (m.State == 1)//属于正常用户发放金额
            //            {
            //                decimal balance = m.ORE + kv.Value;
            //                iss++;
            //                decimal bonus = kv.Value * 0.2M;//  计算百分比

            //                #region 判断此用户租期内是否收取奖金达到上限(未做)
            //                ZGZY.Model.BS_Machine Machine = new ZGZY.BLL.BS_Machine().GetModelByAccount(kv.Key);
            //                ZGZY.Model.BS_MachineConfig mc=new ZGZY.BLL.BS_MachineConfig().GetModel(Machine.type);
            //                decimal countBonus=new ZGZY.BLL.BS_DigIncomeDetail().GetIncomeCount(kv.Key, Machine.start_run_time, Machine.end_run_time, 2);
            //                if (countBonus > mc.Maximum)
            //                {
            //                    //收益达到上限不再计算收益
            //                    continue;
            //                }
            //                else if (countBonus+bonus>mc.Maximum)
            //                {
            //                    decimal newbonus=countBonus + bonus - Convert.ToDecimal(mc.Maximum);
            //                    bonus = bonus - newbonus;
            //                }

            //                #endregion

            //                if (bonus > 0)
            //                {
            //                    new ZGZY.BLL.BS_DigIncomeDetail().AddLssuebonus(kv.Key, bonus, balance, DateTime.Now.ToString("yyMMddhhssmmffff") + iss.ToString(), "矿区总收入：" + kv.Value + "");
            //                }
            //                if (iss == 999)
            //                {
            //                    iss = 10;
            //                }
            //            }
            //        }
            //    }
            //}
           

            //#endregion
        }

        void FindOtherSon(string BonusAccount, string leftAccount, string rightAccount, int leftmachine, int rightmachine,  ref Dictionary<string, decimal> PersonBonus)
        {
           // PersonBonus = new Dictionary<string, decimal>();

            string l_account = "";
            string r_account = "";
            decimal l_money = 0;
            decimal r_money = 0;
            int l_machine = 0;
            int r_machine = 0;
            decimal bonus = 0;
            DataTable son_l = new ZGZY.BLL.CustomerBL().GetList(" Person_Liable='" + leftAccount + "' ").Tables[0];
            if (son_l != null)
            {
                if (son_l.Rows.Count > 0)
                {
                    for (int i = 0; i < son_l.Rows.Count; i++)
                    {
                        if (son_l.Rows[i]["region"].ToString() == "0")
                        {
                            ZGZY.Model.BS_Machine Machine = new ZGZY.BLL.BS_Machine().GetModelByAccount(r_account);
                            if (Machine != null)
                            {
                                //就是他
                                l_account = son_l.Rows[i]["Login_Account"].ToString();
                                l_money = new ZGZY.BLL.BS_DigIncomeDetail().GetDailyIncome(l_account, 0);
                                l_machine = Machine.type;
                                break;
                            }
                        }
                    }
                }
            }

            DataTable son_r = new ZGZY.BLL.CustomerBL().GetList(" Person_Liable='" + rightAccount + "' ").Tables[0];
            if (son_r != null)
            {
                if (son_r.Rows.Count > 0)
                {
                    for (int i = 0; i < son_r.Rows.Count; i++)
                    {
                        //判断存在运行中的矿机才可以作为分奖金条件
                        if (son_r.Rows[i]["region"].ToString() == "0")
                        {
                            ZGZY.Model.BS_Machine Machine = new ZGZY.BLL.BS_Machine().GetModelByAccount(r_account);           
                            if (Machine != null)
                            {
                                r_account = son_r.Rows[i]["Login_Account"].ToString();
                                r_money =  new ZGZY.BLL.BS_DigIncomeDetail().GetDailyIncome(r_account, 0);  
                                r_machine =Machine.type;
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
                FindOtherSon(BonusAccount, l_account, r_account, leftmachine, rightmachine, ref PersonBonus);
            }           
        }
    }
}
