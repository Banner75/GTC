using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ZGZY.Model{
	 	//BS_NoticesType
		public class BS_NoticesType
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
		/// 类型名称
        /// </summary>		
		private string _typename;
        public string TypeName
        {
            get{ return _typename; }
            set{ _typename = value; }
        }        
		/// <summary>
		/// State
        /// </summary>		
		private int _state;
        public int State
        {
            get{ return _state; }
            set{ _state = value; }
        }        
		/// <summary>
		/// 排序
        /// </summary>		
		private int _displayorder;
        public int DisplayOrder
        {
            get{ return _displayorder; }
            set{ _displayorder = value; }
        }        
		   
	}
}

