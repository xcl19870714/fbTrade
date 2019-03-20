namespace FB_TRADE
{
    partial class FrmCustomerSearchTool
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.labelCurMarketFbInfo = new System.Windows.Forms.Label();
            this.labelCurMarketAccount = new System.Windows.Forms.Label();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCurMarketAccount);
            this.panel1.Controls.Add(this.labelCurMarketFbInfo);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cbxSearchType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 94);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "搜索类型：";
            // 
            // cbxSearchType
            // 
            this.cbxSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchType.FormattingEnabled = true;
            this.cbxSearchType.Location = new System.Drawing.Point(99, 16);
            this.cbxSearchType.Name = "cbxSearchType";
            this.cbxSearchType.Size = new System.Drawing.Size(177, 23);
            this.cbxSearchType.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 56);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(733, 25);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(673, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelCurMarketFbInfo
            // 
            this.labelCurMarketFbInfo.AutoSize = true;
            this.labelCurMarketFbInfo.Location = new System.Drawing.Point(454, 21);
            this.labelCurMarketFbInfo.Name = "labelCurMarketFbInfo";
            this.labelCurMarketFbInfo.Size = new System.Drawing.Size(97, 15);
            this.labelCurMarketFbInfo.TabIndex = 4;
            this.labelCurMarketFbInfo.Text = "当前营销号：";
            // 
            // labelCurMarketAccount
            // 
            this.labelCurMarketAccount.AutoSize = true;
            this.labelCurMarketAccount.ForeColor = System.Drawing.Color.Red;
            this.labelCurMarketAccount.Location = new System.Drawing.Point(550, 19);
            this.labelCurMarketAccount.Name = "labelCurMarketAccount";
            this.labelCurMarketAccount.Size = new System.Drawing.Size(95, 15);
            this.labelCurMarketAccount.TabIndex = 5;
            this.labelCurMarketAccount.Text = "xuchenglong";
            // 
            // listViewResult
            // 
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.Location = new System.Drawing.Point(0, 94);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(760, 528);
            this.listViewResult.TabIndex = 1;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 597);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(760, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(507, 20);
            this.toolStripStatusLabel1.Text = "在搜索结果中双击条目可直接定位到该客户。（只显示搜索结果的前30位）";
            // 
            // FrmCustomerSearchTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 622);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listViewResult);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCustomerSearchTool";
            this.Text = "搜索小工具";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbxSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurMarketAccount;
        private System.Windows.Forms.Label labelCurMarketFbInfo;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}