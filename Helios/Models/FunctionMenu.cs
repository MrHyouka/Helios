using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Models
{
    public class FunctionMenu
    {
        public string MenuName { get; set; }
        public string MenuDesc { get; set; }
        public string MenuType { get; set; }
        public int MenuIndex { get; set; }
        public string ParentMenuName { get; set; }
        public string AssemblyName { get; set; }
        public string FormName { get; set; }

        /// <summary>
        /// 菜单选项
        /// </summary>
        public FunctionMenu()
        {

        }

        /// <summary>
        /// 菜单选项
        /// </summary>
        /// <param name="MenuName">菜单ID</param>
        /// <param name="MenuDesc">菜单名称</param>
        /// <param name="MenuType">菜单类型(M/F)</param>
        /// <param name="MenuIndex">菜单索引</param>
        /// <param name="ParentMenuName">父菜单ID</param>
        /// <param name="AssemblyName">菜单功能所在相对路径文件名</param>
        /// <param name="FormName">菜单功能对应界面类名</param>
        public FunctionMenu(string MenuName, string MenuDesc, string MenuType, int MenuIndex, string ParentMenuName, string AssemblyName, string FormName)
        {
            this.MenuName = MenuName;
            this.MenuDesc = MenuDesc;
            this.MenuType = MenuType;
            this.MenuIndex = MenuIndex;
            this.ParentMenuName = ParentMenuName;
            this.AssemblyName = AssemblyName;
            this.FormName = FormName;
        }
    }
}
