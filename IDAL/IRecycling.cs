/**  版本信息模板在安装目录下，可自行修改。
* tbRecycling.cs
*
* 功 能： N/A
* 类 名： tbRecycling
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 10:23:11   N/A    初版
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
    /// 接口层tbRecycling
    /// </summary>
    public interface IRecycling
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        //bool Exists(string ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(ZGZY.Model.Recycling model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(ZGZY.Model.Recycling model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string ID);
        bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ZGZY.Model.Recycling GetModel(string ID);
        ZGZY.Model.Recycling DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx


        /// <summary>
        /// 根据回收MRC币订单编号修改状态
        /// </summary>
        /// <param name="condition">修改的条件</param>
        /// <param name="id">编号</param>
        /// <returns></returns>
        int ChangeStateToRecycling(string condition, string id);

        /// <summary>
        /// 根据条件查询记录总数
        /// </summary>
        int GetTotalCount(string where);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        DataTable GetPager(string strWhere, string orderBy, string order, int pageIndex, int pageSize);

    }
}
