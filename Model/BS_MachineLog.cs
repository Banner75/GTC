/**  版本信息模板在安装目录下，可自行修改。
* BS_MachineLog.cs
*
* 功 能： 矿机生产日志
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
	/// BS_MachineLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_MachineLog
	{
		public BS_MachineLog()
		{}
		#region Model
		private int _id;
		private string _give_account;
		private string _receive_account;
		private int _machine_id;
		private DateTime _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 赠送人
		/// </summary>
		public string give_account
		{
			set{ _give_account=value;}
			get{return _give_account;}
		}
		/// <summary>
		/// 获赠人
		/// </summary>
		public string receive_account
		{
			set{ _receive_account=value;}
			get{return _receive_account;}
		}
		/// <summary>
		/// 机器主键
		/// </summary>
		public int machine_id
		{
			set{ _machine_id=value;}
			get{return _machine_id;}
		}
		/// <summary>
		/// 转赠时间
		/// </summary>
		public DateTime createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

