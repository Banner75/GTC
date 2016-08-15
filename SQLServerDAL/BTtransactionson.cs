using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    public class BTtransactionson : ZGZY.IDAL.IBTtransactionson
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddBTtransactionson(ZGZY.Model.BTtransactionson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbBTtransactionson(");
            strSql.Append("ID,addtime,appealcontent,BTtransactionID,dealmoney,state,buyuserID,buytype,transfernum,transfertime,updatetime");
            strSql.Append(") values (");
            strSql.Append("@ID,@addtime,@appealcontent,@BTtransactionID,@dealmoney,@state,@buyuserID,@buytype,@transfernum,@transfertime,@updatetime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@appealcontent", SqlDbType.Text) ,            
                        new SqlParameter("@BTtransactionID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dealmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@state", SqlDbType.Int,4) ,            
                        new SqlParameter("@buyuserID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@buytype", SqlDbType.Int,4) ,            
                        new SqlParameter("@transfernum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@transfertime", SqlDbType.DateTime) ,            
                        new SqlParameter("@updatetime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.addtime;
            parameters[2].Value = model.appealcontent;
            parameters[3].Value = model.BTtransactionID;
            parameters[4].Value = model.dealmoney;
            parameters[5].Value = model.state;
            parameters[6].Value = model.buyuserID;
            parameters[7].Value = model.buytype;
            parameters[8].Value = model.transfernum;
            parameters[9].Value = model.transfertime;
            parameters[10].Value = model.updatetime;                

         
           return  SqlHelper.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateBTtransactionson(ZGZY.Model.BTtransactionson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbBTtransactionson set ");

            strSql.Append(" ID = @ID , ");
            strSql.Append(" addtime = @addtime , ");
            strSql.Append(" appealcontent = @appealcontent , ");
            strSql.Append(" BTtransactionID = @BTtransactionID , ");
            strSql.Append(" dealmoney = @dealmoney , ");
            strSql.Append(" state = @state , ");
            strSql.Append(" buyuserID = @buyuserID , ");
            strSql.Append(" buytype = @buytype , ");
            strSql.Append(" transfernum = @transfernum , ");
            strSql.Append(" transfertime = @transfertime , ");
            strSql.Append(" updatetime = @updatetime  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@appealcontent", SqlDbType.Text) ,            
                        new SqlParameter("@BTtransactionID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@dealmoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@state", SqlDbType.Int,4) ,            
                        new SqlParameter("@buyuserID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@buytype", SqlDbType.Int,4) ,            
                        new SqlParameter("@transfernum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@transfertime", SqlDbType.DateTime) ,            
                        new SqlParameter("@updatetime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.addtime;
            parameters[2].Value = model.appealcontent;
            parameters[3].Value = model.BTtransactionID;
            parameters[4].Value = model.dealmoney;
            parameters[5].Value = model.state;
            parameters[6].Value = model.buyuserID;
            parameters[7].Value = model.buytype;
            parameters[8].Value = model.transfernum;
            parameters[9].Value = model.transfertime;
            parameters[10].Value = model.updatetime;   
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
        public bool DeleteBTtransactionson(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBTtransactionson ");
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
        public ZGZY.Model.BTtransactionson GetBTtransactionsonModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from tbBTtransactionson ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
            parameters[0].Value = ID;


            ZGZY.Model.BTtransactionson model = new Model.BTtransactionson();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                if (ds.Tables[0].Rows[0]["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(ds.Tables[0].Rows[0]["addtime"].ToString());
                }
                model.BTtransactionID = ds.Tables[0].Rows[0]["BTtransactionID"].ToString();
                model.appealcontent = ds.Tables[0].Rows[0]["appealcontent"].ToString();
                if (ds.Tables[0].Rows[0]["dealmoney"].ToString() != "")
                {
                    model.dealmoney = decimal.Parse(ds.Tables[0].Rows[0]["dealmoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                model.buyuserID = ds.Tables[0].Rows[0]["buyuserID"].ToString();
                if (ds.Tables[0].Rows[0]["buytype"].ToString() != "")
                {
                    model.buytype = int.Parse(ds.Tables[0].Rows[0]["buytype"].ToString());
                }
                model.transfernum = ds.Tables[0].Rows[0]["transfernum"].ToString();
                if (ds.Tables[0].Rows[0]["transfertime"].ToString() != "")
                {
                    model.transfertime = DateTime.Parse(ds.Tables[0].Rows[0]["transfertime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["updatetime"].ToString() != "")
                {
                    model.updatetime = DateTime.Parse(ds.Tables[0].Rows[0]["updatetime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rate"].ToString() != "")
                {
                    model.rate = decimal.Parse(ds.Tables[0].Rows[0]["rate"].ToString());
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
        public DataSet GetBTtransactionsonList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbBTtransactionson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetviewBTtransactionsonList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM View_BTtransactionson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetBTtransactionsonList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tbBTtransactionson ");
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
        public string  GetSumBTtransactionson(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(dealmoney) ");
            strSql.Append(" from tbBTtransactionson ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds= SqlHelper.Query(strSql.ToString());

            return ds.Tables[0].Rows[0][0].ToString();
            
        }
        /// <summary>
        /// 购买MRC return -1表示失败 0表示执行成功 >0表示执行失败
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="transactionID"></param>
        /// <param name="SaleMRC"></param>
        /// <param name="userID"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        public int BuyMRC(string ID, string transactionID, int SaleMRC, string userID, decimal rate, int state)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar, 20),                    
                    new SqlParameter("@userID", SqlDbType.VarChar,20),
                    new SqlParameter("@num", SqlDbType.Int),
                    new SqlParameter("@BTID", SqlDbType.VarChar,20),
                    new SqlParameter("@rate", SqlDbType.Decimal,19),
                    new SqlParameter("@salestate", SqlDbType.Int,4),
                    };
            parameters[0].Value = ID;
            parameters[1].Value = userID;
            parameters[2].Value = SaleMRC;
            parameters[3].Value = transactionID;
            parameters[4].Value = rate;
            parameters[5].Value = state;
            var tmp = SqlHelper.RunProcedure("BuyMRC", parameters, "BuyMRC").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="Sonid"></param>
        /// <param name="BTID"></param>
        /// <param name="dealmoney"></param>
        /// <param name="BuyUserID"></param>
        /// <returns></returns>
        public int CancelOrder(string Sonid, string BTID, decimal dealmoney, string BuyUserID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Sonid", SqlDbType.VarChar, 20),                    
                    new SqlParameter("@BTID", SqlDbType.VarChar,20),
                    new SqlParameter("@dealmoney", SqlDbType.Decimal,18),
                    new SqlParameter("@BuyUserID", SqlDbType.VarChar,20)
                    };
            parameters[0].Value = Sonid;
            parameters[1].Value = BTID;
            parameters[2].Value = dealmoney;
            parameters[3].Value = BuyUserID;
            var tmp = SqlHelper.RunProcedure("CancelOrder", parameters, "CancelOrder").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }

        
        /// <summary>
        /// 真实打款确认订单，冻结卖家账户
        /// </summary>
        /// <param name="Son_ID"></param>
        /// <param name="SaleLoginAccount"></param>
        /// <returns></returns>
        public int ConfirmOrder(string Son_ID, string SaleLoginAccount)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Sonid", SqlDbType.VarChar, 20),                    
                    new SqlParameter("@SaleUserID", SqlDbType.VarChar,20)
                    };
            parameters[0].Value = Son_ID;
            parameters[1].Value = SaleLoginAccount;
            var tmp = SqlHelper.RunProcedure("ConfirmOrder", parameters, "ConfirmOrder").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }
        /// <summary>
        /// 过期取消订单可以使用方法
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Son_ID"></param>
        /// <param name="LoginAccount"></param>
        /// <param name="dealmoney"></param>
        /// <returns></returns>
        public int AutoCancelOrder(string ID,string Son_ID,string LoginAccount,decimal dealmoney)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar, 20),                    
                    new SqlParameter("@son_id", SqlDbType.VarChar,20),
                    new SqlParameter("@userid", SqlDbType.VarChar,20),
                    new SqlParameter("@dealmoney", SqlDbType.Decimal,18)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = Son_ID;
            parameters[2].Value = LoginAccount;
            parameters[3].Value = dealmoney;
            var tmp = SqlHelper.RunProcedure("AutoCancelOrder", parameters, "AutoCancelOrder").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }
    }
}
