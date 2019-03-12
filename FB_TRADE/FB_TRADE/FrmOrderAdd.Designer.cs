namespace FB_TRADE
{
    partial class FrmOrderAdd
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
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelCurMarketAccount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOriOrderId = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxOrderType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPayType = new System.Windows.Forms.ComboBox();
            this.txtPayNo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cbxCurrency = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtShipFee = new System.Windows.Forms.TextBox();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.listViewGoods = new System.Windows.Forms.ListView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkbSetDefaultAddress = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtShippingPhone = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtShippingName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.btnOrderDel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelGoods = new System.Windows.Forms.Button();
            this.btnInsertGoods = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbxShipType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShipType = new System.Windows.Forms.TextBox();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtPayType = new System.Windows.Forms.TextBox();
            this.labelOrderStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCustomerName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCustomerId);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 56);
            this.panel1.TabIndex = 0;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(349, 21);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(149, 25);
            this.txtCustomerName.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "昵称：";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Enabled = false;
            this.txtCustomerId.Location = new System.Drawing.Point(110, 21);
            this.txtCustomerId.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(149, 25);
            this.txtCustomerId.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelCurMarketAccount,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1162, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelCurMarketAccount
            // 
            this.labelCurMarketAccount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelCurMarketAccount.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.labelCurMarketAccount.Name = "labelCurMarketAccount";
            this.labelCurMarketAccount.Size = new System.Drawing.Size(104, 22);
            this.labelCurMarketAccount.Text = "xuchenglong";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel1.Text = "当前营销号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "客户编号：";
            // 
            // txtOriOrderId
            // 
            this.txtOriOrderId.Enabled = false;
            this.txtOriOrderId.Location = new System.Drawing.Point(685, 14);
            this.txtOriOrderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOriOrderId.Name = "txtOriOrderId";
            this.txtOriOrderId.Size = new System.Drawing.Size(204, 25);
            this.txtOriOrderId.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(594, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "原始单号：";
            // 
            // cbxOrderType
            // 
            this.cbxOrderType.FormattingEnabled = true;
            this.cbxOrderType.Location = new System.Drawing.Point(451, 16);
            this.cbxOrderType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxOrderType.Name = "cbxOrderType";
            this.cbxOrderType.Size = new System.Drawing.Size(105, 23);
            this.cbxOrderType.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(373, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "订单类型：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(254, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "（系统生成）";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Enabled = false;
            this.txtOrderId.Location = new System.Drawing.Point(113, 17);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.ReadOnly = true;
            this.txtOrderId.Size = new System.Drawing.Size(147, 25);
            this.txtOrderId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单编号：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtOriOrderId);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbxOrderType);
            this.panel2.Controls.Add(this.txtOrderId);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 52);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtPayType);
            this.panel4.Controls.Add(this.txtCurrency);
            this.panel4.Controls.Add(this.txtShipType);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cbxPayType);
            this.panel4.Controls.Add(this.txtPayNo);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.cbxCurrency);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.txtPayAmount);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.txtShipFee);
            this.panel4.Controls.Add(this.txtTrackingNo);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.cbxShipType);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.listViewGoods);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 108);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1164, 271);
            this.panel4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "商品信息：";
            // 
            // cbxPayType
            // 
            this.cbxPayType.FormattingEnabled = true;
            this.cbxPayType.Location = new System.Drawing.Point(444, 234);
            this.cbxPayType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPayType.Name = "cbxPayType";
            this.cbxPayType.Size = new System.Drawing.Size(68, 23);
            this.cbxPayType.TabIndex = 23;
            this.cbxPayType.SelectedIndexChanged += new System.EventHandler(this.cbxPayType_SelectedIndexChanged);
            // 
            // txtPayNo
            // 
            this.txtPayNo.Enabled = false;
            this.txtPayNo.Location = new System.Drawing.Point(828, 229);
            this.txtPayNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPayNo.Name = "txtPayNo";
            this.txtPayNo.Size = new System.Drawing.Size(204, 25);
            this.txtPayNo.TabIndex = 22;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(697, 237);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(102, 15);
            this.label23.TabIndex = 21;
            this.label23.Text = "Payment No：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(301, 237);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(142, 15);
            this.label24.TabIndex = 19;
            this.label24.Text = "Type Of Payment：";
            // 
            // cbxCurrency
            // 
            this.cbxCurrency.FormattingEnabled = true;
            this.cbxCurrency.Location = new System.Drawing.Point(160, 231);
            this.cbxCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCurrency.Name = "cbxCurrency";
            this.cbxCurrency.Size = new System.Drawing.Size(52, 23);
            this.cbxCurrency.TabIndex = 18;
            this.cbxCurrency.SelectedIndexChanged += new System.EventHandler(this.cbxCurrency_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(34, 235);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(86, 15);
            this.label25.TabIndex = 17;
            this.label25.Text = "Currency：";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Enabled = false;
            this.txtPayAmount.Location = new System.Drawing.Point(828, 193);
            this.txtPayAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(204, 25);
            this.txtPayAmount.TabIndex = 16;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(697, 201);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(134, 15);
            this.label22.TabIndex = 15;
            this.label22.Text = "Payment Amount：";
            // 
            // txtShipFee
            // 
            this.txtShipFee.Enabled = false;
            this.txtShipFee.Location = new System.Drawing.Point(350, 196);
            this.txtShipFee.Margin = new System.Windows.Forms.Padding(4);
            this.txtShipFee.Name = "txtShipFee";
            this.txtShipFee.Size = new System.Drawing.Size(83, 25);
            this.txtShipFee.TabIndex = 14;
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.Enabled = false;
            this.txtTrackingNo.Location = new System.Drawing.Point(552, 196);
            this.txtTrackingNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(133, 25);
            this.txtTrackingNo.TabIndex = 13;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(450, 200);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 15);
            this.label20.TabIndex = 12;
            this.label20.Text = "Tracking No：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(34, 199);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 15);
            this.label21.TabIndex = 10;
            this.label21.Text = "Shipping Type：";
            // 
            // listViewGoods
            // 
            this.listViewGoods.Location = new System.Drawing.Point(37, 42);
            this.listViewGoods.Margin = new System.Windows.Forms.Padding(4);
            this.listViewGoods.Name = "listViewGoods";
            this.listViewGoods.Size = new System.Drawing.Size(995, 138);
            this.listViewGoods.TabIndex = 0;
            this.listViewGoods.UseCompatibleStateImageBehavior = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkbSetDefaultAddress);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.txtShippingAddress);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.txtShippingPhone);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.txtShippingName);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 379);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1164, 154);
            this.panel5.TabIndex = 4;
            // 
            // chkbSetDefaultAddress
            // 
            this.chkbSetDefaultAddress.AutoSize = true;
            this.chkbSetDefaultAddress.Location = new System.Drawing.Point(37, 132);
            this.chkbSetDefaultAddress.Name = "chkbSetDefaultAddress";
            this.chkbSetDefaultAddress.Size = new System.Drawing.Size(194, 19);
            this.chkbSetDefaultAddress.TabIndex = 23;
            this.chkbSetDefaultAddress.Text = "设为此客户默认收货地址";
            this.chkbSetDefaultAddress.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 12);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(199, 15);
            this.label19.TabIndex = 22;
            this.label19.Text = "THE SHIPPING INFORMATION";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Enabled = false;
            this.txtShippingAddress.Location = new System.Drawing.Point(120, 71);
            this.txtShippingAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(907, 56);
            this.txtShippingAddress.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 88);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "ADDRESS：";
            // 
            // txtShippingPhone
            // 
            this.txtShippingPhone.Enabled = false;
            this.txtShippingPhone.Location = new System.Drawing.Point(585, 38);
            this.txtShippingPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtShippingPhone.Name = "txtShippingPhone";
            this.txtShippingPhone.Size = new System.Drawing.Size(441, 25);
            this.txtShippingPhone.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(501, 41);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 15);
            this.label17.TabIndex = 18;
            this.label17.Text = "PHONE NO：";
            // 
            // txtShippingName
            // 
            this.txtShippingName.Enabled = false;
            this.txtShippingName.Location = new System.Drawing.Point(120, 38);
            this.txtShippingName.Margin = new System.Windows.Forms.Padding(4);
            this.txtShippingName.Name = "txtShippingName";
            this.txtShippingName.Size = new System.Drawing.Size(360, 25);
            this.txtShippingName.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(33, 41);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 15);
            this.label18.TabIndex = 16;
            this.label18.Text = "NAME：";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelOrderStatus);
            this.panel6.Controls.Add(this.label28);
            this.panel6.Controls.Add(this.btnOrderDel);
            this.panel6.Controls.Add(this.btnSubmit);
            this.panel6.Controls.Add(this.btnSave);
            this.panel6.Controls.Add(this.btnDelGoods);
            this.panel6.Controls.Add(this.btnInsertGoods);
            this.panel6.Controls.Add(this.label26);
            this.panel6.Controls.Add(this.txtNote);
            this.panel6.Controls.Add(this.label27);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 533);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1164, 132);
            this.panel6.TabIndex = 5;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(916, 18);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(112, 15);
            this.label28.TabIndex = 31;
            this.label28.Text = "当前订单状态：";
            // 
            // btnOrderDel
            // 
            this.btnOrderDel.Location = new System.Drawing.Point(1025, 75);
            this.btnOrderDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrderDel.Name = "btnOrderDel";
            this.btnOrderDel.Size = new System.Drawing.Size(100, 29);
            this.btnOrderDel.TabIndex = 30;
            this.btnOrderDel.Text = "删除";
            this.btnOrderDel.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(899, 75);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 29);
            this.btnSubmit.TabIndex = 29;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(773, 75);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelGoods
            // 
            this.btnDelGoods.Location = new System.Drawing.Point(36, 82);
            this.btnDelGoods.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelGoods.Name = "btnDelGoods";
            this.btnDelGoods.Size = new System.Drawing.Size(100, 29);
            this.btnDelGoods.TabIndex = 27;
            this.btnDelGoods.Text = "删除记录";
            this.btnDelGoods.UseVisualStyleBackColor = true;
            // 
            // btnInsertGoods
            // 
            this.btnInsertGoods.Location = new System.Drawing.Point(36, 45);
            this.btnInsertGoods.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertGoods.Name = "btnInsertGoods";
            this.btnInsertGoods.Size = new System.Drawing.Size(100, 29);
            this.btnInsertGoods.TabIndex = 26;
            this.btnInsertGoods.Text = "插入记录";
            this.btnInsertGoods.UseVisualStyleBackColor = true;
            this.btnInsertGoods.Click += new System.EventHandler(this.btnInsertGoods_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(17, 18);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 15);
            this.label26.TabIndex = 25;
            this.label26.Text = "订单操作";
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Location = new System.Drawing.Point(212, 32);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(537, 89);
            this.txtNote.TabIndex = 24;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(160, 36);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 15);
            this.label27.TabIndex = 23;
            this.label27.Text = "备注：";
            // 
            // cbxShipType
            // 
            this.cbxShipType.FormattingEnabled = true;
            this.cbxShipType.Location = new System.Drawing.Point(160, 196);
            this.cbxShipType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxShipType.Name = "cbxShipType";
            this.cbxShipType.Size = new System.Drawing.Size(52, 23);
            this.cbxShipType.TabIndex = 11;
            this.cbxShipType.SelectedIndexChanged += new System.EventHandler(this.cbxShipType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Fee：";
            // 
            // txtShipType
            // 
            this.txtShipType.Enabled = false;
            this.txtShipType.Location = new System.Drawing.Point(220, 196);
            this.txtShipType.Margin = new System.Windows.Forms.Padding(4);
            this.txtShipType.Name = "txtShipType";
            this.txtShipType.Size = new System.Drawing.Size(63, 25);
            this.txtShipType.TabIndex = 25;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Enabled = false;
            this.txtCurrency.Location = new System.Drawing.Point(220, 231);
            this.txtCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(63, 25);
            this.txtCurrency.TabIndex = 26;
            // 
            // txtPayType
            // 
            this.txtPayType.Enabled = false;
            this.txtPayType.Location = new System.Drawing.Point(524, 234);
            this.txtPayType.Margin = new System.Windows.Forms.Padding(4);
            this.txtPayType.Name = "txtPayType";
            this.txtPayType.Size = new System.Drawing.Size(63, 25);
            this.txtPayType.TabIndex = 27;
            // 
            // labelOrderStatus
            // 
            this.labelOrderStatus.AutoSize = true;
            this.labelOrderStatus.Location = new System.Drawing.Point(1031, 18);
            this.labelOrderStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrderStatus.Name = "labelOrderStatus";
            this.labelOrderStatus.Size = new System.Drawing.Size(52, 15);
            this.labelOrderStatus.TabIndex = 32;
            this.labelOrderStatus.Text = "未提交";
            // 
            // FrmOrderAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 665);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmOrderAdd";
            this.Text = "FrmOrderAdd";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOriOrderId;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxOrderType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbxPayType;
        private System.Windows.Forms.TextBox txtPayNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbxCurrency;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtShipFee;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListView listViewGoods;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtShippingAddress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtShippingPhone;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtShippingName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnDelGoods;
        private System.Windows.Forms.Button btnInsertGoods;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnOrderDel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel labelCurMarketAccount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbSetDefaultAddress;
        private System.Windows.Forms.ComboBox cbxShipType;
        private System.Windows.Forms.TextBox txtPayType;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtShipType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOrderStatus;
    }
}