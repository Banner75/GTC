using System;
using System.Data;
namespace ZGZY.IDAL {
	/// <summary>
	/// 接口层BS_Notices
	/// </summary>
	public interface IBS_Notices
	{
		#region  成员方法
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  Add(ZGZY.Model.BS_Notices model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZGZY.Model.BS_Notices model);
		/// <summary>
		/// 删除数据
		/// </summary>
		bool Delete(int ID);
				bool DeleteList(string IDlist );
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZGZY.Model.BS_Notices GetModel(int ID);
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
	} 
}