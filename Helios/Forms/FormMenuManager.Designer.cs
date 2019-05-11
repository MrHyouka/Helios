namespace Helios.Forms
{
    partial class FormMenuManager
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
            this.components = new System.ComponentModel.Container();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.expMenuList = new DevComponents.DotNetBar.ExpandablePanel();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbMenuType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pnlMenuManager = new System.Windows.Forms.Panel();
            this.expMenuList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // expMenuList
            // 
            this.expMenuList.CanvasColor = System.Drawing.SystemColors.Control;
            this.expMenuList.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expMenuList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expMenuList.Controls.Add(this.listViewEx1);
            this.expMenuList.Controls.Add(this.panel1);
            this.expMenuList.DisabledBackColor = System.Drawing.Color.Empty;
            this.expMenuList.Dock = System.Windows.Forms.DockStyle.Left;
            this.expMenuList.HideControlsWhenCollapsed = true;
            this.expMenuList.Location = new System.Drawing.Point(0, 0);
            this.expMenuList.Name = "expMenuList";
            this.expMenuList.Size = new System.Drawing.Size(286, 686);
            this.expMenuList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expMenuList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expMenuList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expMenuList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expMenuList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expMenuList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expMenuList.Style.GradientAngle = 90;
            this.expMenuList.TabIndex = 10;
            this.expMenuList.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expMenuList.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expMenuList.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expMenuList.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expMenuList.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expMenuList.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expMenuList.TitleStyle.GradientAngle = 90;
            this.expMenuList.TitleText = "菜单列表";
            // 
            // listViewEx1
            // 
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx1.Location = new System.Drawing.Point(0, 70);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(286, 616);
            this.listViewEx1.TabIndex = 4;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "菜单编码";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "菜单名";
            this.columnHeader3.Width = 129;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cmbMenuType);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 44);
            this.panel1.TabIndex = 5;
            // 
            // cmbMenuType
            // 
            this.cmbMenuType.DisplayMember = "Text";
            this.cmbMenuType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMenuType.FormattingEnabled = true;
            this.cmbMenuType.ItemHeight = 15;
            this.cmbMenuType.Location = new System.Drawing.Point(58, 11);
            this.cmbMenuType.Name = "cmbMenuType";
            this.cmbMenuType.Size = new System.Drawing.Size(88, 21);
            this.cmbMenuType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMenuType.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "菜单类型";
            // 
            // pnlMenuManager
            // 
            this.pnlMenuManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuManager.Location = new System.Drawing.Point(286, 0);
            this.pnlMenuManager.Name = "pnlMenuManager";
            this.pnlMenuManager.Size = new System.Drawing.Size(801, 686);
            this.pnlMenuManager.TabIndex = 22;
            // 
            // FormMenuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 686);
            this.Controls.Add(this.pnlMenuManager);
            this.Controls.Add(this.expMenuList);
            this.Name = "FormMenuManager";
            this.Text = "FormMenuManager";
            this.Load += new System.EventHandler(this.FormMenuManager_Load);
            this.expMenuList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ExpandablePanel expMenuList;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel pnlMenuManager;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMenuType;
    }
}