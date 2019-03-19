namespace FB_TRADE
{
    partial class FrmTraceNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTraceNotify));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnCopyUrl = new System.Windows.Forms.ToolStripButton();
            this.labelNotifyInfo = new System.Windows.Forms.ToolStripLabel();
            this.labelTraceCount = new System.Windows.Forms.ToolStripLabel();
            this.listViewTrace = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpdate,
            this.btnCopyUrl,
            this.labelNotifyInfo,
            this.labelTraceCount});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1317, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(103, 24);
            this.btnUpdate.Text = "手动刷新数据";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCopyUrl
            // 
            this.btnCopyUrl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCopyUrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopyUrl.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyUrl.Image")));
            this.btnCopyUrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyUrl.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnCopyUrl.Name = "btnCopyUrl";
            this.btnCopyUrl.Size = new System.Drawing.Size(103, 24);
            this.btnCopyUrl.Text = "复制主页链接";
            this.btnCopyUrl.Click += new System.EventHandler(this.btnCopyUrl_Click);
            // 
            // labelNotifyInfo
            // 
            this.labelNotifyInfo.Name = "labelNotifyInfo";
            this.labelNotifyInfo.Size = new System.Drawing.Size(189, 24);
            this.labelNotifyInfo.Text = "目前需要跟踪的客户数为：";
            // 
            // labelTraceCount
            // 
            this.labelTraceCount.ForeColor = System.Drawing.Color.Red;
            this.labelTraceCount.Name = "labelTraceCount";
            this.labelTraceCount.Size = new System.Drawing.Size(18, 24);
            this.labelTraceCount.Text = "2";
            // 
            // listViewTrace
            // 
            this.listViewTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTrace.Location = new System.Drawing.Point(0, 27);
            this.listViewTrace.Name = "listViewTrace";
            this.listViewTrace.Size = new System.Drawing.Size(1317, 549);
            this.listViewTrace.TabIndex = 1;
            this.listViewTrace.UseCompatibleStateImageBehavior = false;
            // 
            // FrmTraceNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 576);
            this.Controls.Add(this.listViewTrace);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmTraceNotify";
            this.Text = "FrmTraceNotify";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripButton btnCopyUrl;
        private System.Windows.Forms.ToolStripLabel labelNotifyInfo;
        private System.Windows.Forms.ToolStripLabel labelTraceCount;
        private System.Windows.Forms.ListView listViewTrace;
    }
}