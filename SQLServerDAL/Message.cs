using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
  public   class Message : ZGZY.IDAL.IMessage
    {
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
      public int AddMessage(ZGZY.Model.Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BS_Message(");
            strSql.Append("ID,Title,Content,CreateDate,State,Login_Account,Reply,ReplyDate,Type");
            strSql.Append(") values (");
            strSql.Append("@ID,@Title,@Content,@CreateDate,@State,@Login_Account,@Reply,@ReplyDate,@Type");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Content", SqlDbType.Text) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@Login_Account", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Reply", SqlDbType.Text) ,            
                        new SqlParameter("@ReplyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Type", SqlDbType.Int,4)             
              
            };
          
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.State;
            parameters[5].Value = model.Login_Account;
            parameters[6].Value = model.Reply;
            parameters[7].Value = model.ReplyDate;
            parameters[8].Value = model.Type;
            return SqlHelper.ExecuteSql(strSql.ToString(), parameters);

        }
      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateMessage(ZGZY.Model.Message model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update BS_Message set ");

          strSql.Append(" ID = @ID , ");
          strSql.Append(" Title = @Title , ");
          strSql.Append(" Content = @Content , ");
          strSql.Append(" CreateDate = @CreateDate , ");
          strSql.Append(" State = @State , ");
          strSql.Append(" Login_Account = @Login_Account , ");
          strSql.Append(" Reply = @Reply , ");
          strSql.Append(" ReplyDate = @ReplyDate , ");
          strSql.Append(" Type = @Type  ");
          strSql.Append(" where  ID=@ID");

          SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Content", SqlDbType.Text) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@Login_Account", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Reply", SqlDbType.Text) ,            
                        new SqlParameter("@ReplyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Type", SqlDbType.Int,4)             
              
            };

          parameters[0].Value = model.ID;
          parameters[1].Value = model.Title;
          parameters[2].Value = model.Content;
          parameters[3].Value = model.CreateDate;
          parameters[4].Value = model.State;
          parameters[5].Value = model.Login_Account;
          parameters[6].Value = model.Reply;
          parameters[7].Value = model.ReplyDate;
          parameters[8].Value = model.Type;
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
      public bool DeleteMessage(string ID)
      {

          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete from BS_Message ");
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
      public ZGZY.Model.Message GetMessageModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Title, Content, CreateDate, State, Login_Account, Reply, ReplyDate, Type  ");
            strSql.Append("  from BS_Message ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
            parameters[0].Value = ID;


            ZGZY.Model.Message model = new ZGZY.Model.Message();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                model.Login_Account = ds.Tables[0].Rows[0]["Login_Account"].ToString();
                model.Reply = ds.Tables[0].Rows[0]["Reply"].ToString();
                if (ds.Tables[0].Rows[0]["ReplyDate"].ToString() != "")
                {
                    model.ReplyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ReplyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
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
      public DataSet GetMessageList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BS_Message ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
      public DataSet GetMessageList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM BS_Message ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }


      /// <summary>
      /// 批量删除
      /// </summary>
      /// <param name="ids"></param>
      /// <returns></returns>
      public int DeleteRange(string ids)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete from BS_Message ");
          strSql.Append(string.Format(" where ID in ({0})", ids));
          return SqlHelper.ExecuteSql(strSql.ToString());
          
      }

    }
}
