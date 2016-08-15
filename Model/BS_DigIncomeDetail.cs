/**  版本信息模板在安装目录下，可自行修改。
* BS_MachineLog.cs
*
* 功 能： 矿币流水
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
	/// BS_DigIncomeDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_DigIncomeDetail
	{
		public BS_DigIncomeDetail()
		{}
		#region Model
		private string _id;
		private decimal? _income;
		private decimal? _pay;
		private decimal? _remain;
		private string _subaccount;
		private int? _machine;
		private string _kind;
		private DateTime? _occur_date;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 收入
		/// </summary>
		public decimal? Income
		{
			set{ _income=value;}
			get{return _income;}
		}
		/// <summary>
		/// 支出
		/// </summary>
		public decimal? Pay
		{
			set{ _pay=value;}
			get{return _pay;}
		}
		/// <summary>
		/// 余额
		/// </summary>
		public decimal? Remain
		{
			set{ _remain=value;}
			get{return _remain;}
		}
		/// <summary>
		/// 会员id
		/// </summary>
		public string SubAccount
		{
			set{ _subaccount=value;}
			get{return _subaccount;}
		}
		/// <summary>
		/// 挖矿收入才需要记录矿机id
		/// </summary>
		public int? Machine
		{
			set{ _machine=value;}
			get{return _machine;}
		}
		/// <summary>
		/// 矿机类型：1：小矿，2：中矿，3：大矿
		/// </summary>
		public string Kind
		{
			set{ _kind=value;}
			get{return _kind;}
		}
		/// <summary>
		/// 发生时间
		/// </summary>
		public DateTime? Occur_Date
		{
			set{ _occur_date=value;}
			get{return _occur_date;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

