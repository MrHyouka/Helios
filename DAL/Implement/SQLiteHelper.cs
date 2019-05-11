using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL.Interface;
using System.Data.SQLite;
using System.Configuration;
using System.Reflection;

namespace DAL.Implement
{
    public class SQLiteHelper : IDBHelper
    {
        private static string localDatabasePath = ConfigurationManager.AppSettings["LocalDatabasePath"];
        private static string localDatabaseVersion = ConfigurationManager.AppSettings["LocalDatabaseVersion"];
        private static string localDatabasePassword = ConfigurationManager.AppSettings["LocalDatabasePassword"];
        private static string connectionString = ConfigurationManager.ConnectionStrings["sqlite"].ToString();

        //"server=10.40.21.8;userid=root;password=QIUTONG;Database=qiusql;charset=utf8";

        #region "事务处理"
        private SQLiteTransaction transaction;
        private SQLiteConnection transactionConnection;

        /// <summary>
        /// 打开数据库连接并开启事务
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                transactionConnection = new SQLiteConnection(connectionString);
                transactionConnection.Open();
                transaction = transactionConnection.BeginTransaction();
            }
            catch (Exception) { RollbackTransaction(); throw; }
        }

        /// <summary>
        /// 提交事务并关闭数据库连接
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                transaction.Commit();
                transactionConnection.Close();
                transactionConnection.Dispose();
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// 回滚事务并关闭数据库连接
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                transaction.Rollback();
                transactionConnection.Close();
                transactionConnection.Dispose();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 在已开启的事务中执行增删改操作，返回受影响的行数
        /// </summary>
        /// <param name="sql">执行语句</param>
        /// <param name="parameters">执行语句参数</param>
        /// <returns></returns>
        public int ExecuteNonQueryWithTransaction(string sql, object[] parameters)
        {
            int affectedRows = 0;
            try
            {
                SQLiteCommand transactionCommand = new SQLiteCommand(transactionConnection);
                transactionCommand.CommandText = sql;
                if (parameters != null && parameters.Length != 0)
                {
                    foreach (object parameter in parameters)
                    {
                        transactionCommand.Parameters.Add(new SQLiteParameter(null, parameter));
                    }
                }
                affectedRows = transactionCommand.ExecuteNonQuery();
            }
            catch (Exception) { RollbackTransaction(); throw; }

            return affectedRows;
        }
        #endregion

        #region "非事务处理"

        /// <summary>
        /// 执行增删改操作，返回受影响的行数 
        /// </summary>
        /// <param name="sql">执行语句</param>
        /// <param name="parameters">执行语句参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, object[] parameters)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandText = sql;
                        if (parameters != null && parameters.Length != 0)
                        {
                            foreach (object parameter in parameters)
                            {
                                command.Parameters.Add(new SQLiteParameter(null, parameter));
                            }
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception) { throw; }
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// 批量处理增删改操作语句
        /// </summary>
        /// <param name="list">执行语句与参数集合</param>
        public void ExecuteNonQueryBatch(List<KeyValuePair<string, object[]>> list)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try { connection.Open(); }
                catch { throw; }
                using (SQLiteTransaction tran = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        try
                        {
                            foreach (var item in list)
                            {
                                command.CommandText = item.Key;
                                if (item.Value != null)
                                {
                                    command.Parameters.AddRange(item.Value);
                                }
                                if (item.Value != null && item.Value.Length != 0)
                                {
                                    foreach (object parameter in item.Value)
                                    {
                                        command.Parameters.Add(new SQLiteParameter(null, parameter));
                                    }
                                }
                                command.ExecuteNonQuery();
                            }
                            tran.Commit();
                        }
                        catch (Exception) { tran.Rollback(); throw; }
                    }
                }
            }
        }

        /// <summary>
        /// 执行整表插入数据操作
        /// </summary>
        /// <param name="tableName">需要操作的表名</param>
        /// <param name="dt">需要插入的表数据</param>
        /// <returns></returns>
        public int ExecuteInsertByDataTable(string tableName, DataTable dt)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                { connection.Open(); }
                catch { throw; }
                using (SQLiteTransaction tran = connection.BeginTransaction())
                {
                    try
                    {
                        string sql = "select * from " + tableName + " where 1=2";
                        SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);
                        SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da);
                        da.InsertCommand = scb.GetInsertCommand();
                        affectedRows = da.Update(dt);
                        tran.Commit();
                    }
                    catch (Exception) { tran.Rollback(); throw; }
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// 查询并返回不含数据的表结构
        /// </summary>
        /// <param name="tableName">需要查询的表名</param>
        /// <returns></returns>
        public DataTable ExecuteQueryTableStructure(string tableName)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    try
                    {
                        conn.Open();
                        command.CommandText = "select * from " + tableName + " where 1=2";
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                    catch (Exception) { throw; }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，并返回第一行第一列的数据
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, object[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    try
                    {
                        conn.Open();
                        command.CommandText = sql;
                        if (parameters != null && parameters.Length != 0)
                        {
                            foreach (object parameter in parameters)
                            {
                                command.Parameters.Add(new SQLiteParameter(null, parameter));
                            }
                        }
                        return command.ExecuteScalar();
                    }
                    catch (Exception) { throw; }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，并返回查询结果的DataTable实例
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sql, object[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    try
                    {
                        if (parameters != null && parameters.Length != 0)
                        {
                            foreach (object parameter in parameters)
                            {
                                command.Parameters.Add(new SQLiteParameter(null, parameter));
                            }
                        }
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                    catch (Exception) { throw; }

                }
            }
        }

        /// <summary>
        /// 执行查询语句，并返回查询结果的泛型实例序列
        /// </summary>
        /// <typeparam name="T">指定的泛型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        public List<T> ExecuteQueryForList<T>(string sql, object[] parameters) where T : new()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    try
                    {
                        if (parameters != null && parameters.Length != 0)
                        {
                            foreach (object parameter in parameters)
                            {
                                command.Parameters.Add(new SQLiteParameter(null, parameter));
                            }
                        }
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        if (data.Rows.Count == 0) return new List<T>();
                        else return ConvertToList<T>(data);
                    }
                    catch (Exception) { throw; }

                }
            }
        }

        /// <summary>
        /// 执行查询语句，并返回查询结果第一行的泛型实例
        /// </summary>
        /// <typeparam name="T">指定的泛型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        public T ExecuteQueryForObject<T>(string sql, object[] parameters) where T : new()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    try
                    {
                        if (parameters != null && parameters.Length != 0)
                        {
                            foreach (object parameter in parameters)
                            {
                                command.Parameters.Add(new SQLiteParameter(null, parameter));
                            }
                        }
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        if (data.Rows.Count == 0) return default(T);
                        else return ConvertToGeneric<T>(data);
                    }
                    catch (Exception) { throw; }

                }
            }
        }

        /// <summary>
        /// 执行查询语句，并返回关联的SQLiteDataReader实例 
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">查询语句参数</param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteReader(string sql, object[] parameters)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            try
            {
                if (parameters != null && parameters.Length != 0)
                {
                    foreach (object parameter in parameters)
                    {
                        command.Parameters.Add(new SQLiteParameter(null, parameter));
                    }
                }
                connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region "数据类型转化"
        /// <summary>
        /// 将SQLiteDataReader类型数据转换为泛型对象
        /// </summary>
        /// <typeparam name="T">需转换的泛型</typeparam>
        /// <param name="result">需转换的数据</param>
        /// <returns></returns>
        public T ConvertReaderToType<T>(SQLiteDataReader dataReader)
        {
            T t = System.Activator.CreateInstance<T>();
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo p in properties)
            {
                System.Reflection.PropertyInfo[] resultProperties = t.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo rp in resultProperties)
                {
                    if (rp.Name == p.Name)
                    {
                        rp.SetValue(t, dataReader[p.Name] == null ? "" : dataReader[p.Name].GetType().ToString() == "System.DateTime" ? dataReader.GetValue(dataReader.GetOrdinal(p.Name)).ToString() : dataReader[p.Name].ToString(), null);
                        //rp.SetValue(t, result[p.Name] == null ? "" : result[p.Name].ToString(), null);
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// 将DataTable类型数据转换为泛型对象序列
        /// </summary>
        /// <typeparam name="T">需转换的泛型</typeparam>
        /// <param name="dt">需转换的数据</param>
        /// <returns></returns>
        public List<T> ConvertToList<T>(DataTable dt) where T : new()
        {
            try
            {
                // 定义集合 
                List<T> ts = new List<T>();
                // 获得此模型的类型 
                Type type = typeof(T);
                //定义一个临时变量 
                string tempName = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    //遍历DataTable中所有的数据行  
                    foreach (DataRow dr in dt.Rows)
                    {
                        T t = new T();
                        // 获得此模型的公共属性 
                        PropertyInfo[] propertys = t.GetType().GetProperties();
                        //遍历该对象的所有属性 
                        foreach (PropertyInfo pi in propertys)
                        {
                            tempName = pi.Name;//将属性名称赋值给临时变量   
                            //检查DataTable是否包含此列（列名==对象的属性名）     
                            if (dt.Columns.Contains(tempName))
                            {
                                // 判断此属性是否有Setter   
                                if (!pi.CanWrite) continue;//该属性不可写，直接跳出   
                                //取值   
                                object value = dr[tempName];
                                //如果非空，则赋给对象的属性
                                if (value != DBNull.Value)
                                {
                                    if (pi.PropertyType.FullName == "System.DateTime")
                                    {
                                        if (value.ToString() != "")
                                        {
                                            pi.SetValue(t, Convert.ToDateTime(value), null);
                                        }
                                    }
                                    else
                                    {
                                        pi.SetValue(t, value, null);
                                    }
                                }
                            }
                        }
                        //对象添加到泛型集合中 
                        ts.Add(t);
                    }
                }
                return ts;
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// 将DataTable类型数据第一行转换为泛型对象
        /// </summary>
        /// <typeparam name="T">需转换的泛型</typeparam>
        /// <param name="dt">需转换的数据</param>
        /// <returns></returns>
        public T ConvertToGeneric<T>(DataTable dt) where T : new()
        {
            try
            {
                Type type = typeof(T);
                //定义一个临时变量 
                string tempName = string.Empty;
                if (dt.Rows.Count != 0)
                {
                    //遍历DataTable中所有的数据行  
                    DataRow dr = dt.Rows[0];
                    T t = new T();
                    // 获得此模型的公共属性 
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    //遍历该对象的所有属性 
                    foreach (PropertyInfo pi in propertys)
                    {

                        tempName = pi.Name;//将属性名称赋值给临时变量   
                        //检查DataTable是否包含此列（列名==对象的属性名）     
                        if (dt.Columns.Contains(tempName))
                        {
                            // 判断此属性是否有Setter   
                            if (!pi.CanWrite) continue;//该属性不可写，直接跳出   
                            //取值   
                            object value = dr[tempName];
                            //如果非空，则赋给对象的属性
                            if (value != DBNull.Value)
                            {
                                if (pi.PropertyType.FullName == "System.DateTime")
                                {
                                    if (value.ToString() != "")
                                    {
                                        pi.SetValue(t, Convert.ToDateTime(value), null);
                                    }
                                }
                                else
                                {
                                    pi.SetValue(t, value, null);
                                }
                            }
                        }
                    }
                    return t;
                }
                else return default(T);
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
