using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ZGZY.Model;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 会员管理
    /// </summary>
    public interface ICustomerDA
    {
        BS_Customers GetSafeAccountInfo(string account);
        string GetQueryPwd(string account);
        string GetPayPwd(string account);
        List<BS_Safe_Problems> GetSafeProblems(string account);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        BS_Customers GetCustomerByID(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Login_Account">登陆名称</param>
        /// <returns></returns>
        BS_Customers GetCustomerByLoginAccount(string LoginAccount);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<BS_Customers> GetCustomersByCondition(string condition);
        BS_Customers GetCustomerByUserNameAndPWD(string username, string password);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Insert(BS_Customers data);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(BS_Customers data);
        int UpdateMRCorORE(BS_Customers data);
        /// <summary>
        /// 更新MRC
        /// </summary>
        /// 
        int UpdateMRC(string loginAccount, decimal MRCQty);
        /// <summary>
        /// 更新ORE
        /// </summary>
        /// 
        int UpdateORE(string loginAccount, decimal MRCQty);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// 

        int Delete(string id);
        /// <summary>
        /// 批量删除
        /// </summary>
        int DeleteRange(string Login_Account);
        /// <summary>
        /// 批量还原
        /// </summary>
        int RecoveryUserList(string Login_Account);
        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="Account"></param>
        /// <returns></returns>
        int UpdateQueryPwd(string pwd, string Account);
        /// <summary>
        /// 修改交易密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="Account"></param>
        /// <returns></returns>
        int UpdatePayPwd(string pwd, string Account);
        int UpdatedLastDate(string Account);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
        bool Exists(string Login_Account);
        bool ExistsEmail(string Email);
        bool ExistsMobile(string Mobile);
        /// <summary>
        /// 根据会员登录账号修改数据
        /// </summary>
        /// <param name="condition">修改的数据</param>
        /// <param name="loginAccount">会员登录账号</param>
        /// <returns></returns>
        int UpdateCondition(string condition, string loginAccount);

        int ConversionMRC(int ORE, int MRC, string Login_Account, decimal Remain, string OREID, int free);
        /// <summary>
        /// 返回总和
        /// </summary>
        /// <param name="column"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        string ReturnCount(string column, string condition);
        int getTeamNumbers(string account);
    }
}
