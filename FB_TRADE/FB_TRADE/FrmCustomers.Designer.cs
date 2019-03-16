namespace FB_TRADE
{
    partial class FrmCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomers));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnCopyUrl = new System.Windows.Forms.ToolStripButton();
            this.labelCurMarketFbInfo = new System.Windows.Forms.ToolStripLabel();
            this.panelList = new System.Windows.Forms.Panel();
            this.listViewCustomers = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.panelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete,
            this.btnAdd,
            this.btnCopyUrl,
            this.labelCurMarketFbInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1236, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDelete
            // 
            this.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(43, 24);
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 24);
            this.btnAdd.Text = "新增客户";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCopyUrl
            // 
            this.btnCopyUrl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCopyUrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopyUrl.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyUrl.Image")));
            this.btnCopyUrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyUrl.Name = "btnCopyUrl";
            this.btnCopyUrl.Size = new System.Drawing.Size(103, 24);
            this.btnCopyUrl.Text = "复制首页链接";
            this.btnCopyUrl.Click += new System.EventHandler(this.btnCopyUrl_Click);
            // 
            // labelCurMarketFbInfo
            // 
            this.labelCurMarketFbInfo.Name = "labelCurMarketFbInfo";
            this.labelCurMarketFbInfo.Size = new System.Drawing.Size(99, 24);
            this.labelCurMarketFbInfo.Text = "当前营销号：";
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.listViewCustomers);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 27);
            this.panelList.Margin = new System.Windows.Forms.Padding(4);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(1236, 501);
            this.panelList.TabIndex = 2;
            // 
            // listViewCustomers
            // 
            this.listViewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCustomers.Location = new System.Drawing.Point(0, 0);
            this.listViewCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.listViewCustomers.Name = "listViewCustomers";
            this.listViewCustomers.Size = new System.Drawing.Size(1236, 501);
            this.listViewCustomers.TabIndex = 0;
            this.listViewCustomers.UseCompatibleStateImageBehavior = false;
            // 
            // FrmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 528);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCustomers";
            this.Text = "客户管理";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.ListView listViewCustomers;
        private System.Windows.Forms.ToolStripButton btnCopyUrl;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripLabel labelCurMarketFbInfo;
    }
}