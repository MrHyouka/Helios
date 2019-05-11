using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Helios.DAL
{
    class MySqlHelper : IDBHelper
    {
        private static string server = System.Configuration.ConfigurationManager.AppSettings["DatabaseServer"];
        private static string dbName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"];
        private static string dbUser = System.Configuration.ConfigurationManager.AppSettings["DatabaseUser"];
        private static string dbPassword = System.Configuration.ConfigurationManager.AppSettings["DatabasePassword"];
        private static string dbCharset = System.Configuration.ConfigurationManager.AppSettings["DatabaseCharset"];
        private static string dbPooling = System.Configuration.ConfigurationManager.AppSettings["DatabasePooling"];
        public static string connectionString = string.Format("Data Source={0};Database={1};User Id={2};Password={3};charset={4};pooling={5}", server, dbName, dbUser, dbPassword, dbCharset, dbPooling);

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public int ExecuteInsertByDataTable(string tableName, DataTable dt)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQueryBatch(List<KeyValuePair<string, object[]>> list)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQueryWithTransaction(string sql, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteQuery(string sql, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Collection<T> ExecuteQueryForCollection<T>(string sql, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQueryForList<T>(string sql, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteQueryTableStructure(string tableName)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string sql, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
