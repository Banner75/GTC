using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ZGZY.IDAL
{
   public interface IBTtransactionson
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
       int AddBTtransactionson(ZGZY.Model.BTtransactionson model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
       bool UpdateBTtransactionson(ZGZY.Model.BTtransactionson model);
        /// <summary>
        /// 删除数据
        /// </summary>
       bool DeleteBTtransactionson(string ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ZGZY.Model.BTtransactionson GetBTtransactionsonModel(string ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetBTtransactionsonList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetBTtransactionsonList(int Top, string strWhere, string filedOrder);
       /// <summary>
        /// 获得数据列表
       /// </summary>
       /// <param name="strWhere"></param>
       /// <returns></returns>
        DataSet GetviewBTtransactionsonList(string strWhere);
       /// <summary>
       /// 获取bt总量
       /// </summary>
       /// <param name="where">条件</param>
       /// <returns></returns>
        string GetSumBTtransactionson(string where);
        int BuyMRC(string ID, string transactionID, int SaleMRC, string userID, decimal rate, int state);
        int CancelOrder(string Sonid, string BTID, decimal dealmoney, string BuyUserID);
        int AutoCancelOrder(string ID, string Son_ID, string LoginAccount, decimal dealmoney);
        int ConfirmOrder(string Son_ID, string SaleLoginAccount);
    }
}
