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

namespace Helios
{
    public partial class FormMain : Office2007Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            GetFunctionMenuList();
            AddNode(functionList);
        }

        public void OpenFormByReflection(string assemblyName, string formName)
        {
            Type formType = null;

            //如果AssemblyName与当前本程序一致，则从.exe中获取界面
            if (assemblyName == Assembly.GetExecutingAssembly().GetName().Name)
            {
                formType = Assembly.LoadFrom(assemblyName + ".exe").GetType(formName);
            }
            else
            {
                formType = Assembly.LoadFrom(assemblyName + ".dll").GetType(formName);
            }

            if (formType != null)//查看反射是否成功
            {
                if (typeof(Form).IsAssignableFrom(formType)) //反射结果是否为窗体Form  关键的判断
                {
                    Form form = (Form)Activator.CreateInstance(formType); //创建反射窗体实例  建立窗体的实例
                    AddFormToTab(form, form.Text, form.Text);
                }
                else
                { MessageBox.Show("指定的类型不能是从Form类型继承", "温馨提示"); }
            }
            else
            { MessageBox.Show("指定的类型不存在", "温馨提示"); }
        }

        public void AddFormToTab(Form form, string tabName)
        {
            AddFormToTab(form, tabName, tabName);
        }

        public void AddFormToTab(Form form, string tabName, string tabText)
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

            //新增Tab，并将页面Dock进新页面
            SuperTabItem tabItem = this.tabMain.CreateTab(tabName);
            tabItem.Text = tabText;
            tabItem.Name = tabName;
            tabItem.AttachedControl.Controls.Add(form);

            //选中新增的Tab
            this.tabMain.SelectedTab = tabItem;
        }

        /// <summary>
        /// 通过反射加载界面
        /// </summary>
        /// <param name="AssemblyName">界面所在文件路径名</param>
        /// <param name="strName">界面类名</param>
        public static void CreateFormByReflection(string assemblyName, string formName)
        {
            Form doc = GetFormByReflection(assemblyName, formName);
            doc.Show();
        }

        public static Form GetFormByReflection(string assemblyName, string formName)
        {
            return (Form)Assembly.Load(assemblyName).CreateInstance(formName);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OpenFormByReflection("Helios", "Helios.Forms.FormDemo");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            OpenFormByReflection("Forms", "Forms.Form1");
        }


        public void GetFunctionMenuTree()
        {
            TreeNode functionTree = new TreeNode();
            treeFunctionMenu.DataSource = functionTree;
        }
        
        List<FunctionMenu> functionList = new List<FunctionMenu>();
       
        private void treeFunctionMenu_Click(object sender, EventArgs e)
        {
            if (treeFunctionMenu.SelectedNode == null) return;
            if (treeFunctionMenu.SelectedNode.Nodes.Count != 0) return;
            //MessageBox.Show("Text:" + treeFunctionMenu.SelectedNode.Text + "\nTag:" + treeFunctionMenu.SelectedNode.Tag);
            FunctionMenu function = (FunctionMenu)treeFunctionMenu.SelectedNode.Tag;
            string assemblyName = function.AssemblyName;
            string formName = function.FormName;
            OpenFormByReflection(assemblyName, formName);
        }


        private void GetFunctionMenuList()
        {
            FunctionMenu function = new FunctionMenu
            {
                MenuName = "FUNC001",
                MenuDesc = "FUNC001"
            };
            functionList.Add(function);

            function = new FunctionMenu
            {
                MenuName = "FUNC002",
                MenuDesc = "FormDemo",
                ParentMenuName = "FUNC001",
                AssemblyName = "Helios",
                FormName = "Helios.Forms.FormDemo"
            };
            functionList.Add(function);

            function = new FunctionMenu
            {
                MenuName = "FUNC002",
                MenuDesc = "Form1",
                ParentMenuName = "FUNC001",
                AssemblyName = "Forms",
                FormName = "Forms.Form1"
            };
            functionList.Add(function);

            function = new FunctionMenu
            {
                MenuName = "FUNC003",
                MenuDesc = "FormMenuManager",
                ParentMenuName = "FUNC001",
                AssemblyName = "Helios",
                FormName = "Helios.Forms.FormMenuManager"
            };
            functionList.Add(function);
        }

        public void AddNode(List<FunctionMenu> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ParentMenuName == null)
                {
                    Node pnode = new Node();
                    pnode.Text = list[i].MenuDesc;
                    pnode.Tag = list[i];
                    treeFunctionMenu.Nodes.Add(pnode);
                    AddChildNode(list,list[i].MenuName, pnode);
                }
            }
        }

        public void AddChildNode(List<FunctionMenu> list ,string pid, Node pnode)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ParentMenuName == pid)
                {
                    Node cnode = new Node();
                    cnode.Text = list[i].MenuDesc;
                    cnode.Tag = list[i];
                    pnode.Nodes.Add(cnode);
                    AddChildNode(list,list[i].MenuName, cnode);
                }
            }
        }
    }
}
