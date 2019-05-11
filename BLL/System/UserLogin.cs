using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using DAL.Properties;

namespace BLL.System
{
    public class UserLogin
    {
        public static bool UserLoginCheck(string user_id, string password)
        {
            if(password.Equals(DBHelper.GlobalHelper.ExecuteQueryForObject<User>("select * from User where user_id =?", new object[] { user_id }).USER_PASSWORD))
                return true;
            else
                return false;
        }
    }
}
