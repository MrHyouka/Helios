using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Implement;
using DAL.Interface;

namespace DAL.Proxy
{
    public class DBHelperProxy
    {
        public static IDBHelper GetDBHelper()
        {
            return new SQLiteHelper();
        }

        public static IDBHelper GetDBHelper(string x)
        {
            return new SQLiteHelper();
        }
    }
}
