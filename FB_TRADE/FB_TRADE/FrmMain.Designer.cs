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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbxUser = new System.Windows.Forms.ToolStripComboBox();
            this.cbxFbAccount = new System.Windows.Forms.ToolStripComboBox();
            this.lblTools = new System.Windows.Forms.ToolStripLabel();
            this.btnSelfInfoChg = new System.Windows.Forms.ToolStripButton();
            this.btnUserList = new System.Windows.Forms.ToolStripButton();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.labelHello = new System.Windows.Forms.Label();
            this.btnOldCustomers = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnGroupControl = new System.Windows.Forms.Button();
            this.btnCustomerControl = new System.Windows.Forms.Button();
            this.btnCustomerNotify = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panelMenu.SuspendLayout();
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
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.Control;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.labelHello);
            this.panelMenu.Controls.Add(this.btnOldCustomers);
            this.panelMenu.Controls.Add(this.btnOrderList);
            this.panelMenu.Controls.Add(this.btnGroupControl);
            this.panelMenu.Controls.Add(this.btnCustomerControl);
            this.panelMenu.Controls.Add(this.btnCustomerNotify);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 28);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 509);
            this.panelMenu.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "营销号列表";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Location = new System.Drawing.Point(11, 11);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(31, 15);
            this.labelHello.TabIndex = 6;
            this.labelHello.Text = "Hi,";
            // 
            // btnOldCustomers
            // 
            this.btnOldCustomers.Location = new System.Drawing.Point(44, 320);
            this.btnOldCustomers.Name = "btnOldCustomers";
            this.btnOldCustomers.Size = new System.Drawing.Size(126, 30);
            this.btnOldCustomers.TabIndex = 5;
            this.btnOldCustomers.Text = "老客户营销";
            this.btnOldCustomers.UseVisualStyleBackColor = true;
            // 
            // btnOrderList
            // 
            this.btnOrderList.Location = new System.Drawing.Point(44, 268);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(126, 30);
            this.btnOrderList.TabIndex = 4;
            this.btnOrderList.Text = "订单列表";
            this.btnOrderList.UseVisualStyleBackColor = true;
            // 
            // btnGroupControl
            // 
            this.btnGroupControl.Location = new System.Drawing.Point(44, 217);
            this.btnGroupControl.Name = "btnGroupControl";
            this.btnGroupControl.Size = new System.Drawing.Size(126, 30);
            this.btnGroupControl.TabIndex = 3;
            this.btnGroupControl.Text = "群组管理";
            this.btnGroupControl.UseVisualStyleBackColor = true;
            // 
            // btnCustomerControl
            // 
            this.btnCustomerControl.Location = new System.Drawing.Point(44, 166);
            this.btnCustomerControl.Name = "btnCustomerControl";
            this.btnCustomerControl.Size = new System.Drawing.Size(126, 30);
            this.btnCustomerControl.TabIndex = 2;
            this.btnCustomerControl.Text = "客户管理";
            this.btnCustomerControl.UseVisualStyleBackColor = true;
            // 
            // btnCustomerNotify
            // 
            this.btnCustomerNotify.Location = new System.Drawing.Point(44, 117);
            this.btnCustomerNotify.Name = "btnCustomerNotify";
            this.btnCustomerNotify.Size = new System.Drawing.Size(126, 30);
            this.btnCustomerNotify.TabIndex = 1;
            this.btnCustomerNotify.Text = "客户跟踪提醒";
            this.btnCustomerNotify.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 28);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1046, 509);
            this.panelContent.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 537);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbxFbAccount;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnOldCustomers;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnGroupControl;
        private System.Windows.Forms.Button btnCustomerControl;
        private System.Windows.Forms.Button btnCustomerNotify;
        private System.Windows.Forms.ToolStripButton btnSelfInfoChg;
        private System.Windows.Forms.ToolStripComboBox cbxUser;
        private System.Windows.Forms.ToolStripLabel lblTools;
        private System.Windows.Forms.Label labelHello;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton btnUserList;
    }
}