using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    public class BTLog : ZGZY.IDAL.IBTLog
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddBTLog(ZGZY.Model.BTLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbBTLog(");
            strSql.Append("type,state,logcontent,addtime,userID,btmoney");
            strSql.Append(") values (");
            strSql.Append("@type,@state,@logcontent,@addtime,@userID,@btmoney");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@type", SqlDbType.Int,4) ,            
                        new SqlParameter("@state", SqlDbType.Int,4) ,            
                        new SqlParameter("@logcontent", SqlDbType.Text) ,            
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@userID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@btmoney", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.type;
            parameters[1].Value = model.state;
            parameters[2].Value = model.logcontent;
            parameters[3].Value = model.addtime;
            parameters[4].Value = model.userID;
            parameters[5].Value = model.btmoney;             

            object obj = SqlHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateBTLog(ZGZY.Model.BTLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbBTLog set ");

            strSql.Append(" type = @type , ");
            strSql.Append(" state = @state , ");
            strSql.Append(" logcontent = @logcontent , ");
            strSql.Append(" addtime = @addtime , ");
            strSql.Append(" userID = @userID , ");
            strSql.Append(" btmoney = @btmoney  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@type", SqlDbType.Int,4) ,            
                        new SqlParameter("@state", SqlDbType.Int,4) ,            
                        new SqlParameter("@logcontent", SqlDbType.Text) ,            
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@userID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@btmoney", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.type;
            parameters[2].Value = model.state;
            parameters[3].Value = model.logcontent;
            parameters[4].Value = model.addtime;
            parameters[5].Value = model.userID;
            parameters[6].Value = model.btmoney;      
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
        public bool DeleteBTLog(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBTLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteBTLogList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBTLog ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = SqlHelper.ExecuteSql(strSql.ToString());
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
        public ZGZY.Model.BTLog GetBTLogModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, type, state, logcontent, addtime, userID,btmoney  ");
            strSql.Append("  from tbBTLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            ZGZY.Model.BTLog model = new ZGZY.Model.BTLog();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                model.logcontent = ds.Tables[0].Rows[0]["logcontent"].ToString();
                if (ds.Tables[0].Rows[0]["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(ds.Tables[0].Rows[0]["addtime"].ToString());
                }
                model.userID = ds.Tables[0].Rows[0]["userID"].ToString();
                if (ds.Tables[0].Rows[0]["btmoney"].ToString() != "")
                {
                    model.btmoney = decimal.Parse(ds.Tables[0].Rows[0]["btmoney"].ToString());
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
        public DataSet GetBTLogList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbBTLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetBTLogList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tbBTLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }
    }
}
