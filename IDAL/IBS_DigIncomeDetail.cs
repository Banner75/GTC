/**  版本信息模板在安装目录下，可自行修改。
* BS_DigIncomeDetail.cs
*
* 功 能： N/A
* 类 名： BS_DigIncomeDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/2 10:45:25   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace ZGZY.IDAL
{
	/// <summary>
	/// 接口层BS_DigIncomeDetail
	/// </summary>
	public interface IBS_DigIncomeDetail
	{
		#region  成员方法
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(ZGZY.Model.BS_DigIncomeDetail model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZGZY.Model.BS_DigIncomeDetail model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ID);
		bool DeleteList(string IDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZGZY.Model.BS_DigIncomeDetail GetModel(string ID);
		ZGZY.Model.BS_DigIncomeDetail DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx
        /// <summary>
        /// 获取收益总数
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="day">0等于今天</param>
        /// <returns></returns>
        decimal GetDailyIncome(string Account, int day);
        decimal GetDailyIncome(int day);
        /// <summary>
        /// 奖金发放
        /// </summary>
        /// <param name="Login_Account"></param>
        /// <param name="bonus"></param>
        /// <param name="balance"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        int AddLssuebonus(string Login_Account, decimal bonus, decimal balance, string ID, string Remark);
        decimal GetIncomeCount(string Account, DateTime stare, DateTime end, int type);
        decimal GetDailyIncomeFromToDay(string Account, int type);
		#endregion  MethodEx


        /// <summary>
        /// 获取矿机币流水
        /// </summary>
        /// <param name="strwhere">条件</param>
        /// <returns></returns>
        DataTable GetDigIncomeDetailList(string strwhere);

        decimal GetBonus(string Account, int day);
	} 
}
