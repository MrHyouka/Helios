using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User
    {
        public User()
        {
        }

        public User(string user_id)
        {
            USER_ID = user_id;
        }

        public string USER_ID { get; set; }
        public string USER_NAME{ get; set; }
        public string USER_PASSWORD{ get; set; }
        public string USER_GROUP{ get; set; }
        public string DEPARTMENT{ get; set; }
        public string MOBILE_PHONE{ get; set; }
        public string TEL_PHONE{ get; set; }
        public string E_MAIL{ get; set; }
        public char SEX{ get; set; }
        public DateTime BIRTHDAY{ get; set; }
        public string CREATE_USER{ get; set; }
        public DateTime CREATE_TIME{ get; set; }
        public string UPDATE_USER{ get; set; }
        public DateTime UPDATE_TIME{ get; set; }
    }
}
