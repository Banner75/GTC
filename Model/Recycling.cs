using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    /// <summary>
    /// MRC币系统回收
    /// </summary>
    public class Recycling
    {
        #region Model
        private string _id;
        private string _userid;
        private decimal? _showmoney;
        private DateTime? _addtime;
        private DateTime? _updatetime;
        private int _state = 1;
        private int? _handleadminid;
        private int? _transferadminid;
        private string _transfernum;
        private DateTime? _transfertime;
        private decimal _rate = 0M;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ShowMoney
        {
            set { _showmoney = value; }
            get { return _showmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? updatetime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 1:申请回收中，2:回收处理中，3:交易成功，4:交易失败，5:撤销交易
        /// </summary>
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 接单管理员ID
        /// </summary>
        public int? HandleAdminID
        {
            set { _handleadminid = value; }
            get { return _handleadminid; }
        }
        /// <summary>
        /// 转账管理员ID
        /// </summary>
        public int? TransferAdminID
        {
            set { _transferadminid = value; }
            get { return _transferadminid; }
        }
        /// <summary>
        /// 转账金额
        /// </summary>
        public string transfernum
        {
            set { _transfernum = value; }
            get { return _transfernum; }
        }
        /// <summary>
        /// 转账时间
        /// </summary>
        public DateTime? transfertime
        {
            set { _transfertime = value; }
            get { return _transfertime; }
        }
        /// <summary>
        /// 购买汇率
        /// </summary>
        public decimal rate
        {
            set { _rate = value; }
            get { return _rate; }
        }
        #endregion Model
    }
}
