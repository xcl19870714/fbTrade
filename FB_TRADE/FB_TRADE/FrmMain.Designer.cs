namespace FB_TRADE
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbxUser = new System.Windows.Forms.ToolStripComboBox();
            this.cbxFbAccount = new System.Windows.Forms.ToolStripComboBox();
            this.lblTools = new System.Windows.Forms.ToolStripLabel();
            this.btnSelfInfoChg = new System.Windows.Forms.ToolStripButton();
            this.btnUserList = new System.Windows.Forms.ToolStripButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnFbAccountList = new System.Windows.Forms.Button();
            this.labelHello = new System.Windows.Forms.Label();
            this.btnOldCustomers = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnGroupControl = new System.Windows.Forms.Button();
            this.btnCustomerControl = new System.Windows.Forms.Button();
            this.btnCustomerNotify = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbxUser,
            this.cbxFbAccount,
            this.lblTools,
            this.btnSelfInfoChg,
            this.btnUserList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1266, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.MaxDropDownItems = 100;
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(100, 28);
            this.cbxUser.Sorted = true;
            // 
            // cbxFbAccount
            // 
            this.cbxFbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFbAccount.MaxDropDownItems = 100;
            this.cbxFbAccount.Name = "cbxFbAccount";
            this.cbxFbAccount.Size = new System.Drawing.Size(100, 28);
            this.cbxFbAccount.Sorted = true;
            // 
            // lblTools
            // 
            this.lblTools.Name = "lblTools";
            this.lblTools.Size = new System.Drawing.Size(43, 25);
            this.lblTools.Text = "工具:";
            // 
            // btnSelfInfoChg
            // 
            this.btnSelfInfoChg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSelfInfoChg.Image = ((System.Drawing.Image)(resources.GetObject("btnSelfInfoChg.Image")));
            this.btnSelfInfoChg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelfInfoChg.Name = "btnSelfInfoChg";
            this.btnSelfInfoChg.Size = new System.Drawing.Size(137, 25);
            this.btnSelfInfoChg.Text = " 【个人信息修改】";
            this.btnSelfInfoChg.Click += new System.EventHandler(this.btnSelfInfoChg_Click);
            // 
            // btnUserList
            // 
            this.btnUserList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUserList.Image = ((System.Drawing.Image)(resources.GetObject("btnUserList.Image")));
            this.btnUserList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(122, 25);
            this.btnUserList.Text = " 【子账号管理】";
            this.btnUserList.Click += new System.EventHandler(this.btnUserList_Click);
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.splitContainer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 28);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1266, 509);
            this.panelMain.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnFbAccountList);
            this.splitContainer1.Panel1.Controls.Add(this.labelHello);
            this.splitContainer1.Panel1.Controls.Add(this.btnOldCustomers);
            this.splitContainer1.Panel1.Controls.Add(this.btnOrderList);
            this.splitContainer1.Panel1.Controls.Add(this.btnGroupControl);
            this.splitContainer1.Panel1.Controls.Add(this.btnCustomerControl);
            this.splitContainer1.Panel1.Controls.Add(this.btnCustomerNotify);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 507);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // btnFbAccountList
            // 
            this.btnFbAccountList.Location = new System.Drawing.Point(17, 50);
            this.btnFbAccountList.Name = "btnFbAccountList";
            this.btnFbAccountList.Size = new System.Drawing.Size(126, 30);
            this.btnFbAccountList.TabIndex = 28;
            this.btnFbAccountList.Text = "营销号列表";
            this.btnFbAccountList.UseVisualStyleBackColor = true;
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Location = new System.Drawing.Point(4, 10);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(31, 15);
            this.labelHello.TabIndex = 27;
            this.labelHello.Text = "Hi,";
            // 
            // btnOldCustomers
            // 
            this.btnOldCustomers.Location = new System.Drawing.Point(17, 304);
            this.btnOldCustomers.Name = "btnOldCustomers";
            this.btnOldCustomers.Size = new System.Drawing.Size(126, 30);
            this.btnOldCustomers.TabIndex = 26;
            this.btnOldCustomers.Text = "老客户营销";
            this.btnOldCustomers.UseVisualStyleBackColor = true;
            // 
            // btnOrderList
            // 
            this.btnOrderList.Location = new System.Drawing.Point(17, 252);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(126, 30);
            this.btnOrderList.TabIndex = 25;
            this.btnOrderList.Text = "订单列表";
            this.btnOrderList.UseVisualStyleBackColor = true;
            // 
            // btnGroupControl
            // 
            this.btnGroupControl.Location = new System.Drawing.Point(17, 201);
            this.btnGroupControl.Name = "btnGroupControl";
            this.btnGroupControl.Size = new System.Drawing.Size(126, 30);
            this.btnGroupControl.TabIndex = 24;
            this.btnGroupControl.Text = "群组管理";
            this.btnGroupControl.UseVisualStyleBackColor = true;
            // 
            // btnCustomerControl
            // 
            this.btnCustomerControl.Location = new System.Drawing.Point(17, 150);
            this.btnCustomerControl.Name = "btnCustomerControl";
            this.btnCustomerControl.Size = new System.Drawing.Size(126, 30);
            this.btnCustomerControl.TabIndex = 23;
            this.btnCustomerControl.Text = "客户管理";
            this.btnCustomerControl.UseVisualStyleBackColor = true;
            // 
            // btnCustomerNotify
            // 
            this.btnCustomerNotify.Location = new System.Drawing.Point(17, 101);
            this.btnCustomerNotify.Name = "btnCustomerNotify";
            this.btnCustomerNotify.Size = new System.Drawing.Size(126, 30);
            this.btnCustomerNotify.TabIndex = 22;
            this.btnCustomerNotify.Text = "客户跟踪提醒";
            this.btnCustomerNotify.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMain.HotTrack = true;
            this.tabControlMain.ItemSize = new System.Drawing.Size(76, 21);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1098, 505);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1090, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1090, 476);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 537);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbxFbAccount;
        private System.Windows.Forms.ToolStripButton btnSelfInfoChg;
        private System.Windows.Forms.ToolStripComboBox cbxUser;
        private System.Windows.Forms.ToolStripLabel lblTools;
        private System.Windows.Forms.ToolStripButton btnUserList;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnFbAccountList;
        private System.Windows.Forms.Label labelHello;
        private System.Windows.Forms.Button btnOldCustomers;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnGroupControl;
        private System.Windows.Forms.Button btnCustomerControl;
        private System.Windows.Forms.Button btnCustomerNotify;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}