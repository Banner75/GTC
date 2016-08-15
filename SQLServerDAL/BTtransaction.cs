using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    public class BTtransaction : ZGZY.IDAL.IBTtransaction
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddBTtransaction(ZGZY.Model.BTtransaction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbBTtransaction(");
            strSql.Append("ID,userID,allmoney,showmoney,dealmoney,salemoney,addtime,state,updatetime");
            strSql.Append(") values (");
            strSql.Append("@ID,@userID,@allmoney,@showmoney,@dealmoney,@salemoney,@addtime,@state,@updatetime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@userID", SqlDbType.VarChar,20) ,     
                        new SqlParameter("@practical_money", SqlDbType.Decimal,9) ,           
                        new SqlParameter("@allmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@showmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dealmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@salemoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@state", SqlDbType.Int,4) ,            
                        new SqlParameter("@updatetime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.userID;
            parameters[2].Value = model.practical_money;
            parameters[3].Value = model.allmoney;
            parameters[4].Value = model.showmoney;
            parameters[5].Value = model.dealmoney;
            parameters[6].Value = model.salemoney;
            parameters[7].Value = model.addtime;
            parameters[8].Value = model.state;
            parameters[9].Value = model.updatetime;

          return  SqlHelper.ExecuteSql(strSql.ToString(), parameters);

        }

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
        public int addSaleMRC(string transactionID, decimal SaleMRC, string SaleUserAccount, int BTLogType, int BTLogState, string Logcontent, decimal practical_money)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar, 20),
                    new SqlParameter("@num", SqlDbType.Int),
                    new SqlParameter("@userID", SqlDbType.VarChar,20),
                    new SqlParameter("@type", SqlDbType.Int),
                    new SqlParameter("@log_state", SqlDbType.Int),
                    new SqlParameter("@logcontent", SqlDbType.Text),
                    new SqlParameter("@practical_money", SqlDbType.Decimal)
                    };
            parameters[0].Value = transactionID;
            parameters[1].Value = SaleMRC;
            parameters[2].Value = SaleUserAccount;
            parameters[3].Value = BTLogType;
            parameters[4].Value = BTLogState;
            parameters[5].Value = Logcontent;
            parameters[6].Value = practical_money;

            var tmp = SqlHelper.RunProcedure("SaleMRC", parameters, "SaleMRC").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }

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
        public int addRecyclingMRC(string id, string userID, decimal sellMoney, decimal deMoney, DateTime addtime, DateTime updatetime, int state)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar, 20),
                    new SqlParameter("@userID", SqlDbType.VarChar, 20),
                    new SqlParameter("@sellMoney", SqlDbType.Decimal, 9),
                    new SqlParameter("@deMoney", SqlDbType.Decimal, 9),
                    new SqlParameter("@addtime", SqlDbType.DateTime),
                    new SqlParameter("@updatetime", SqlDbType.DateTime),
                    new SqlParameter("@state", SqlDbType.Int),
                    };
            parameters[0].Value = id;
            parameters[1].Value = userID;
            parameters[2].Value = sellMoney;
            parameters[3].Value = deMoney;
            parameters[4].Value = addtime;
            parameters[5].Value = updatetime;
            parameters[6].Value = state;

            var tmp = SqlHelper.RunProcedure("RecyclingMRC", parameters, "RecyclingMRC").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }



       
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateBTtransaction(ZGZY.Model.BTtransaction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbBTtransaction set ");

            strSql.Append(" ID = @ID , ");
            strSql.Append(" userID = @userID , ");
            strSql.Append(" allmoney = @allmoney , ");
            strSql.Append(" showmoney = @showmoney , ");
            strSql.Append(" dealmoney = @dealmoney , ");
            strSql.Append(" salemoney = @salemoney , ");
            strSql.Append(" addtime = @addtime , ");
            strSql.Append(" state = @state , ");
            strSql.Append(" updatetime = @updatetime,  ");
            strSql.Append(" practical_money = @practical_money  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@userID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@allmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@showmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@dealmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@salemoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@state", SqlDbType.Int,4) ,            
                        new SqlParameter("@updatetime", SqlDbType.DateTime),             
                        new SqlParameter("@practical_money", SqlDbType.Decimal )                       
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.userID;
            parameters[2].Value = model.allmoney;
            parameters[3].Value = model.showmoney;
            parameters[4].Value = model.dealmoney;
            parameters[5].Value = model.salemoney;
            parameters[6].Value = model.addtime;
            parameters[7].Value = model.state;
            parameters[8].Value = model.updatetime;
            parameters[8].Value = model.practical_money;

            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteBTtransaction(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBTtransaction ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
            parameters[0].Value = ID;


            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZGZY.Model.BTtransaction GetBTtransactionModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, userID, practical_money,allmoney, showmoney, dealmoney, salemoney, addtime, state, updatetime  ");
            strSql.Append("  from tbBTtransaction ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
            parameters[0].Value = ID;


            ZGZY.Model.BTtransaction model = new Model.BTtransaction();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.userID = ds.Tables[0].Rows[0]["userID"].ToString();
                if (ds.Tables[0].Rows[0]["allmoney"].ToString() != "")
                {
                    model.allmoney = decimal.Parse(ds.Tables[0].Rows[0]["allmoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["practical_money"].ToString() != "")
                {
                    model.practical_money = decimal.Parse(ds.Tables[0].Rows[0]["practical_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["showmoney"].ToString() != "")
                {
                    model.showmoney = decimal.Parse(ds.Tables[0].Rows[0]["showmoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dealmoney"].ToString() != "")
                {
                    model.dealmoney = decimal.Parse(ds.Tables[0].Rows[0]["dealmoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["salemoney"].ToString() != "")
                {
                    model.salemoney = decimal.Parse(ds.Tables[0].Rows[0]["salemoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(ds.Tables[0].Rows[0]["addtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["updatetime"].ToString() != "")
                {
                    model.updatetime = DateTime.Parse(ds.Tables[0].Rows[0]["updatetime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetBTtransactionList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbBTtransaction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetBTtransactionList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tbBTtransaction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public string  GetSumBTtransaction(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(allmoney) ");
            strSql.Append(" from tbBTtransaction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = SqlHelper.Query(strSql.ToString());

            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
