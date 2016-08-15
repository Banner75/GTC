using System;
using System.Data;
namespace ZGZY.IDAL {
	/// <summary>
	/// 接口层BS_MRC_Wallet
	/// </summary>
	public interface IBS_MRC_Wallet
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  Add(ZGZY.Model.BS_MRC_Wallet model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZGZY.Model.BS_MRC_Wallet model);
		/// <summary>
		/// 删除数据
		/// </summary>
		bool Delete(int ID);
				bool DeleteList(string IDlist );
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZGZY.Model.BS_MRC_Wallet GetModel(int ID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法

        /// <summary>
        /// 获取美瑞币流水
        /// </summary>
        /// <param name="strwhere">条件</param>
        /// <returns></returns>
        DataTable GetMRCWalletLogList(string strwhere);
        int GetMRCPaySum(string LoginAccount);

	} 
}