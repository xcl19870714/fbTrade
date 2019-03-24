namespace FB_TRADE
{
    partial class FrmGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroups));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.labelCurMarketFbInfo = new System.Windows.Forms.ToolStripLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbJoin = new System.Windows.Forms.CheckBox();
            this.ckbAccept = new System.Windows.Forms.CheckBox();
            this.ckbReject = new System.Windows.Forms.CheckBox();
            this.cbxTweeting = new System.Windows.Forms.CheckBox();
            this.cbxQuit = new System.Windows.Forms.CheckBox();
            this.ckbAbbandon = new System.Windows.Forms.CheckBox();
            this.cbxIm = new System.Windows.Forms.CheckBox();
            this.cbxNormal = new System.Windows.Forms.CheckBox();
            this.cbxCheated = new System.Windows.Forms.CheckBox();
            this.ckbAttacked = new System.Windows.Forms.CheckBox();
            this.cbxLocalTrade = new System.Windows.Forms.CheckBox();
            this.cbxUnTrust = new System.Windows.Forms.CheckBox();
            this.cbxOnSale = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.txtFilterWords = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete,
            this.btnAdd,
            this.btnCopy,
            this.toolStripLabel1,
            this.labelCurMarketFbInfo,
            this.btnUpdate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1071, 27);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnAdd.Text = "新增群组";
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
            this.btnCopy.Text = "复制首页链接";
            this.btnCopy.Click += new System.EventHandler(this.btnCopyUrl_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewGroups);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1071, 396);
            this.panel2.TabIndex = 2;
            // 
            // listViewGroups
            // 
            this.listViewGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGroups.Location = new System.Drawing.Point(0, 0);
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(1071, 396);
            this.listViewGroups.TabIndex = 0;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "状态包含：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "标记包含：";
            // 
            // ckbJoin
            // 
            this.ckbJoin.AutoSize = true;
            this.ckbJoin.Location = new System.Drawing.Point(92, 49);
            this.ckbJoin.Name = "ckbJoin";
            this.ckbJoin.Size = new System.Drawing.Size(89, 19);
            this.ckbJoin.TabIndex = 8;
            this.ckbJoin.Text = "申请加入";
            this.ckbJoin.UseVisualStyleBackColor = true;
            // 
            // ckbAccept
            // 
            this.ckbAccept.AutoSize = true;
            this.ckbAccept.Location = new System.Drawing.Point(197, 49);
            this.ckbAccept.Name = "ckbAccept";
            this.ckbAccept.Size = new System.Drawing.Size(89, 19);
            this.ckbAccept.TabIndex = 9;
            this.ckbAccept.Text = "申请通过";
            this.ckbAccept.UseVisualStyleBackColor = true;
            // 
            // ckbReject
            // 
            this.ckbReject.AutoSize = true;
            this.ckbReject.Location = new System.Drawing.Point(307, 49);
            this.ckbReject.Name = "ckbReject";
            this.ckbReject.Size = new System.Drawing.Size(89, 19);
            this.ckbReject.TabIndex = 10;
            this.ckbReject.Text = "申请被拒";
            this.ckbReject.UseVisualStyleBackColor = true;
            // 
            // cbxTweeting
            // 
            this.cbxTweeting.AutoSize = true;
            this.cbxTweeting.Location = new System.Drawing.Point(422, 49);
            this.cbxTweeting.Name = "cbxTweeting";
            this.cbxTweeting.Size = new System.Drawing.Size(89, 19);
            this.cbxTweeting.TabIndex = 11;
            this.cbxTweeting.Text = "发贴状态";
            this.cbxTweeting.UseVisualStyleBackColor = true;
            // 
            // cbxQuit
            // 
            this.cbxQuit.AutoSize = true;
            this.cbxQuit.Location = new System.Drawing.Point(528, 49);
            this.cbxQuit.Name = "cbxQuit";
            this.cbxQuit.Size = new System.Drawing.Size(89, 19);
            this.cbxQuit.TabIndex = 12;
            this.cbxQuit.Text = "退出群组";
            this.cbxQuit.UseVisualStyleBackColor = true;
            // 
            // ckbAbbandon
            // 
            this.ckbAbbandon.AutoSize = true;
            this.ckbAbbandon.Location = new System.Drawing.Point(638, 49);
            this.ckbAbbandon.Name = "ckbAbbandon";
            this.ckbAbbandon.Size = new System.Drawing.Size(59, 19);
            this.ckbAbbandon.TabIndex = 13;
            this.ckbAbbandon.Text = "不要";
            this.ckbAbbandon.UseVisualStyleBackColor = true;
            // 
            // cbxIm
            // 
            this.cbxIm.AutoSize = true;
            this.cbxIm.Location = new System.Drawing.Point(92, 80);
            this.cbxIm.Name = "cbxIm";
            this.cbxIm.Size = new System.Drawing.Size(59, 19);
            this.cbxIm.TabIndex = 15;
            this.cbxIm.Text = "重要";
            this.cbxIm.UseVisualStyleBackColor = true;
            // 
            // cbxNormal
            // 
            this.cbxNormal.AutoSize = true;
            this.cbxNormal.Location = new System.Drawing.Point(157, 79);
            this.cbxNormal.Name = "cbxNormal";
            this.cbxNormal.Size = new System.Drawing.Size(59, 19);
            this.cbxNormal.TabIndex = 16;
            this.cbxNormal.Text = "一般";
            this.cbxNormal.UseVisualStyleBackColor = true;
            // 
            // cbxCheated
            // 
            this.cbxCheated.AutoSize = true;
            this.cbxCheated.Location = new System.Drawing.Point(227, 80);
            this.cbxCheated.Name = "cbxCheated";
            this.cbxCheated.Size = new System.Drawing.Size(104, 19);
            this.cbxCheated.TabIndex = 17;
            this.cbxCheated.Text = "认为是骗子";
            this.cbxCheated.UseVisualStyleBackColor = true;
            // 
            // ckbAttacked
            // 
            this.ckbAttacked.AutoSize = true;
            this.ckbAttacked.Location = new System.Drawing.Point(337, 80);
            this.ckbAttacked.Name = "ckbAttacked";
            this.ckbAttacked.Size = new System.Drawing.Size(74, 19);
            this.ckbAttacked.TabIndex = 18;
            this.ckbAttacked.Text = "被攻击";
            this.ckbAttacked.UseVisualStyleBackColor = true;
            // 
            // cbxLocalTrade
            // 
            this.cbxLocalTrade.AutoSize = true;
            this.cbxLocalTrade.Location = new System.Drawing.Point(423, 79);
            this.cbxLocalTrade.Name = "cbxLocalTrade";
            this.cbxLocalTrade.Size = new System.Drawing.Size(104, 19);
            this.cbxLocalTrade.TabIndex = 19;
            this.cbxLocalTrade.Text = "想当地交易";
            this.cbxLocalTrade.UseVisualStyleBackColor = true;
            // 
            // cbxUnTrust
            // 
            this.cbxUnTrust.AutoSize = true;
            this.cbxUnTrust.Location = new System.Drawing.Point(543, 79);
            this.cbxUnTrust.Name = "cbxUnTrust";
            this.cbxUnTrust.Size = new System.Drawing.Size(74, 19);
            this.cbxUnTrust.TabIndex = 20;
            this.cbxUnTrust.Text = "不信任";
            this.cbxUnTrust.UseVisualStyleBackColor = true;
            // 
            // cbxOnSale
            // 
            this.cbxOnSale.AutoSize = true;
            this.cbxOnSale.Location = new System.Drawing.Point(623, 79);
            this.cbxOnSale.Name = "cbxOnSale";
            this.cbxOnSale.Size = new System.Drawing.Size(74, 19);
            this.cbxOnSale.TabIndex = 21;
            this.cbxOnSale.Text = "做活动";
            this.cbxOnSale.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 26;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.cbxIm);
            this.panel1.Controls.Add(this.ckbJoin);
            this.panel1.Controls.Add(this.dateTimePickerBegin);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dateTimePickerEnd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtFilterWords);
            this.panel1.Controls.Add(this.txtKeyWords);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbxOnSale);
            this.panel1.Controls.Add(this.cbxUnTrust);
            this.panel1.Controls.Add(this.cbxLocalTrade);
            this.panel1.Controls.Add(this.ckbAttacked);
            this.panel1.Controls.Add(this.cbxCheated);
            this.panel1.Controls.Add(this.cbxNormal);
            this.panel1.Controls.Add(this.ckbAbbandon);
            this.panel1.Controls.Add(this.cbxQuit);
            this.panel1.Controls.Add(this.cbxTweeting);
            this.panel1.Controls.Add(this.ckbReject);
            this.panel1.Controls.Add(this.ckbAccept);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 150);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "关键词：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "不含：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(92, 14);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(216, 25);
            this.txtKeyWords.TabIndex = 1;
            // 
            // txtFilterWords
            // 
            this.txtFilterWords.Location = new System.Drawing.Point(374, 14);
            this.txtFilterWords.Name = "txtFilterWords";
            this.txtFilterWords.Size = new System.Drawing.Size(216, 25);
            this.txtFilterWords.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "至";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "更新日期：";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(251, 112);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(136, 25);
            this.dateTimePickerEnd.TabIndex = 25;
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Location = new System.Drawing.Point(90, 111);
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size(136, 25);
            this.dateTimePickerBegin.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(593, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(415, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "（关键词或过滤词支持：群组ID/名称/首页链接/简介/备注）";
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
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // FrmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmGroups";
            this.Text = "FrmGroups";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripLabel labelCurMarketFbInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbJoin;
        private System.Windows.Forms.CheckBox ckbAccept;
        private System.Windows.Forms.CheckBox ckbReject;
        private System.Windows.Forms.CheckBox cbxTweeting;
        private System.Windows.Forms.CheckBox cbxQuit;
        private System.Windows.Forms.CheckBox ckbAbbandon;
        private System.Windows.Forms.CheckBox cbxIm;
        private System.Windows.Forms.CheckBox cbxNormal;
        private System.Windows.Forms.CheckBox cbxCheated;
        private System.Windows.Forms.CheckBox ckbAttacked;
        private System.Windows.Forms.CheckBox cbxLocalTrade;
        private System.Windows.Forms.CheckBox cbxUnTrust;
        private System.Windows.Forms.CheckBox cbxOnSale;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox txtFilterWords;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton btnUpdate;
    }
}