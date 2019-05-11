using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DAL;
using DevComponents.DotNetBar;
using Helios.DAL;
using Helios.Properties;
using Model;
using BLL.System;

namespace Helios
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        #region "无边框拖动效果"
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void pnlDragPad_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        #region "界面按钮外观效果"

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = (System.Drawing.Image)Resources.next_32_green;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = (System.Drawing.Image)Resources.next_32_white;
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = (System.Drawing.Image)Resources.next_32_green;
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = (System.Drawing.Image)Resources.next_32_white;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = (System.Drawing.Image)Resources.back_32_red;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = (System.Drawing.Image)Resources.back_32_white;
        }

        private void btnExit_Enter(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = (System.Drawing.Image)Resources.back_32_red;
        }

        private void btnExit_Leave(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = (System.Drawing.Image)Resources.back_32_white;
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (UserLogin.UserLoginCheck(txtUserID.Text.Trim(), txtPassword.Text.Trim()) == true)
            {
                Program.SetLoginFlag = true;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Resources.GLaDOS_Welcome);
            player.Load();
            player.Play();
        }

        private bool CheckLogin(string user_id, string pass_word)
        {
            if(pass_word.Equals(DBHelper.GlobalHelper.ExecuteScalar(SQLResources.SQL_Select_User_Ver_001,new object[] { user_id })))
                return true;
            else
                return false;
        }
    }
}