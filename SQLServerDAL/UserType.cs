using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    public class UserType : ZGZY.IDAL.IUserType
    {
        public bool ExistsUserType(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BS_Customer_Type");
            strSql.Append(" where " + where);
            if (Convert.ToInt32(SqlHelper.Query(strSql.ToString()).Tables[0].Rows[0][0].ToString())> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  AddUserType(ZGZY.Model.BS_Customer_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BS_Customer_Type(");
            strSql.Append("Id,name,money,machinenum");
            strSql.Append(") values (");
            strSql.Append("@Id,@name,@money,@machinenum");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@name", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@money", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@machinenum", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Money;
            parameters[3].Value = model.MachineNum;
          return  SqlHelper.ExecuteSql(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateUserType(ZGZY.Model.BS_Customer_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BS_Customer_Type set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" name = @name , ");
            strSql.Append(" money = @money , ");
            strSql.Append(" machinenum = @machinenum  ");
            strSql.Append(" where Id=@Id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@name", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@money", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@machinenum", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Money;
            parameters[3].Value = model.MachineNum;
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
        public bool DeleteUserType(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BS_Customer_Type ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,20)			};
            parameters[0].Value = Id;


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
        public ZGZY.Model.BS_Customer_Type GetUserTypeModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, name, money, machinenum  ");
            strSql.Append("  from BS_Customer_Type ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,20)			};
            parameters[0].Value = Id;


           ZGZY.Model.BS_Customer_Type model = new ZGZY.Model.BS_Customer_Type();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.Name = ds.Tables[0].Rows[0]["name"].ToString();
                if (ds.Tables[0].Rows[0]["money"].ToString() != "")
                {
                    model.Money = decimal.Parse(ds.Tables[0].Rows[0]["money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["machinenum"].ToString() != "")
                {
                    model.MachineNum = int.Parse(ds.Tables[0].Rows[0]["machinenum"].ToString());
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
        public DataSet GetUserTypeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BS_Customer_Type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }
    }
}
