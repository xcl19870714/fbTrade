namespace FB_TRADE
{
    partial class FrmOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrders));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnAbbandon = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.labelCurMarketFbInfo = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbSelfDel = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckbAdminDel = new System.Windows.Forms.CheckBox();
            this.ckbShiped = new System.Windows.Forms.CheckBox();
            this.ckbNotShip = new System.Windows.Forms.CheckBox();
            this.ckbPriceNotConfirm = new System.Windows.Forms.CheckBox();
            this.ckbSave = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewOrders = new System.Windows.Forms.ListView();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnOrderCopy = new System.Windows.Forms.ToolStripButton();
            this.btnOrderAfterSale = new System.Windows.Forms.ToolStripButton();
            this.btnOrderDivide = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilterWords = new System.Windows.Forms.TextBox();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete,
            this.btnAbbandon,
            this.btnOrderDivide,
            this.btnOrderAfterSale,
            this.btnOrderCopy,
            this.btnAdd,
            this.btnCopy,
            this.toolStripLabel1,
            this.labelCurMarketFbInfo,
            this.btnUpdate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1318, 27);
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
            this.btnDelete.ToolTipText = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAbbandon
            // 
            this.btnAbbandon.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAbbandon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAbbandon.Image = ((System.Drawing.Image)(resources.GetObject("btnAbbandon.Image")));
            this.btnAbbandon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbbandon.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnAbbandon.Name = "btnAbbandon";
            this.btnAbbandon.Size = new System.Drawing.Size(43, 24);
            this.btnAbbandon.Text = "废弃";
            this.btnAbbandon.Click += new System.EventHandler(this.btnAbbandon_Click);
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
            this.btnAdd.Text = "新建订单";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(103, 24);
            this.btnCopy.Text = "复制订单编号";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(99, 24);
            this.toolStripLabel1.Text = "当前营销号：";
            // 
            // labelCurMarketFbInfo
            // 
            this.labelCurMarketFbInfo.ForeColor = System.Drawing.Color.Red;
            this.labelCurMarketFbInfo.Name = "labelCurMarketFbInfo";
            this.labelCurMarketFbInfo.Size = new System.Drawing.Size(99, 24);
            this.labelCurMarketFbInfo.Text = "当前营销号：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.ckbSave);
            this.panel1.Controls.Add(this.dateTimePickerBegin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtFilterWords);
            this.panel1.Controls.Add(this.txtKeyWords);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ckbSelfDel);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ckbAdminDel);
            this.panel1.Controls.Add(this.ckbShiped);
            this.panel1.Controls.Add(this.ckbNotShip);
            this.panel1.Controls.Add(this.ckbPriceNotConfirm);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePickerEnd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 124);
            this.panel1.TabIndex = 0;
            // 
            // ckbSelfDel
            // 
            this.ckbSelfDel.AutoSize = true;
            this.ckbSelfDel.Location = new System.Drawing.Point(610, 53);
            this.ckbSelfDel.Name = "ckbSelfDel";
            this.ckbSelfDel.Size = new System.Drawing.Size(104, 19);
            this.ckbSelfDel.TabIndex = 12;
            this.ckbSelfDel.Text = "自己删除单";
            this.ckbSelfDel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(424, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 33);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ckbAdminDel
            // 
            this.ckbAdminDel.AutoSize = true;
            this.ckbAdminDel.Location = new System.Drawing.Point(476, 52);
            this.ckbAdminDel.Name = "ckbAdminDel";
            this.ckbAdminDel.Size = new System.Drawing.Size(119, 19);
            this.ckbAdminDel.TabIndex = 11;
            this.ckbAdminDel.Text = "管理员废弃单";
            this.ckbAdminDel.UseVisualStyleBackColor = true;
            // 
            // ckbShiped
            // 
            this.ckbShiped.AutoSize = true;
            this.ckbShiped.Location = new System.Drawing.Point(387, 52);
            this.ckbShiped.Name = "ckbShiped";
            this.ckbShiped.Size = new System.Drawing.Size(74, 19);
            this.ckbShiped.TabIndex = 10;
            this.ckbShiped.Text = "已发货";
            this.ckbShiped.UseVisualStyleBackColor = true;
            // 
            // ckbNotShip
            // 
            this.ckbNotShip.AutoSize = true;
            this.ckbNotShip.Location = new System.Drawing.Point(300, 52);
            this.ckbNotShip.Name = "ckbNotShip";
            this.ckbNotShip.Size = new System.Drawing.Size(74, 19);
            this.ckbNotShip.TabIndex = 9;
            this.ckbNotShip.Text = "未发货";
            this.ckbNotShip.UseVisualStyleBackColor = true;
            // 
            // ckbPriceNotConfirm
            // 
            this.ckbPriceNotConfirm.AutoSize = true;
            this.ckbPriceNotConfirm.Location = new System.Drawing.Point(181, 52);
            this.ckbPriceNotConfirm.Name = "ckbPriceNotConfirm";
            this.ckbPriceNotConfirm.Size = new System.Drawing.Size(104, 19);
            this.ckbPriceNotConfirm.TabIndex = 8;
            this.ckbPriceNotConfirm.Text = "未确认金额";
            this.ckbPriceNotConfirm.UseVisualStyleBackColor = true;
            // 
            // ckbSave
            // 
            this.ckbSave.AutoSize = true;
            this.ckbSave.Location = new System.Drawing.Point(93, 52);
            this.ckbSave.Name = "ckbSave";
            this.ckbSave.Size = new System.Drawing.Size(74, 19);
            this.ckbSave.TabIndex = 7;
            this.ckbSave.Text = "未提交";
            this.ckbSave.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "订单状态：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "更新日期：";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(254, 85);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(136, 25);
            this.dateTimePickerEnd.TabIndex = 16;
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Location = new System.Drawing.Point(91, 85);
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size(136, 25);
            this.dateTimePickerBegin.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewOrders);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1318, 411);
            this.panel2.TabIndex = 2;
            // 
            // listViewOrders
            // 
            this.listViewOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOrders.Location = new System.Drawing.Point(0, 0);
            this.listViewOrders.Margin = new System.Windows.Forms.Padding(4);
            this.listViewOrders.Name = "listViewOrders";
            this.listViewOrders.Size = new System.Drawing.Size(1318, 411);
            this.listViewOrders.TabIndex = 0;
            this.listViewOrders.UseCompatibleStateImageBehavior = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(103, 24);
            this.btnUpdate.Text = "手动刷新数据";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnOrderCopy
            // 
            this.btnOrderCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOrderCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOrderCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderCopy.Image")));
            this.btnOrderCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderCopy.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnOrderCopy.Name = "btnOrderCopy";
            this.btnOrderCopy.Size = new System.Drawing.Size(73, 24);
            this.btnOrderCopy.Text = "复制订单";
            this.btnOrderCopy.Click += new System.EventHandler(this.btnOrderCopy_Click);
            // 
            // btnOrderAfterSale
            // 
            this.btnOrderAfterSale.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOrderAfterSale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOrderAfterSale.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderAfterSale.Image")));
            this.btnOrderAfterSale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderAfterSale.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnOrderAfterSale.Name = "btnOrderAfterSale";
            this.btnOrderAfterSale.Size = new System.Drawing.Size(73, 24);
            this.btnOrderAfterSale.Text = "新建售后";
            this.btnOrderAfterSale.Click += new System.EventHandler(this.btnOrderAfterSale_Click);
            // 
            // btnOrderDivide
            // 
            this.btnOrderDivide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOrderDivide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOrderDivide.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderDivide.Image")));
            this.btnOrderDivide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderDivide.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.btnOrderDivide.Name = "btnOrderDivide";
            this.btnOrderDivide.Size = new System.Drawing.Size(73, 24);
            this.btnOrderDivide.Text = "新建分期";
            this.btnOrderDivide.Click += new System.EventHandler(this.btnOrderDivide_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(602, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "（关键词或过滤词支持：订单号/原始订单号/客户编号/客户姓名/订单备注/包含商品名）";
            // 
            // txtFilterWords
            // 
            this.txtFilterWords.Location = new System.Drawing.Point(382, 12);
            this.txtFilterWords.Name = "txtFilterWords";
            this.txtFilterWords.Size = new System.Drawing.Size(216, 25);
            this.txtFilterWords.TabIndex = 21;
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(91, 12);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(216, 25);
            this.txtKeyWords.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "不含：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "关键词：";
            // 
            // FrmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmOrders";
            this.Text = "FrmOrders";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewOrders;
        private System.Windows.Forms.CheckBox ckbAdminDel;
        private System.Windows.Forms.CheckBox ckbShiped;
        private System.Windows.Forms.CheckBox ckbNotShip;
        private System.Windows.Forms.CheckBox ckbPriceNotConfirm;
        private System.Windows.Forms.CheckBox ckbSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripLabel labelCurMarketFbInfo;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.CheckBox ckbSelfDel;
        private System.Windows.Forms.ToolStripButton btnAbbandon;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripButton btnOrderDivide;
        private System.Windows.Forms.ToolStripButton btnOrderAfterSale;
        private System.Windows.Forms.ToolStripButton btnOrderCopy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilterWords;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}