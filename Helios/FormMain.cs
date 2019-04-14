using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using System.IO;
using Helios.Models;
using Helios.DAO;

namespace Helios
{
    public partial class FormMain : Office2007Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        List<FunctionMenu> customerFunctionMenus = new List<FunctionMenu>();
        Node customerFunctionNode = new Node();

        private void FormMain_Load(object sender, EventArgs e)
        {
            GetFunctionMenuList();
            SetCustomerFunctionMenu();
        }

        #region "初始化主界面功能菜单"

        /// <summary>
        /// 获取功菜单能列表
        /// </summary>
        private void GetFunctionMenuList()
        {
            //=======************************************=======//
            //=======此处代码正式使用时替换成对应的数据源=======//
            //=======************************************=======//

            this.customerFunctionMenus = new CustomerFunctionMenu().CustomerFunctionMenus;
        }

        /// <summary>
        /// 设置用户功能菜单
        /// </summary>
        private void SetCustomerFunctionMenu()
        {
            this.ConvertFunctionMenuListToNode(customerFunctionMenus, treeFunctionMenu.Nodes);
        }

        /// <summary>
        /// 将菜单列表转为菜单树，并将菜单对象赋值给成员Tag
        /// </summary>
        /// <param name="sourceList">菜单列表</param>
        /// <param name="targetNodeCollection">菜单Node</param>
        public void ConvertFunctionMenuListToNode(List<FunctionMenu> sourceList, NodeCollection targetNodeCollection)
        {
            for (int i = 0; i < sourceList.Count; i++)
            {
                if (sourceList[i].ParentMenuName == null)
                {
                    Node parentNode = new Node
                    {
                        Text = sourceList[i].MenuDesc,
                        Tag = sourceList[i]
                    };
                    targetNodeCollection.Add(parentNode);
                    AddChildNode(sourceList, sourceList[i].MenuName, parentNode);
                }
            }
        }

        /// <summary>
        /// 递归填充子Node
        /// </summary>
        /// <param name="sourceList">菜单列表</param>
        /// <param name="parentName">父Node名</param>
        /// <param name="parentNode">父Node</param>
        public void AddChildNode(List<FunctionMenu> sourceList, string parentName, Node parentNode)
        {
            for (int i = 0; i < sourceList.Count; i++)
            {
                if (sourceList[i].ParentMenuName == parentName)
                {
                    Node childNode = new Node
                    {
                        Text = sourceList[i].MenuDesc,
                        Tag = sourceList[i]
                    };
                    parentNode.Nodes.Add(childNode);
                    AddChildNode(sourceList, sourceList[i].MenuName, childNode);
                }
            }
        }

        #endregion

        #region "打开新界面"

        /// <summary>
        /// 通过反射获取窗体对象
        /// </summary>
        /// <param name="assemblyName">窗体所在相对路径文件名</param>
        /// <param name="formName">窗体类名</param>
        /// <returns>窗体对象</returns>
        public static Form GetFormByReflection(string assemblyName, string formName)
        {
            try
            {
                Type formType = null;
                if (assemblyName == Assembly.GetExecutingAssembly().GetName().Name) //如果AssemblyName与当前本程序一致，则从.exe文件中获取界面
                {
                    formType = Assembly.LoadFrom(assemblyName + ".exe").GetType(formName);
                }
                else //否则，从.dll文件中获取界面
                {
                    formType = Assembly.LoadFrom(assemblyName + ".dll").GetType(formName);
                }
                if (formType != null)//查看反射是否成功
                {
                    if (typeof(Form).IsAssignableFrom(formType)) //反射结果是否为窗体Form
                    {
                        //return (Form)Assembly.Load(assemblyName).CreateInstance(formName);
                        return (Form)Activator.CreateInstance(formType); //返回窗体对象实例
                    }
                    else
                    { MessageBox.Show("指定的类型不能是从Form类型继承", "温馨提示"); return null; }
                }
                else
                { MessageBox.Show("指定的类型不存在", "温馨提示"); return null; }
            }
            catch { throw; }
        }

        /// <summary>
        /// 将界面添加至Tab页中
        /// </summary>
        /// <param name="form">界面对象</param>
        /// <param name="tabName">Tab名称</param>
        /// <param name="tabText">Tab显示页签名称</param>
        public void AddFormToTab(Form form, string tabName, string tabText)
        {
            try
            {
                foreach (SuperTabItem tab in this.tabMain.Tabs)
                {
                    //如果界面已打开，则切换至该界面
                    if (tab.Name == tabName)
                    {
                        this.tabMain.SelectedTab = tab;
                        return;
                    }
                }
                //配置子窗体必要属性
                form.TopLevel = false;
                form.Visible = true;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                //新增Tab，并将页面Dock进新Tab页
                SuperTabItem tabItem = this.tabMain.CreateTab(tabName);
                if (tabText == null || tabText == string.Empty)
                    tabItem.Text = tabName;
                else
                    tabItem.Text = tabText;
                tabItem.Name = tabName;
                tabItem.AttachedControl.Controls.Add(form);

                //选中新增的Tab
                this.tabMain.SelectedTab = tabItem;
            }
            catch { throw; }
        }

        /// <summary>
        /// 通过功能菜单对象在Tab中打开功能界面
        /// </summary>
        /// <param name="function"></param>
        private void OpenNewTabForm(FunctionMenu function)
        {
            AddFormToTab(GetFormByReflection(function.AssemblyName, function.FormName), function.MenuName, function.MenuDesc);
        }

        private void treeFunctionMenu_Click(object sender, EventArgs e)
        {
            if (treeFunctionMenu.SelectedNode == null) return;
            if (treeFunctionMenu.SelectedNode.Nodes.Count != 0) return;
            OpenNewTabForm((FunctionMenu)treeFunctionMenu.SelectedNode.Tag);
        }

        #endregion
    }
}
