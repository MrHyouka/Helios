using System.Collections.Generic;
using System.Data;

namespace DAL.Interface
{
    public interface IDBHelper
    {
        #region "事物操作"

        /// <summary>
        /// 打开数据库连接并开启事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交事务并关闭数据库连接
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 回滚事务并关闭数据库连接
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// 在已开启的事务中执行增删改操作，返回受影响的行数
        /// </summary>
        /// <param name="sql">执行语句</param>
        /// <param name="parameters">执行语句参数</param>
        /// <returns></returns>
        int ExecuteNonQueryWithTransaction(string sql, object[] parameters);

        #endregion

        #region "非事务操作"

        /// <summary>
        /// 执行增删改操作，返回受影响的行数 
        /// </summary>
        /// <param name="sql">执行语句</param>
        /// <param name="parameters">执行语句参数</param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql, object[] parameters);

        /// <summary>
        /// 批量处理增删改操作语句
        /// </summary>
        /// <param name="list">执行语句与参数集合</param>
        void ExecuteNonQueryBatch(List<KeyValuePair<string, object[]>> list);

        /// <summary>
        /// 执行整表插入数据操作
        /// </summary>
        /// <param name="tableName">需要操作的表名</param>
        /// <param name="dt">需要插入的表数据</param>
        /// <returns></returns>
        int ExecuteInsertByDataTable(string tableName, DataTable dt);

        /// <summary>
        /// 查询并返回不含数据的表结构
        /// </summary>
        /// <param name="tableName">需要查询的表名</param>
        /// <returns></returns>
        DataTable ExecuteQueryTableStructure(string tableName);

        /// <summary>
        /// 执行查询语句，并返回查询结果的DataTable实例
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        DataTable ExecuteQuery(string sql, object[] parameters);

        /// <summary>
        /// 执行查询语句，并返回第一行第一列的数据
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        object ExecuteScalar(string sql, object[] parameters);

        /// <summary>
        /// 执行查询语句，并返回查询结果的泛型实例序列
        /// </summary>
        /// <typeparam name="T">指定的泛型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        List<T> ExecuteQueryForList<T>(string sql, object[] parameters) where T : new();

        /// <summary>
        /// 执行查询语句，并返回查询结果第一行的泛型实例
        /// </summary>
        /// <typeparam name="T">指定的泛型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        T ExecuteQueryForObject<T>(string sql, object[] parameters) where T : new();

        #endregion
    }
}
