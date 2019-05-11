using DAL.Interface;
using DAL.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DBHelper
    {
        public static IDBHelper GlobalHelper = DBHelperProxy.GetDBHelper();
    }
}
