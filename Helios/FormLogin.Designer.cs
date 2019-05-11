namespace Helios
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pnlLoginMain = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUserID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlDragPad = new System.Windows.Forms.Panel();
            this.pnlLoginMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLoginMain
            // 
            this.pnlLoginMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLoginMain.BackgroundImage")));
            this.pnlLoginMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLoginMain.Controls.Add(this.btnExit);
            this.pnlLoginMain.Controls.Add(this.btnLogin);
            this.pnlLoginMain.Controls.Add(this.pnlPassword);
            this.pnlLoginMain.Controls.Add(this.pnlUser);
            this.pnlLoginMain.Controls.Add(this.txtPassword);
            this.pnlLoginMain.Controls.Add(this.txtUserID);
            this.pnlLoginMain.Controls.Add(this.pnlDragPad);
            this.pnlLoginMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlLoginMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoginMain.Location = new System.Drawing.Point(0, 0);
            this.pnlLoginMain.Name = "pnlLoginMain";
            this.pnlLoginMain.Size = new System.Drawing.Size(618, 348);
            this.pnlLoginMain.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::Helios.Properties.Resources.back_32_white;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(456, 253);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.Enter += new System.EventHandler(this.btnExit_Enter);
            this.btnExit.Leave += new System.EventHandler(this.btnExit_Leave);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = global::Helios.Properties.Resources.next_32_white;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(549, 253);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(40, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Enter += new System.EventHandler(this.btnLogin_Enter);
            this.btnLogin.Leave += new System.EventHandler(this.btnLogin_Leave);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.Transparent;
            this.pnlPassword.BackgroundImage = global::Helios.Properties.Resources.lock_32_white;
            this.pnlPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlPassword.Location = new System.Drawing.Point(425, 221);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(25, 25);
            this.pnlPassword.TabIndex = 3;
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.Transparent;
            this.pnlUser.BackgroundImage = global::Helios.Properties.Resources.user_32_white;
            this.pnlUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlUser.Location = new System.Drawing.Point(425, 190);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(25, 25);
            this.pnlUser.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.MenuBar;
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPassword.Location = new System.Drawing.Point(456, 221);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PreventEnterBeep = true;
            this.txtPassword.Size = new System.Drawing.Size(133, 26);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.MenuBar;
            // 
            // 
            // 
            this.txtUserID.Border.Class = "TextBoxBorder";
            this.txtUserID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserID.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserID.Location = new System.Drawing.Point(456, 189);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PreventEnterBeep = true;
            this.txtUserID.Size = new System.Drawing.Size(133, 26);
            this.txtUserID.TabIndex = 0;
            // 
            // pnlDragPad
            // 
            this.pnlDragPad.BackColor = System.Drawing.Color.Transparent;
            this.pnlDragPad.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDragPad.Location = new System.Drawing.Point(0, 0);
            this.pnlDragPad.Name = "pnlDragPad";
            this.pnlDragPad.Size = new System.Drawing.Size(618, 44);
            this.pnlDragPad.TabIndex = 0;
            this.pnlDragPad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDragPad_MouseDown);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.ClientSize = new System.Drawing.Size(618, 348);
            this.Controls.Add(this.pnlLoginMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.pnlLoginMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginMain;
        private System.Windows.Forms.Panel pnlDragPad;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserID;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
    }
}