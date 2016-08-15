using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ZGZY.Model{
	 	//BS_MachineConfig
		public class BS_MachineConfig
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 矿机名称
        /// </summary>		
		private string _machinename;
        public string MachineName
        {
            get{ return _machinename; }
            set{ _machinename = value; }
        }        
		/// <summary>
		/// 租价
        /// </summary>		
		private int _machineprice;
        public int MachinePrice
        {
            get{ return _machineprice; }
            set{ _machineprice = value; }
        }        
		/// <summary>
		/// 最小收益
        /// </summary>		
		private int _minprofit;
        public int MinProfit
        {
            get{ return _minprofit; }
            set{ _minprofit = value; }
        }        
		/// <summary>
		/// 最大收益
        /// </summary>		
		private int _maxprofit;
        public int MaxProfit
        {
            get{ return _maxprofit; }
            set{ _maxprofit = value; }
        }        
		/// <summary>
		/// 租期天数
        /// </summary>		
		private int _tenancy;
        public int Tenancy
        {
            get{ return _tenancy; }
            set{ _tenancy = value; }
        }        
		/// <summary>
		/// 矿机小区最大收益
        /// </summary>		
		private int _maximum;
        public int Maximum
        {
            get{ return _maximum; }
            set{ _maximum = value; }
        }

        /// <summary>
        /// 矿机小区见点奖层数
        /// </summary>		
        private int _JianDLayers;
        public int JianDLayers
        {
            get { return _JianDLayers; }
            set { _JianDLayers = value; }
        }   
		   
	}
}

