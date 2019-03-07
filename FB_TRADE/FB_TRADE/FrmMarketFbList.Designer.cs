namespace FB_TRADE
{
    partial class FrmMarketFbList
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("昵称");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("账号");
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnMarketFbAdd = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewMarketFbs = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnMarketFbAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(906, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(225, 24);
            this.toolStripLabel1.Text = "双击查看/编辑营销号详细资料。";
            // 
            // btnMarketFbAdd
            // 
            this.btnMarketFbAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMarketFbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMarketFbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarketFbAdd.Name = "btnMarketFbAdd";
            this.btnMarketFbAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMarketFbAdd.Size = new System.Drawing.Size(88, 24);
            this.btnMarketFbAdd.Text = "新增营销号";
            this.btnMarketFbAdd.Click += new System.EventHandler(this.btnMarketFbAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewMarketFbs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 494);
            this.panel1.TabIndex = 1;
            // 
            // listViewMarketFbs
            // 
            this.listViewMarketFbs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMarketFbs.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listViewMarketFbs.Location = new System.Drawing.Point(0, 0);
            this.listViewMarketFbs.Name = "listViewMarketFbs";
            this.listViewMarketFbs.Size = new System.Drawing.Size(906, 494);
            this.listViewMarketFbs.TabIndex = 0;
            this.listViewMarketFbs.UseCompatibleStateImageBehavior = false;
            // 
            // FrmMarketFbList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 521);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmMarketFbList";
            this.Text = "营销号列表";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnMarketFbAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewMarketFbs;
    }
}