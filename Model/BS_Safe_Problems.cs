using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ZGZY.Model
{
	 	//BS_Safe_Problems
		public class BS_Safe_Problems
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
		/// Login_Account
        /// </summary>		
		private string _login_account;
        public string LoginAccount
        {
            get{ return _login_account; }
            set{ _login_account = value; }
        }        
		/// <summary>
		/// Question
        /// </summary>		
		private string _question;
        public string Question
        {
            get{ return _question; }
            set{ _question = value; }
        }        
		/// <summary>
		/// Answer
        /// </summary>		
		private string _answer;
        public string Answer
        {
            get{ return _answer; }
            set{ _answer = value; }
        }        
		/// <summary>
		/// 
        /// </summary>		
		private int _state;
        public int State
        {
            get{ return _state; }
            set{ _state = value; }
        }        
		/// <summary>
		/// Created_By
        /// </summary>		
		private int _created_by;
        public int Created_By
        {
            get{ return _created_by; }
            set{ _created_by = value; }
        }        
		/// <summary>
		/// Created_Date
        /// </summary>		
		private DateTime _created_date;
        public DateTime Created_Date
        {
            get{ return _created_date; }
            set{ _created_date = value; }
        }        
		/// <summary>
		/// Last_Updated_By
        /// </summary>		
		private int _last_updated_by;
        public int Last_Updated_By
        {
            get{ return _last_updated_by; }
            set{ _last_updated_by = value; }
        }        
		/// <summary>
		/// Last_Updated_Date
        /// </summary>		
		private DateTime _last_updated_date;
        public DateTime Last_Updated_Date
        {
            get{ return _last_updated_date; }
            set{ _last_updated_date = value; }
        }        
		
		   
	}
}

