using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.Common;
using ZGZY.Model;
using ZGZY.IDAL;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 新版会员表
    /// </summary>
    public class CustomerDA : ICustomerDA
    {
        #region 查询数据

        #region 根据帐号查询安全帐号信息

        public BS_Customers GetSafeAccountInfo(string account)
        {
            BS_Customers data = new BS_Customers();

            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append("Login_Account,Email,Mobile,Login_PWD, Pay_PWD ");
            sql.Append("from BS_Customers ");
            sql.Append("where ");
            sql.Append("State = 1 ");
            sql.Append("and ");
            sql.Append("Login_Account = @account ");

            SqlParameter[] parameters = {
					                        new SqlParameter("@account", account)			
                                        };

            DataSet ds = SqlHelper.Query(sql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                data.Login_Account = (ds.Tables[0].Rows[0]["Login_Account"] == DBNull.Value) ? "" : ds.Tables[0].Rows[0]["Login_Account"].ToString();
                data.Email = (ds.Tables[0].Rows[0]["Email"] == DBNull.Value) ? "" : ds.Tables[0].Rows[0]["Email"].ToString();
                data.Mobile = (ds.Tables[0].Rows[0]["Mobile"] == DBNull.Value) ? "" : ds.Tables[0].Rows[0]["Mobile"].ToString();
                data.Login_PWD = (ds.Tables[0].Rows[0]["Login_PWD"] == DBNull.Value) ? "" : ds.Tables[0].Rows[0]["Login_PWD"].ToString();
                data.Pay_PWD = (ds.Tables[0].Rows[0]["Pay_PWD"] == DBNull.Value) ? "" : ds.Tables[0].Rows[0]["Pay_PWD"].ToString();
            }
            else
            {
                data = null;
            }

            return data;
        }


        #endregion

        #region 根据帐号读取安全问题

        public List<BS_Safe_Problems> GetSafeProblems(string account)
        {
            List<BS_Safe_Problems> datas = new List<BS_Safe_Problems>();

            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append("ID, Login_Account, Question, Answer ");
            sql.Append("from BS_Safe_Problems ");
            sql.Append("where ");
            sql.Append("state = 1 ");
            sql.Append("and ");
            sql.Append("Login_Account = @account ");

            SqlParameter[] parameters = {
					                        new SqlParameter("@account", account)
                                        };

            DataSet ds = SqlHelper.Query(sql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    BS_Safe_Problems data = new BS_Safe_Problems();
                    data.ID = (dr["ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                    data.LoginAccount = (dr["Login_Account"] == DBNull.Value) ? "" : dr["Login_Account"].ToString();
                    data.Question = (dr["Question"] == DBNull.Value) ? "" : dr["Question"].ToString();
                    data.Answer = (dr["Answer"] == DBNull.Value) ? "" : dr["Answer"].ToString();
                    datas.Add(data);
                }
            }
            else
            {
                datas = null;
            }

            return datas;
        }

        #endregion

        #endregion

        //---------------------------------------------------------新版分割符号------------------------------------------------------

        #region 查询数据

        #region 根据会员ID读取会员信息
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZGZY.Model.BS_Customers GetCustomerByID(string Login_Account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from BS_Customers ");
            strSql.Append(" where Login_Account=@Login_Account ");
            SqlParameter[] parameters = { new SqlParameter("@Login_Account", SqlDbType.VarChar, 20) };
            parameters[0].Value = Login_Account;
            ZGZY.Model.BS_Customers model = new ZGZY.Model.BS_Customers();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZGZY.Model.BS_Customers GetCustomerByLoginAccount(string Login_Account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from BS_Customers ");
            strSql.Append(" where Login_Account=@Login_Account ");
            SqlParameter[] parameters = { new SqlParameter("@Login_Account", SqlDbType.VarChar, 20) };
            parameters[0].Value = Login_Account;
            ZGZY.Model.BS_Customers model = new ZGZY.Model.BS_Customers();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 根据查询条件获取单个会员信息

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BS_Customers> GetCustomersByCondition(string condition)
        {
            List<BS_Customers> datas = new List<BS_Customers>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from BS_Customers ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrWhiteSpace(condition))
            {
                strSql.Append("and " + condition);
            }
            DataSet ds = SqlHelper.Query(strSql.ToString());
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                datas.Add(DataRowToModel(ds.Tables[0].Rows[0]));
            }
            else
            {
                datas = null;
            }
            return datas;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZGZY.Model.BS_Customers DataRowToModel(DataRow row)
        {
            ZGZY.Model.BS_Customers model = new ZGZY.Model.BS_Customers();
            if (row != null)
            {
                if (row["Login_Account"] != null) { model.Login_Account = row["Login_Account"].ToString(); }
                if (row["Nick_Name"] != null) { model.Nick_Name = row["Nick_Name"].ToString(); }
                if (row["Truly_Name"] != null) { model.Truly_Name = row["Truly_Name"].ToString(); }
                if (row["Sex"] != null && row["Sex"].ToString() != "") { model.Sex = int.Parse(row["Sex"].ToString()); }
                if (row["Card_Kind"] != null) { model.Card_Kind = row["Card_Kind"].ToString(); }
                if (row["Card_No"] != null) { model.Card_No = row["Card_No"].ToString(); }
                if (row["Email"] != null) { model.Email = row["Email"].ToString(); }
                if (row["Mobile"] != null) { model.Mobile = row["Mobile"].ToString(); }
                if (row["Country"] != null) { model.Country = row["Country"].ToString(); }
                if (row["Bank"] != null) { model.Bank = row["Bank"].ToString(); }
                if (row["Bank_User"] != null) { model.Bank_User = row["Bank_User"].ToString(); }
                if (row["Bank_Account"] != null) { model.Bank_Account = row["Bank_Account"].ToString(); }
                if (row["Bank_Branch"] != null) { model.Bank_Branch = row["Bank_Branch"].ToString(); }
                if (row["Alipay"] != null) { model.Alipay = row["Alipay"].ToString(); }
                if (row["Parent"] != null) { model.Parent = row["Parent"].ToString(); }
                if (row["Person_Liable"] != null) { model.Person_Liable = row["Person_Liable"].ToString(); }
                if (row["User_Grade"] != null) { model.User_Grade = row["User_Grade"].ToString(); }
                if (row["Register_Date"] != null && row["Register_Date"].ToString() != "") { model.Register_Date = DateTime.Parse(row["Register_Date"].ToString()); }
                if (row["MRC"] != null && row["MRC"].ToString() != "") { model.MRC = decimal.Parse(row["MRC"].ToString()); }
                if (row["ORE"] != null && row["ORE"].ToString() != "") { model.ORE = decimal.Parse(row["ORE"].ToString()); }
                if (row["cAmount"] != null && row["cAmount"].ToString() != "") { model.cAmt = decimal.Parse(row["cAmount"].ToString()); }
                if (row["State"] != null && row["State"].ToString() != "") { model.State = int.Parse(row["State"].ToString()); }
                if (row["Mills_Num"] != null && row["Mills_Num"].ToString() != "") { model.Mills_Num = int.Parse(row["Mills_Num"].ToString()); }
                if (row["Login_PWD"] != null) { model.Login_PWD = row["Login_PWD"].ToString(); }
                if (row["Pay_PWD"] != null) { model.Pay_PWD = row["Pay_PWD"].ToString(); }
                if (row["Remark"] != null) { model.Remark = row["Remark"].ToString(); }
                if (row["Created_By"] != null && row["Created_By"].ToString() != "") { model.Created_By = int.Parse(row["Created_By"].ToString()); }
                if (row["Created_Date"] != null && row["Created_Date"].ToString() != "") { model.Created_Date = DateTime.Parse(row["Created_Date"].ToString()); }
                if (row["Last_Updated_By"] != null && row["Last_Updated_By"].ToString() != "") { model.Last_Updated_By = int.Parse(row["Last_Updated_By"].ToString()); }
                if (row["Last_Updated_Date"] != null && row["Last_Updated_Date"].ToString() != "") { model.Last_Updated_Date = DateTime.Parse(row["Last_Updated_Date"].ToString()); }
                if (row["Region"] != null && row["Region"].ToString() != "") { model.Region = int.Parse(row["Region"].ToString()); }
                if (row["OtherOREBonus"] != null && row["OtherOREBonus"].ToString() != "") { model.OtherOREBonus = int.Parse(row["OtherOREBonus"].ToString()); }
                if (row["stare"] != null && row["stare"].ToString() != "") { model.stare = int.Parse(row["stare"].ToString()); }
                if (row["class"] != null && row["class"].ToString() != "") { model.Class = int.Parse(row["class"].ToString()); }
            }
            return model;
        }
        #endregion

        #region 根据用户名和密码查询会员

        /// <summary>
        /// 根据用户名和密码读取会员信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public BS_Customers GetCustomerByUserNameAndPWD(string username, string password)
        {
            BS_Customers data = new BS_Customers();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BS_Customers ");
            strSql.Append(" where ");
            strSql.Append("Login_Account = @account ");
            strSql.Append("and ");
            strSql.Append("Login_PWD = @pwd ");
            SqlParameter[] parameters = {
					                        new SqlParameter("@account", username),
			                                new SqlParameter("@pwd", password)
                                        };
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

        #endregion

        #region 返回列表数据
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BS_Customers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM BS_Customers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }
        #endregion

        #endregion

        #region 会员数据操作

        #region 增加一条数据(返回新增记录id)
        /// <summary>
        /// 增加一条数据(返回新增记录id)
        /// </summary>
        public int Insert(BS_Customers model)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BS_Customers(");
            strSql.Append("Login_Account,Nick_Name,Truly_Name,Sex,Card_Kind,Card_No,Email,Mobile,Country,Bank,Bank_User,Bank_Account,Bank_Branch,Alipay, Parent,Person_Liable, User_Grade, Register_Date, MRC,ORE,State,Mills_Num,Login_PWD,Pay_PWD,Remark,Created_By,Created_Date,Last_Updated_By,Last_Updated_Date,Region,OtherOREBonus,class)");
            strSql.Append(" values (");
            strSql.Append("@Login_Account,@Nick_Name,@Truly_Name,@Sex,@Card_Kind,@Card_No,@Email,@Mobile,@Country,@Bank,@Bank_User,@Bank_Account,@Bank_Branch,@Alipay,@Parent, @Person_Liable,@User_Grade,@Register_Date,@MRC,@ORE,@State,@Mills_Num,@Login_PWD,@Pay_PWD,@Remark,@Created_By,@Created_Date,@Last_Updated_By,@Last_Updated_Date,@Region,@OtherOREBonus,@class)");
            SqlParameter[] parameters = {
					new SqlParameter("@Login_Account", SqlDbType.VarChar,20),
					new SqlParameter("@Nick_Name", SqlDbType.VarChar,20),
					new SqlParameter("@Truly_Name", SqlDbType.VarChar,20),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Card_Kind", SqlDbType.VarChar,20),
					new SqlParameter("@Card_No", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,60),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Country", SqlDbType.VarChar,20),
					new SqlParameter("@Bank", SqlDbType.VarChar,20),
					new SqlParameter("@Bank_User", SqlDbType.VarChar,20),
					new SqlParameter("@Bank_Account", SqlDbType.VarChar,20),
					new SqlParameter("@Bank_Branch", SqlDbType.VarChar,20),
					new SqlParameter("@Alipay", SqlDbType.VarChar,20),
					new SqlParameter("@Parent", SqlDbType.VarChar,20),
                    new SqlParameter("@Person_Liable", SqlDbType.VarChar,20),
                    new SqlParameter("@User_Grade", SqlDbType.VarChar,50),
					new SqlParameter("@Register_Date", SqlDbType.DateTime),
					new SqlParameter("@MRC", SqlDbType.Decimal,8),
					new SqlParameter("@ORE", SqlDbType.Decimal,8),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Mills_Num", SqlDbType.Int,4),
					new SqlParameter("@Login_PWD", SqlDbType.VarChar,32),
					new SqlParameter("@Pay_PWD", SqlDbType.VarChar,32),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@Created_By", SqlDbType.Int,4),
					new SqlParameter("@Created_Date", SqlDbType.DateTime),
					new SqlParameter("@Last_Updated_By", SqlDbType.Int,4),
					new SqlParameter("@Last_Updated_Date", SqlDbType.DateTime),
					new SqlParameter("@Region", SqlDbType.Int,4),
					new SqlParameter("@OtherOREBonus", SqlDbType.Int,4),
                    new SqlParameter("@class", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.Login_Account;
            parameters[1].Value = model.Nick_Name;
            parameters[2].Value = model.Truly_Name;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Card_Kind;
            parameters[5].Value = model.Card_No;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.Mobile;
            parameters[8].Value = model.Country;
            parameters[9].Value = model.Bank;
            parameters[10].Value = model.Bank_User;
            parameters[11].Value = model.Bank_Account;
            parameters[12].Value = model.Bank_Branch;
            parameters[13].Value = model.Alipay;
            parameters[14].Value = model.Parent;
            parameters[15].Value = model.Person_Liable;
            parameters[16].Value = model.User_Grade;
            parameters[17].Value = model.Register_Date;
            parameters[18].Value = model.MRC;
            parameters[19].Value = model.ORE;
            parameters[20].Value = model.State;
            parameters[21].Value = model.Mills_Num;
            parameters[22].Value = model.Login_PWD;
            parameters[23].Value = model.Pay_PWD;
            parameters[24].Value = model.Remark;
            parameters[25].Value = model.Created_By;
            parameters[26].Value = model.Created_Date;
            parameters[27].Value = model.Last_Updated_By;
            parameters[28].Value = model.Last_Updated_Date;
            parameters[29].Value = model.Region;
            parameters[30].Value = model.OtherOREBonus;
            parameters[31].Value = model.Class;
            try
            {
                result = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
        #endregion

        #region 更新最后登录时间
        public int UpdatedLastDate(string Account)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set  Last_Updated_Date = @Last_Updated_Date where Login_Account = @Login_Account  ");
            SqlParameter[] parameters = {
			                                new SqlParameter("@Last_Updated_Date",DateTime.Now),
                                             new SqlParameter("@Login_Account", Account)
                                         };
            try
            {
                result = SqlHelper.ExecuteSql(sql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
        #endregion

        #region 修改记录
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BS_Customers data)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set ");
            sql.Append(" Nick_Name = @nickname,");
            sql.Append(" Truly_Name = @trulyname, ");
            sql.Append(" Sex = @sex,");
            sql.Append(" Email = @email,");
            sql.Append(" Mobile = @mobile,");
            sql.Append(" Country = @country,");
            sql.Append(" Bank = @bank,");
            sql.Append(" Bank_User = @bankuser,");
            sql.Append(" Bank_Account = @bankaccount,");
            sql.Append(" Bank_Branch = @bankbranch,");
            sql.Append(" Alipay = @alipay,");
            sql.Append(" class = @class,");
            sql.Append(" Remark = @remark ");
            sql.Append(" where Login_Account = @Login_Account  ");

            SqlParameter[] parameters = {
			                                new SqlParameter("@Login_Account", data.Login_Account) ,            
                                            new SqlParameter("@nickname", data.Nick_Name) ,            
                                            new SqlParameter("@trulyname", data.Truly_Name) ,            
                                            new SqlParameter("@sex", data.Sex),             
                                            new SqlParameter("@email", data.Email) , 
                                            new SqlParameter("@mobile", data.Mobile) , 
                                            new SqlParameter("@country", data.Country) ,            
                                            new SqlParameter("@bank", data.Bank),
                                            new SqlParameter("@bankuser", data.Bank_User),
                                            new SqlParameter("@bankaccount", data.Bank_Account),
                                            new SqlParameter("@bankbranch", data.Bank_Branch),
                                            new SqlParameter("@alipay", data.Alipay),             
                                            new SqlParameter("@class", data.Class),    
                                            new SqlParameter("@remark", data.Remark)           
                                        };

            try
            {
                result = SqlHelper.ExecuteSql(sql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateMRCorORE(BS_Customers data)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set ");
            sql.Append(" MRC = @MRC,");
            sql.Append(" ORE = @ORE, ");
            sql.Append(" cAmt = @cAmt ");
            sql.Append(" where Login_Account = @Login_Account  ");

            SqlParameter[] parameters = {
			                                new SqlParameter("@MRC", data.MRC) ,            
                                            new SqlParameter("@ORE", data.ORE),
                                            new SqlParameter("@cAmt", data.cAmt),
                                            new SqlParameter("@Login_Account", data.Login_Account)
                                        };

            try
            {
                result = SqlHelper.ExecuteSql(sql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新客户美瑞币MRC
        /// </summary>
        public int UpdateMRC(string loginAccount,decimal mrcQty)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set ");
            sql.Append(" MRC = @MRC");
            sql.Append(" where Login_Account = @Login_Account  ");

            SqlParameter[] parameters = {
			                                new SqlParameter("@Login_Account", loginAccount) ,            
                                            new SqlParameter("@MRC", mrcQty)           
                                        };

            try
            {
                result = SqlHelper.ExecuteSql(sql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新客户矿机币ORE
        /// </summary>
        public int UpdateORE(string loginAccount, decimal oreQty)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set ");
            sql.Append(" ORE = @ORE");
            sql.Append(" where Login_Account = @Login_Account  ");

            SqlParameter[] parameters = {
			                                new SqlParameter("@Login_Account", loginAccount) ,            
                                            new SqlParameter("@ORE", oreQty)           
                                        };

            try
            {
                result = SqlHelper.ExecuteSql(sql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新会员登录密码
        /// </summary>
        /// <param name="pwd">会员登录密码</param>
        /// <param name="Account">会员登录账号</param>
        /// <returns></returns>
        public int UpdateQueryPwd(string pwd, string Account)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set  Login_PWD = @Login_PWD where Login_Account = @Login_Account  ");
            SqlParameter[] parameters = {
			                                new SqlParameter("@Login_PWD", pwd),
                                             new SqlParameter("@Login_Account", Account)
                                         };
            try
            {
                result = SqlHelper.ExecuteSql(sql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
        /// <summary>
        /// 更新会员二级密码
        /// </summary>
        /// <param name="pwd">会员二级密码</param>
        /// <param name="Account">会员登录账号</param>
        /// <returns></returns>
        public int UpdatePayPwd(string pwd, string Account)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set  Pay_PWD = @Pay_PWD where Login_Account = @Login_Account  ");
            SqlParameter[] parameters = {
			                                new SqlParameter("@Pay_PWD", pwd),
                                             new SqlParameter("@Login_Account", Account)
                                         };
            try
            {
                result = SqlHelper.ExecuteSql(sql.ToString(), parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
        #endregion

        #region 根据会员登录账号修改数据
        /// <summary>
        /// 根据会员登录账号修改数据
        /// </summary>
        /// <param name="condition">修改的数据</param>
        /// <param name="loginAccount">会员登录账号</param>
        /// <returns></returns>
        public int UpdateCondition(string condition, string loginAccount)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set " + condition + " where Login_Account = '" + loginAccount + "'");
            result = SqlHelper.ExecuteSql(sql.ToString());
            return result;
        }
        #endregion



        #region 批量还原正常状态
        /// <summary>
        /// 批量还原
        /// </summary>
        public int RecoveryUserList(string Login_Account)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set State=1 where Login_Account in (" + Login_Account + ")");
            result = SqlHelper.ExecuteSql(sql.ToString());
            return result;
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(string Login_Account)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            string delStr = "delete a from BS_Customers a left join BS_Machine b on a.Login_Account=b.Login_Account left join BS_Customers c on a.Login_Account=c.Person_Liable where a.Login_Account= @loginaccount and b.Login_Account is null and c.Login_Account is null ";
            sql.Append("update BS_Customers set State=3 where Login_Account = @loginaccount ");
            SqlParameter[] parameters = { new SqlParameter("@loginaccount", Login_Account) };
            result = SqlHelper.ExecuteSql(sql.ToString(), parameters); //update first.
            result += SqlHelper.ExecuteSql(delStr, parameters); //delete second. maybe can't delete
            return result;
        }
        #endregion

        #region 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        public int DeleteRange(string Login_Account)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update BS_Customers set State=3 where Login_Account in (" + Login_Account + ")");
            result = SqlHelper.ExecuteSql(sql.ToString());
            return result;
        }
        #endregion        

        #endregion

        #region 判断用户是否存在
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Login_Account)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("select 1 from BS_Customers where Login_Account = @Login_Account ");
            SqlParameter[] parameters = { new SqlParameter("@Login_Account", Login_Account) };
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sb.ToString(), parameters);
            if (dt != null && dt.Rows.Count > 0) { result = true; }
            return result;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsEmail(string Email)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("select 1 from BS_Customers where Email = @Email ");
            SqlParameter[] parameters = { new SqlParameter("@Email", Email) };
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sb.ToString(), parameters);
            if (dt != null && dt.Rows.Count > 0) { result = true; }
            return result;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsMobile(string Mobile)
        {
            bool result = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("select 1 from BS_Customers where Mobile = @Mobile ");
            SqlParameter[] parameters = { new SqlParameter("@Mobile", Mobile) };
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sb.ToString(), parameters);
            if (dt != null && dt.Rows.Count > 0) { result = true; }
            return result;
        }
        #endregion

        #region 返回密码
        public string getQueryPwd(string account)
        {
            string result = "";
            StringBuilder sql = new StringBuilder();
            sql.Append("select Login_Pwd from BS_Customers where state = 1 and login_account = @account ");
            SqlParameter[] parameters = { new SqlParameter("@account", account) };
            object obj = SqlHelper.GetSingle(sql.ToString(), parameters);
            if (obj != null) { result = obj.ToString(); }
            return result;
        }

        public string GetPayPwd(string account)
        {
            string result = "";
            StringBuilder sql = new StringBuilder();
            sql.Append("select Pay_pwd from BS_Customers where state = 1  and login_account = @account ");
            SqlParameter[] parameters = { new SqlParameter("@account", account) };
            object obj = SqlHelper.GetSingle(sql.ToString(), parameters);
            if (obj != null) { result = obj.ToString(); }
            return result;
        }

        public string GetQueryPwd(string account)
        {
            BS_Customers data = new BS_Customers();
            StringBuilder sql = new StringBuilder();
            sql.Append("select Login_PWD from BS_Customers where Login_Account = @account ");
            SqlParameter[] parameters = { new SqlParameter("@account", account), };
            DataSet ds = SqlHelper.Query(sql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                //data.ID = (ds.Tables[0].Rows[0]["ID"] == DBNull.Value) ? "" : Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
                data.Login_PWD = (ds.Tables[0].Rows[0]["Login_PWD"] == DBNull.Value) ? "" : ds.Tables[0].Rows[0]["Login_PWD"].ToString();
            }
            else
            {
                return "";
            }
            return data.Login_PWD;
        }
        #endregion

        #region 会员兑换美瑞币

        public int ConversionMRC(int ORE,int MRC,string Login_Account,decimal Remain,string OREID,int free)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ORE", SqlDbType.Int, 20),                    
                    new SqlParameter("@MRC", SqlDbType.Int,20),
                    new SqlParameter("@Login_Account", SqlDbType.VarChar,20),
                    new SqlParameter("@Remain", SqlDbType.Decimal,18),
                    new SqlParameter("@OREID", SqlDbType.VarChar,20),
                    new SqlParameter("@free", SqlDbType.Int,4)
                    };
            parameters[0].Value = ORE;
            parameters[1].Value = MRC;
            parameters[2].Value = Login_Account;
            parameters[3].Value = Remain;
            parameters[4].Value = OREID;
            parameters[5].Value = free;
            var tmp = SqlHelper.RunProcedure("ConversionMRC", parameters, "ConversionMRC").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }
             
        #endregion

        public string ReturnCount(string column, string condition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select isnull(sum(isnull(" + column + ",0)),0) from  BS_Customers");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrWhiteSpace(condition))
            {
                strSql.Append("and " + condition);
            }

            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToDecimal(obj).ToString();
            }
            else
            {
                return " ";
            }

        }

        public int getTeamNumbers(string account)
        {
            int result = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("select teamNumbers=dbo.fx_getTeamNumbers(@account)");
            SqlParameter[] parameters = { new SqlParameter("@account", account) };
            object obj = SqlHelper.GetSingle(sql.ToString(), parameters);
            if (obj != null) { result = int.Parse(obj.ToString()); }
            return result;
        }

    }
}
