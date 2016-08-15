using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    //BT交易主表
    public class BTtransaction
    {

        /// <summary>
        /// ID
        /// </summary>		
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 会员ID（卖）
        /// </summary>		
        private string _userid;
        public string userID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        /// <summary>
        /// 总出售数量
        /// </summary>		
        private decimal _practical_money;
        public decimal practical_money
        {
            get { return _practical_money; }
            set { _practical_money = value; }
        }

        /// <summary>
        /// 总出售数量
        /// </summary>		
        private decimal _allmoney;
        public decimal allmoney
        {
            get { return _allmoney; }
            set { _allmoney = value; }
        }
        /// <summary>
        /// 未出售数量
        /// </summary>		
        private decimal _showmoney;
        public decimal showmoney
        {
            get { return _showmoney; }
            set { _showmoney = value; }
        }
        /// <summary>
        /// 成交中数量
        /// </summary>		
        private decimal _dealmoney;
        public decimal dealmoney
        {
            get { return _dealmoney; }
            set { _dealmoney = value; }
        }
        /// <summary>
        /// 已成交数量
        /// </summary>		
        private decimal _salemoney;
        public decimal salemoney
        {
            get { return _salemoney; }
            set { _salemoney = value; }
        }
        /// <summary>
        /// 新增时间
        /// </summary>		
        private DateTime _addtime;
        public DateTime addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// 1.取消2.交易中
        /// </summary>		
        private int _state;
        public int state
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 状态更新时间
        /// </summary>		
        private DateTime _updatetime;
        public DateTime updatetime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
    }
}
