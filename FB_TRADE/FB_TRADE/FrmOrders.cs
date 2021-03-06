﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using FB_Trade_DAL;
using FB_Trade_Models;

namespace FB_TRADE
{
    public partial class FrmOrders : Form
    {
        public bool bAdmin;
        public string curMarketFbId;
        public string curMarketFbAccount;
        public FrmMain pFrmMain;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        //1. 构造界面
        public FrmOrders()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            dateTimePickerBegin.Value = Convert.ToDateTime("2017-01-01");

            this.listViewOrders.View = System.Windows.Forms.View.Details;
            this.listViewOrders.FullRowSelect = true;
            listViewOrders.CheckBoxes = true;
            this.listViewOrders.GridLines = true;

            this.listViewOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewOrders_MouseDoubleClick);
            this.listViewOrders.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewOrders.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewOrders.Clear();
            listViewOrders.Columns.Add("订单号", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("客户编号", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("订单类型", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("原订单号", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("订单状态", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("总金额", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("创建时间", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("更新时间", 100, HorizontalAlignment.Left);
            listViewOrders.Columns.Add("备注", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewOrders.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "订单号":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "客户编号":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "姓名":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "订单类型":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "原订单号":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "订单状态":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "总金额":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "创建时间":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "更新时间":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    case "备注":
                        item.Width = (this.listViewOrders.Width / 100) * 10;
                        break;
                    default:
                        item.Width = -2;
                        break;
                }
            }
        }

        //2. 数据加载
        public void MyFrmInit()
        {
            if (!bAdmin)
            {
                btnDelete.Visible = false;
                btnAbbandon.Visible = false;
            }

            labelCurMarketFbInfo.Text = curMarketFbAccount;

            ckbSave.Checked = true;
            ckbPriceNotConfirm.Checked = true;
            ckbNotShip.Checked = true;
            ckbShiped.Checked = true;
            ckbAdminDel.Checked = true;
            ckbSelfDel.Checked = true;

            LoadListViewDB();
        }

        public void LoadListViewDB()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbOrders where marketFbId='{0}'", curMarketFbId);

                string keyWords = txtKeyWords.Text.Trim();
                if (keyWords != "")
                {
                    sb.AppendFormat(" and (orderId like '%{0}%' or oriOrderId like '%{1}%' or customerFbId like '%{2}%' or note like '%{3}%' or " +
                        "customerFbId in (select fbId from tb_fbCustomers where name like '%{4}%' or fbUrl like '%{5}%') or " +
                        "orderId in (select orderId from tb_fbOrdergoods where name like '%{6}%'))",
                        keyWords, keyWords, keyWords, keyWords, keyWords, keyWords, keyWords);
                }

                string filterWords = txtFilterWords.Text.Trim();
                if (filterWords != "")
                {
                    sb.AppendFormat(" and (orderId not like '%{0}%' and oriOrderId not like '%{1}%' and customerFbId not like '%{2}%' and note not like '%{3}%' and " +
                        "customerFbId not in (select fbId from tb_fbCustomers where name like '%{4}%' or fbUrl like '%{5}%') and " +
                        "orderId not in (select orderId from tb_fbOrdergoods where name like '%{6}%'))",
                        filterWords, filterWords, filterWords, filterWords, filterWords, filterWords, filterWords);
                }

                DateTime begin = new DateTime(dateTimePickerBegin.Value.Year, dateTimePickerBegin.Value.Month, dateTimePickerBegin.Value.Day, 0, 0, 0);
                DateTime end = new DateTime(dateTimePickerEnd.Value.Year, dateTimePickerEnd.Value.Month, dateTimePickerEnd.Value.Day, 23, 59, 59);
                sb.AppendFormat(" and lastEditTime between '{0}' and '{1}'", begin.ToString(), end.ToString());

                if (ckbSave.Checked && ckbPriceNotConfirm.Checked && ckbNotShip.Checked && ckbShiped.Checked && ckbAdminDel.Checked && ckbSelfDel.Checked)
                {
                    ;
                }
                else
                {
                    sb.Append(" and status in ('填充'");
                    if (ckbSave.Checked)
                        sb.Append(",'未提交'");
                    if (ckbPriceNotConfirm.Checked)
                        sb.Append(",'未确认金额'");
                    if (ckbNotShip.Checked)
                        sb.Append(",'未发货'");
                    if (ckbShiped.Checked)
                        sb.Append(",'已发货'");
                    if (ckbAdminDel.Checked)
                        sb.Append(",'管理员废弃单'");
                    if (ckbSelfDel.Checked)
                        sb.Append(",'自己删除单'");
                    sb.Append(")");
                }

                List<FbOrderInfo> orderList = (List<FbOrderInfo>)db.GetList(sb.ToString(), "tb_fbOrders");

                listViewOrders.Items.Clear();
                foreach (var order in orderList)
                {
                    ListViewItem it = new ListViewItem();

                    //orderInfo
                    it.Text = order.orderId;

                    //Get Customer Info
                    sb.Clear();
                    sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", order.customerFbId);
                    FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");
                    it.SubItems.Add(customer.fbId);
                    it.SubItems.Add(customer.name);

                    it.SubItems.Add(order.orderType);
                    it.SubItems.Add(order.oriOrderId);
                    it.SubItems.Add(order.status);
                    it.SubItems.Add(order.totalPrice);
                    it.SubItems.Add(order.createTime);
                    it.SubItems.Add(order.lastEditTime);
                    it.SubItems.Add(order.note);

                    listViewOrders.Items.Add(it);
                }
                //ListViewResize();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "数据库异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //3. 操作
        //新增订单
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmOrderAdd frm = new FrmOrderAdd();
            this.pFrmMain.AddPage(frm, "新增订单");

            frm.bAdmin = this.bAdmin;
            frm.bAdd = true;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;
            frm.pFrmMain = this.pFrmMain;

            frm.MyFrmInit();
            frm.Show();
        }

        //双击编辑
        private void listViewOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewOrders.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmOrderAdd frm = new FrmOrderAdd();
                this.pFrmMain.AddPage(frm, "编辑订单");

                frm.bAdmin = this.bAdmin;
                frm.bAdd = false;
                frm.curOrderId = info.Item.Text;
                frm.curMarketFbId = this.curMarketFbId;
                frm.curMarketFbAccount = curMarketFbAccount;
                frm.pFrmMain = this.pFrmMain;

                frm.MyFrmInit();
                frm.Show();
            }
        }

        //废弃
        private void btnAbbandon_Click(object sender, EventArgs e)
        {
            if (listViewOrders.CheckedItems.Count < 1)
            {
                MessageBox.Show("没有选中的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show("确定要废弃选中订单吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < listViewOrders.CheckedItems.Count; i++)
            {
                try
                {
                    sb.Clear();
                    sb.AppendFormat("update tb_fbOrders set status='{0}' where orderId='{1}'",
                       bAdmin ? "管理员废弃单":"自己删除单", listViewOrders.CheckedItems[i].SubItems[0].Text);
                    db.UpdateData(sb.ToString());
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "数据库异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.LoadListViewDB();
        }

        //删除订单
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewOrders.CheckedItems.Count < 1)
            {
                MessageBox.Show("没有选中的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show("确定彻底删除选中订单？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < listViewOrders.CheckedItems.Count; i++)
            {
                try
                {
                    //先删除goods
                    sb.Clear();
                    sb.AppendFormat("delete from tb_fbOrderGoods where orderId='{0}'",
                        listViewOrders.CheckedItems[i].SubItems[0].Text);
                    db.DeleteData(sb.ToString());

                    //再删除订单
                    sb.Clear();
                    sb.AppendFormat("delete from tb_fbOrders where orderId='{0}'",
                        listViewOrders.CheckedItems[i].SubItems[0].Text);
                    db.DeleteData(sb.ToString());
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "数据库异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.LoadListViewDB();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (listViewOrders.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要复制的订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewOrders.CheckedItems.Count > 1)
            {
                MessageBox.Show("只能选中一个订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(listViewOrders.CheckedItems[0].SubItems[0].Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadListViewDB();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadListViewDB();
        }

        private void btnOrderCopy_Click(object sender, EventArgs e)
        {
            if (listViewOrders.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要复制的订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewOrders.CheckedItems.Count > 1)
            {
                MessageBox.Show("只能选中一个订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmOrderAdd frm = new FrmOrderAdd();
            this.pFrmMain.AddPage(frm, "复制订单");

            frm.bAdmin = this.bAdmin;
            frm.bAdd = true;
            frm.orderAddType = "复制";
            frm.orderAddFrom = listViewOrders.CheckedItems[0].SubItems[0].Text;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;
            frm.pFrmMain = this.pFrmMain;

            frm.MyFrmInit();
            frm.Show();
        }

        private void btnOrderAfterSale_Click(object sender, EventArgs e)
        {
            if (listViewOrders.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要新建售后的订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewOrders.CheckedItems.Count > 1)
            {
                MessageBox.Show("只能选中一个订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmOrderAdd frm = new FrmOrderAdd();
            this.pFrmMain.AddPage(frm, "新建售后单");

            frm.bAdmin = this.bAdmin;
            frm.bAdd = true;
            frm.orderAddType = "新建售后";
            frm.orderAddFrom = listViewOrders.CheckedItems[0].SubItems[0].Text;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;
            frm.pFrmMain = this.pFrmMain;

            frm.MyFrmInit();
            frm.Show();
        }

        private void btnOrderDivide_Click(object sender, EventArgs e)
        {
            if (listViewOrders.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要新建分期的订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewOrders.CheckedItems.Count > 1)
            {
                MessageBox.Show("只能选中一个订单！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmOrderAdd frm = new FrmOrderAdd();
            this.pFrmMain.AddPage(frm, "新建分期单");

            frm.bAdmin = this.bAdmin;
            frm.bAdd = true;
            frm.orderAddType = "新建分期";
            frm.orderAddFrom = listViewOrders.CheckedItems[0].SubItems[0].Text;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;
            frm.pFrmMain = this.pFrmMain;

            frm.MyFrmInit();
            frm.Show();
        }
    }
}
