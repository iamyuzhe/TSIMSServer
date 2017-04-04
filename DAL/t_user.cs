﻿using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TSIMSServer.DAL
{
	/// <summary>
	/// 数据访问类:t_user
	/// </summary>
	public partial class t_user
	{
		public t_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string user_num)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_user");
			strSql.Append(" where user_num=@user_num ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_num", MySqlDbType.VarChar,50)			};
			parameters[0].Value = user_num;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSIMSServer.Model.t_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_user(");
			strSql.Append("user_num,user_name,password,college_num,department_num,major_num,class_num,enter_school_date,phone,identity)");
			strSql.Append(" values (");
			strSql.Append("@user_num,@user_name,@password,@college_num,@department_num,@major_num,@class_num,@enter_school_date,@phone,@identity)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@password", MySqlDbType.VarChar,50),
					new MySqlParameter("@college_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@department_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@major_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@class_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@enter_school_date", MySqlDbType.Date),
					new MySqlParameter("@phone", MySqlDbType.VarChar,50),
					new MySqlParameter("@identity", MySqlDbType.Int32,11)};
			parameters[0].Value = model.user_num;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.password;
			parameters[3].Value = model.college_num;
			parameters[4].Value = model.department_num;
			parameters[5].Value = model.major_num;
			parameters[6].Value = model.class_num;
			parameters[7].Value = model.enter_school_date;
			parameters[8].Value = model.phone;
			parameters[9].Value = model.identity;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(TSIMSServer.Model.t_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_user set ");
			strSql.Append("user_name=@user_name,");
			strSql.Append("password=@password,");
			strSql.Append("college_num=@college_num,");
			strSql.Append("department_num=@department_num,");
			strSql.Append("major_num=@major_num,");
			strSql.Append("class_num=@class_num,");
			strSql.Append("enter_school_date=@enter_school_date,");
			strSql.Append("phone=@phone,");
			strSql.Append("identity=@identity");
			strSql.Append(" where user_num=@user_num ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@password", MySqlDbType.VarChar,50),
					new MySqlParameter("@college_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@department_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@major_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@class_num", MySqlDbType.VarChar,50),
					new MySqlParameter("@enter_school_date", MySqlDbType.Date),
					new MySqlParameter("@phone", MySqlDbType.VarChar,50),
					new MySqlParameter("@identity", MySqlDbType.Int32,11),
					new MySqlParameter("@user_num", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.user_name;
			parameters[1].Value = model.password;
			parameters[2].Value = model.college_num;
			parameters[3].Value = model.department_num;
			parameters[4].Value = model.major_num;
			parameters[5].Value = model.class_num;
			parameters[6].Value = model.enter_school_date;
			parameters[7].Value = model.phone;
			parameters[8].Value = model.identity;
			parameters[9].Value = model.user_num;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string user_num)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_user ");
			strSql.Append(" where user_num=@user_num ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_num", MySqlDbType.VarChar,50)			};
			parameters[0].Value = user_num;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string user_numlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_user ");
			strSql.Append(" where user_num in ("+user_numlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public TSIMSServer.Model.t_user GetModel(string user_num)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select user_num,user_name,password,college_num,department_num,major_num,class_num,enter_school_date,phone,identity from t_user ");
			strSql.Append(" where user_num=@user_num ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_num", MySqlDbType.VarChar,50)			};
			parameters[0].Value = user_num;

			TSIMSServer.Model.t_user model=new TSIMSServer.Model.t_user();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public TSIMSServer.Model.t_user DataRowToModel(DataRow row)
		{
			TSIMSServer.Model.t_user model=new TSIMSServer.Model.t_user();
			if (row != null)
			{
				if(row["user_num"]!=null)
				{
					model.user_num=row["user_num"].ToString();
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["college_num"]!=null)
				{
					model.college_num=row["college_num"].ToString();
				}
				if(row["department_num"]!=null)
				{
					model.department_num=row["department_num"].ToString();
				}
				if(row["major_num"]!=null)
				{
					model.major_num=row["major_num"].ToString();
				}
				if(row["class_num"]!=null)
				{
					model.class_num=row["class_num"].ToString();
				}
				if(row["enter_school_date"]!=null && row["enter_school_date"].ToString()!="")
				{
					model.enter_school_date=DateTime.Parse(row["enter_school_date"].ToString());
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["identity"]!=null && row["identity"].ToString()!="")
				{
					model.identity=int.Parse(row["identity"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select user_num,user_name,password,college_num,department_num,major_num,class_num,enter_school_date,phone,identity ");
			strSql.Append(" FROM t_user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.user_num desc");
			}
			strSql.Append(")AS Row, T.*  from t_user T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_user";
			parameters[1].Value = "user_num";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

