﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TSIMSServer.Model;
namespace TSIMSServer.BLL
{
	/// <summary>
	/// t_user
	/// </summary>
	public partial class t_user
	{
		private readonly TSIMSServer.DAL.t_user dal=new TSIMSServer.DAL.t_user();
		public t_user()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string user_num)
		{
			return dal.Exists(user_num);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TSIMSServer.Model.t_user model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TSIMSServer.Model.t_user model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string user_num)
		{
			
			return dal.Delete(user_num);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string user_numlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(user_numlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSIMSServer.Model.t_user GetModel(string user_num)
		{
			
			return dal.GetModel(user_num);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public TSIMSServer.Model.t_user GetModelByCache(string user_num)
		{
			
			string CacheKey = "t_userModel-" + user_num;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(user_num);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSIMSServer.Model.t_user)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSIMSServer.Model.t_user> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSIMSServer.Model.t_user> DataTableToList(DataTable dt)
		{
			List<TSIMSServer.Model.t_user> modelList = new List<TSIMSServer.Model.t_user>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSIMSServer.Model.t_user model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

