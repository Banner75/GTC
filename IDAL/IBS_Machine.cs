/**  版本信息模板在安装目录下，可自行修改。
* BS_Machine.cs
*
* 功 能： N/A
* 类 名： BS_Machine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/2 10:45:26   N/A    初版
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
	/// 接口层BS_Machine
	/// </summary>
	public interface IBS_Machine
	{
		#region  成员方法
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(ZGZY.Model.BS_Machine model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZGZY.Model.BS_Machine model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		bool DeleteList(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZGZY.Model.BS_Machine GetModel(int id);
		ZGZY.Model.BS_Machine DataRowToModel(DataRow row);
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
        ZGZY.Model.BS_Machine GetModelByAccount(string Login_Account);
        /// <summary>
        /// 每天发放矿机币
        /// </summary>
        /// <returns></returns>
        int AccountOREByDays(string Login_Account, decimal MachineCount, int MachineId, string ID, decimal Income, decimal Pay, decimal Remain, string Kind, string Remark, decimal TomoroCount);


        /// <summary>
        /// 购买矿机
        /// </summary>
        /// <returns></returns>
        int BuyMachine(int type, string Login_Account, DateTime start_run_time, DateTime end_run_time, int MachinePrice, string Remark, int TodayCount);

        /// <summary>
        /// 续租矿机
        /// </summary>
        /// <returns></returns>
        int ReletMachine(DateTime start_run_time, DateTime end_run_time, DateTime count_time, int status, int id, int MachinePrice, string Login_Account, string Remark);
        

		#endregion  MethodEx

        /// <summary>
        /// 根据用户账号查询是否有矿机
        /// </summary>
        /// <param name="Login_Account"></param>
        /// <returns></returns>
        ZGZY.Model.BS_Machine GetMachineByAccount(string Login_Account);
	} 
}
