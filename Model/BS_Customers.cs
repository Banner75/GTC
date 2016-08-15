using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    /// <summary>
    /// 会员表
    /// </summary>
    public class BS_Customers 
    {
        #region Model
        private string _login_account;
        private string _nick_name;
        private string _truly_name;
        private int? _sex = 1;
        private string _card_kind;
        private string _card_no;
        private string _email;
        private string _mobile;
        private string _country;
        private string _bank;
        private string _bank_user;
        private string _bank_account;
        private string _bank_branch;
        private string _alipay;
        private string _parent = "0";
        private string _user_grade = "0";
        private DateTime? _register_date = DateTime.Now;
        private decimal _mrc = 0M;
        private decimal _ore = 0M;
        private decimal _cAmt = 0M;
        private int _state = 1;
        private int? _mills_num = 0;
        private string _login_pwd;
        private string _pay_pwd;
        private string _remark;
        private int? _created_by = 0;
        private DateTime? _created_date = DateTime.Now;
        private int? _last_updated_by = 0;
        private DateTime? _last_updated_date = DateTime.Now;
        private int? _region = 0;
        private int _otherorebonus = 0;
        private string _person_liable;
        private int _class;
        private int _stare = 0;

        
        /// <summary>
        /// 登录帐号
        /// </summary>
        public string Login_Account
        {
            set { _login_account = value; }
            get { return _login_account; }
        }
        /// <summary>
        /// 会员昵称
        /// </summary>
        public string Nick_Name
        {
            set { _nick_name = value; }
            get { return _nick_name; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Truly_Name
        {
            set { _truly_name = value; }
            get { return _truly_name; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string Card_Kind
        {
            set { _card_kind = value; }
            get { return _card_kind; }
        }
        /// <summary>
        /// 证件号
        /// </summary>
        public string Card_No
        {
            set { _card_no = value; }
            get { return _card_no; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 银行
        /// </summary>
        public string Bank
        {
            set { _bank = value; }
            get { return _bank; }
        }
        /// <summary>
        /// 开户人
        /// </summary>
        public string Bank_User
        {
            set { _bank_user = value; }
            get { return _bank_user; }
        }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string Bank_Account
        {
            set { _bank_account = value; }
            get { return _bank_account; }
        }
        /// <summary>
        /// 开户地址
        /// </summary>
        public string Bank_Branch
        {
            set { _bank_branch = value; }
            get { return _bank_branch; }
        }
        /// <summary>
        /// 支付宝
        /// </summary>
        public string Alipay
        {
            set { _alipay = value; }
            get { return _alipay; }
        }
        /// <summary>
        /// 推荐人
        /// </summary>
        public string Parent
        {
            set { _parent = value; }
            get { return _parent; }
        }
        /// <summary>
        /// 所属责任人
        /// </summary>
        public string Person_Liable
        {
            get { return _person_liable; }
            set { _person_liable = value; }
        }
        /// <summary>
        /// 用户级别
        /// </summary>
        public string User_Grade
        {
            set { _user_grade = value; }
            get { return _user_grade; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? Register_Date
        {
            set { _register_date = value; }
            get { return _register_date; }
        }
        /// <summary>
        /// 高特币
        /// </summary>
        public decimal MRC
        {
            set { _mrc = value; }
            get { return _mrc; }
        }
        /// <summary>
        /// 矿机币
        /// </summary>
        public decimal ORE
        {
            set { _ore = value; }
            get { return _ore; }
        }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal cAmt
        {
            set { _cAmt = value; }
            get { return _cAmt; }
        }

        /// <summary>
        /// 1.正常，2.冻结，3.删除
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 矿机数量
        /// </summary>
        public int? Mills_Num
        {
            set { _mills_num = value; }
            get { return _mills_num; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Login_PWD
        {
            set { _login_pwd = value; }
            get { return _login_pwd; }
        }
        /// <summary>
        /// 支付密码
        /// </summary>
        public string Pay_PWD
        {
            set { _pay_pwd = value; }
            get { return _pay_pwd; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 创建于
        /// </summary>
        public int? Created_By
        {
            set { _created_by = value; }
            get { return _created_by; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created_Date
        {
            set { _created_date = value; }
            get { return _created_date; }
        }
        /// <summary>
        /// 最后操作于
        /// </summary>
        public int? Last_Updated_By
        {
            set { _last_updated_by = value; }
            get { return _last_updated_by; }
        }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime? Last_Updated_Date
        {
            set { _last_updated_date = value; }
            get { return _last_updated_date; }
        }
        /// <summary>
        /// 0:左，1:右
        /// </summary>
        public int? Region
        {
            set { _region = value; }
            get { return _region; }
        }
        /// <summary>
        /// 每日增加额外挖矿
        /// </summary>
        public int OtherOREBonus
        {
            set { _otherorebonus = value; }
            get { return _otherorebonus; }
        }
        /// <summary>
        /// 代表用户诚信分数
        /// </summary>
        public int stare
        {
            set { _stare = value; }
            get { return _stare; }
        }
        /// <summary>
        /// 会员类型
        /// </summary>
        public int Class
        {
            set { _class = value; }
            get { return _class; }
        }

        #endregion Model    
    }
}
