using AZLinli.Com.Blog.IRepository.Base;
using AZLinli.Com.Blog.IServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AZLinli.Com.Blog.Services.Base
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        public IBaseRepository<TEntity> baseDal;

        #region 查询
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return baseDal.QueryWhere(predicate);
        }

        /// <summary>
        /// 多表关联查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames)
        {
            return baseDal.QueryJoin(predicate, tableNames);

        }

        /// <summary>
        /// 升序查询还是降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="IsQueryOrderBy"></param>
        /// <returns></returns>
        public List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy)
        {
            return baseDal.QueryOrderBy(predicate, keySelector, IsQueryOrderBy);
        }

        /// <summary>
        /// 升序分页查询还是降序分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pagesize">一页多少条</param>
        /// <param name="rowcount">返回共多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <param name="IsQueryOrderBy">true为升序 false为降序</param>
        /// <returns></returns>
        public List<TEntity> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy)
        {

            return baseDal.QueryByPage(pageIndex, pagesize, out rowcount, predicate, keySelector, IsQueryOrderBy);

        }

        /// <summary>
        /// 从第几条开始用于DataTables
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页开始</param>
        /// <param name="pagesize">一页几条</param>
        /// <param name="rowcount">一共多少条</param>
        /// <param name="predicate">条件</param>
        /// <param name="keySelector">排序关键字</param>
        /// <param name="IsQueryOrderBy">升序还是降序</param>
        /// <returns></returns>
        public List<TEntity> QueryByBeginPage<TKey>(int pageIndex, int pagesize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy)
        {
            return baseDal.QueryByBeginPage(pageIndex, pagesize, out rowcount, predicate, keySelector, IsQueryOrderBy);
        }
        #endregion

        #region 编辑
        /// <summary>
        /// 通过传入的model加需要修改的字段来更改数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertys"></param>
        public void Edit(TEntity model, string[] propertys)
        {
            baseDal.Edit(model, propertys);
        }

        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        public void Edit(TEntity model)
        {
            baseDal.Edit(model);
        }
        #endregion

        #region 删除
        public void Delete(TEntity model, bool isadded)
        {
            baseDal.Delete(model, isadded);
        }
        #endregion

        #region 新增
        public void Add(TEntity model)
        {
            baseDal.Add(model);
        }
        #endregion

        #region 统一提交
        public int SaverChanges()
        {
            return baseDal.SaverChanges();
        }
        #endregion

        #region 调用存储过程返回一个指定的TResult
        public List<TResult> RunProc<TResult>(string sql, params object[] pamrs)
        {
            return baseDal.RunProc<TResult>(sql, pamrs);
        }
        #endregion
    }

}
