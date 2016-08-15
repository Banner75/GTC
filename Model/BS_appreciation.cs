/**  版本信息模板在安装目录下，可自行修改。
* BS_appreciation.cs
*
* 功 能： N/A
* 类 名： BS_appreciation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/11 10:45:53   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ZGZY.Model
{
	/// <summary>
	/// BS_appreciation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_appreciation
	{
		public BS_appreciation()
		{}
		#region Model
		private int _id;
		private DateTime _addtime= DateTime.Now;
		private decimal _todayprice=0M;
		private decimal _lastprice=0M;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 新增时间
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 今日价格
		/// </summary>
		public decimal TodayPrice
		{
			set{ _todayprice=value;}
			get{return _todayprice;}
		}
		/// <summary>
		/// 上次价格
		/// </summary>
		public decimal LastPrice
		{
			set{ _lastprice=value;}
			get{return _lastprice;}
		}
		#endregion Model

	}
}

