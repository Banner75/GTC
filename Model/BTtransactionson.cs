using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    //BT交易子表
    public class BTtransactionson
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
        /// BT交易主表id
        /// </summary>		
        private string _bttransactionid;
        public string BTtransactionID
        {
            get { return _bttransactionid; }
            set { _bttransactionid = value; }
        }
        /// <summary>
        /// 交易数量
        /// </summary>		
        private decimal _dealmoney;
        public decimal dealmoney
        {
            get { return _dealmoney; }
            set { _dealmoney = value; }
        }
        /// <summary>
        /// 1.取消2.交易中3.管理员介入4.成功 5.失败 6.等待确认
        /// </summary>		
        private int _state;
        public int state
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 会员ID（买）
        /// </summary>		
        private string _buyuserid;
        public string buyuserID
        {
            get { return _buyuserid; }
            set { _buyuserid = value; }
        }
        /// <summary>
        /// 购买方式（1.支付宝2.银行转账）
        /// </summary>		
        private int _buytype;
        public int buytype
        {
            get { return _buytype; }
            set { _buytype = value; }
        }
        /// <summary>
        /// 转账流水
        /// </summary>		
        private string _transfernum;
        public string transfernum
        {
            get { return _transfernum; }
            set { _transfernum = value; }
        }
        /// <summary>
        /// 转账时间
        /// </summary>		
        private DateTime _transfertime;
        public DateTime transfertime
        {
            get { return _transfertime; }
            set { _transfertime = value; }
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
        /// <summary>
        /// 交易时间
        /// </summary>		
        private DateTime _addtime;
        public DateTime addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// 申诉内容
        /// </summary>		
        private string _appealcontent;
        public string appealcontent
        {
            get { return _appealcontent; }
            set { _appealcontent = value; }
        }
        private decimal _rate = 0M;
        /// <summary>
        /// 当前MRC兑换人民币价格
        /// </summary>
        public decimal rate
        {
            set { _rate = value; }
            get { return _rate; }
        }
    }
}

