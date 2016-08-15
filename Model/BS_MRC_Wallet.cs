using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ZGZY.Model{
	 	//BS_MRC_Wallet
		public class BS_MRC_Wallet
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 数量
        /// </summary>		
		private int _sum;
        public int Sum
        {
            get{ return _sum; }
            set{ _sum = value; }
        }        
		/// <summary>
		/// 1.支出 2.收入
        /// </summary>		
		private int _type;
        public int Type
        {
            get{ return _type; }
            set{ _type = value; }
        }        
		/// <summary>
		/// 暂无
        /// </summary>		
		private int _status;
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		/// <summary>
		/// 备注
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		/// <summary>
		/// 创建日期
        /// </summary>		
		private DateTime _createdate;
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
		/// <summary>
		/// 用户名
        /// </summary>		
		private string _login_account;
        public string Login_Account
        {
            get{ return _login_account; }
            set{ _login_account = value; }
        }        
		   
	}
}

