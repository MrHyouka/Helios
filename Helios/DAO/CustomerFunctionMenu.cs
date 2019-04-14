using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios.Models;

namespace Helios.DAO
{
    class CustomerFunctionMenu
    {
        private List<Models.FunctionMenu> customerFunctionMenu = new List<Models.FunctionMenu> {
            new FunctionMenu("FUNCM001","数据录入",null),
            new FunctionMenu("FUNCF001","界面配置",null,"Helios","Helios.Forms.FormMenuManager"),
            new FunctionMenu("FUNCF002","内部测试界面","FUNCM001","Helios","Helios.Forms.FormDemo"),
            new FunctionMenu("FUNCF003","外部测试界面","FUNCM001","Forms","Forms.Form1")
        };

        public List<FunctionMenu> CustomerFunctionMenus { get => customerFunctionMenu; set => customerFunctionMenu = value; }
    }
}
