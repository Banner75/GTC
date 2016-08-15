using System;
using System.Data;
namespace ZGZY.IDAL {
	/// <summary>
	/// 接口层BS_NoticesType
	/// </summary>
	public interface IBS_NoticesType
	{
		#region  成员方法
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  Add(ZGZY.Model.BS_NoticesType model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZGZY.Model.BS_NoticesType model);
		/// <summary>
		/// 删除数据
		/// </summary>
		bool Delete(int ID);				
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZGZY.Model.BS_NoticesType GetModel(int ID);
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

        /// <summary>
        /// 批量删除新闻类型
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int DeleteRange(string ids);
        

		#endregion  成员方法
	} 
}