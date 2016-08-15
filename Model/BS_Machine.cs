/**  版本信息模板在安装目录下，可自行修改。
* BS_MachineLog.cs
*
* 功 能： 矿机表
* 类 名： BS_MachineLog
*
* Ver    变更日期             负责人  DeanWinchester
* ───────────────────────────────────
* V0.01  2016/7/2 10:45:26   N/A    初版
*
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ZGZY.Model
{
    /// <summary>
    /// BS_Machine:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BS_Machine
    {

        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 1小，2中，3大
        /// </summary>		
        private int _type;
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 1未激活，2已激活，3过期
        /// </summary>		
        private int _status;
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 当前矿机拥有者
        /// </summary>		
        private string _login_account;
        public string Login_Account
        {
            get { return _login_account; }
            set { _login_account = value; }
        }
        /// <summary>
        /// 产生的矿币数量
        /// </summary>		
        private decimal _sum;
        public decimal sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        /// <summary>
        /// 其他奖金
        /// </summary>		
        private int _otherorebonus;
        public int OtherOREBonus
        {
            get { return _otherorebonus; }
            set { _otherorebonus = value; }
        }
        /// <summary>
        /// 矿机初始化时间
        /// </summary>		
        private DateTime _createrdate;
        public DateTime createrdate
        {
            get { return _createrdate; }
            set { _createrdate = value; }
        }
        /// <summary>
        /// 开始挖矿时间
        /// </summary>		
        private DateTime _start_run_time;
        public DateTime start_run_time
        {
            get { return _start_run_time; }
            set { _start_run_time = value; }
        }
        /// <summary>
        /// 矿机失效时间
        /// </summary>		
        private DateTime _end_run_time;
        public DateTime end_run_time
        {
            get { return _end_run_time; }
            set { _end_run_time = value; }
        }
        /// <summary>
        /// 最近一次结算的时间
        /// </summary>		
        private DateTime _count_time;
        public DateTime count_time
        {
            get { return _count_time; }
            set { _count_time = value; }
        }
        /// <summary>
        /// 今天获取的总数量
        /// </summary>		
        private int _today_count;
        public int today_count
        {
            get { return _today_count; }
            set { _today_count = value; }
        }


    }
}

