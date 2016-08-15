using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ZGZY.IDAL
{
  public   interface IBTtransaction
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddBTtransaction(ZGZY.Model.BTtransaction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateBTtransaction(ZGZY.Model.BTtransaction model);
        /// <summary>
        /// 删除数据
        /// </summary>
        bool DeleteBTtransaction(string ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ZGZY.Model.BTtransaction GetBTtransactionModel(string ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetBTtransactionList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetBTtransactionList(int Top, string strWhere, string filedOrder);
     
         /// <summary>
        ///  获取bt总量
         /// </summary>
         /// <param name="where"></param>
         /// <returns></returns>
        string GetSumBTtransaction(string where);
      /// <summary>
        /// 出售MRC return -1表示失败 0表示执行成功 >0表示执行失败
        /// </summary>
        /// <param name="transactionID"></param>
        /// <param name="SaleMRC"></param>
        /// <param name="SaleUserAccount"></param>
        /// <param name="BTLogType"></param>
        /// <param name="BTLogState"></param>
        /// <param name="Logcontent"></param>
        /// <returns></returns>
        int addSaleMRC(string transactionID, decimal SaleMRC, string SaleUserAccount, int BTLogType, int BTLogState, string Logcontent, decimal practical_money);
        /// <summary>
        ///卖出MRC到回收大厅，增加回收记录和扣除用户MRC币
       /// </summary>
       /// <param name="id"></param>
       /// <param name="userID"></param>
       /// <param name="sellMoney"></param>
       /// <param name="deMoney"></param>
       /// <param name="addtime"></param>
       /// <param name="updatetime"></param>
       /// <param name="state"></param>
       /// <returns></returns>
         int addRecyclingMRC(string id, string userID, decimal sellMoney, decimal deMoney, DateTime addtime, DateTime updatetime, int state);
    }
}
