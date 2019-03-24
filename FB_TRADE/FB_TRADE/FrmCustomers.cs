using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FB_Trade_DAL;
using FB_Trade_Models;

namespace FB_TRADE
{
    public partial class FrmCustomers : Form
    {
        public bool bAdmin;
        public string curMarketFbId;
        public string curMarketFbAccount;
        public FrmMain pFrmMain;

        private DBCommon db = new DBCommon();
        private StringBuilder sb = new StringBuilder();

        //1. 构造界面
        public FrmCustomers()
        {
            InitializeComponent();
            MyComponentInit();
        }

        private void MyComponentInit()
        {
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ShowItemToolTips = false;

            this.listViewCustomers.View = System.Windows.Forms.View.Details;
            this.listViewCustomers.FullRowSelect = true;
            listViewCustomers.CheckBoxes = true;
            this.listViewCustomers.GridLines = true;

            this.listViewCustomers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewCustomers_MouseDoubleClick);
            this.listViewCustomers.ListViewItemSorter = new ListViewColumnSorter();
            this.listViewCustomers.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            listViewCustomers.Clear();
            listViewCustomers.Columns.Add("facebook ID", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("昵称", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("国家", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("城市", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("简介", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("好友关系", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("账号关系", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("客户类型", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("订单数", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("意向产品", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("客户备注", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("跟踪日期", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("更新时间", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("互动次数", 100, HorizontalAlignment.Left);
            listViewCustomers.Columns.Add("聊天摘要", 100, HorizontalAlignment.Left);
        }

        public void ListViewResize()
        {
            foreach (ColumnHeader item in listViewCustomers.Columns)
            {
                item.TextAlign = HorizontalAlignment.Left;
                switch (item.Text)
                {
                    case "facebook ID":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "昵称":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "国家":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "城市":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "简介":
                        item.Width = (this.listViewCustomers.Width / 100) * 8;
                        break;
                    case "好友关系":
                        item.Width = (this.listViewCustomers.Width / 100) * 10;
                        break;
                    case "账号关系":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "客户类型":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "订单数":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "意向产品":
                        item.Width = (this.listViewCustomers.Width / 100) * 10;
                        break;
                    case "客户备注":
                        item.Width = (this.listViewCustomers.Width / 100) * 10;
                        break;
                    case "跟踪日期":
                        item.Width = (this.listViewCustomers.Width / 100) * 5;
                        break;
                    case "更新时间":
                        item.Width = (this.listViewCustomers.Width / 100) * 7;
                        break;
                    case "互动次数":
                        item.Width = (this.listViewCustomers.Width / 100) * 3;
                        break;
                    case "聊天摘要":
                        item.Width = (this.listViewCustomers.Width / 100) * 12;
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
                btnDelete.Visible = false;

            labelCurMarketFbInfo.Text = curMarketFbAccount;

            LoadListViewDB();
        }

        public void LoadListViewDB()
        {
            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbCustomerShips where marketFbId='{0}'", curMarketFbId);
                List<FbCustomerShipInfo> shipList = (List<FbCustomerShipInfo>)db.GetList(sb.ToString(), "tb_fbCustomerShips");

                listViewCustomers.Items.Clear();
                foreach (var ship in shipList)
                {
                    ListViewItem it = new ListViewItem();

                    //shipInfo
                    it.Text = ship.customerFbId;

                    //Get CustomerInfo
                    sb.Clear();
                    sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", ship.customerFbId);
                    FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");
                    it.SubItems.Add(customer.name);
                    it.SubItems.Add(customer.country);
                    it.SubItems.Add(customer.city);
                    it.SubItems.Add(customer.introduction);

                    //friendShips
                    sb.Clear();
                    sb.AppendFormat("select fbAccount from tb_fbMarketAccounts where fbId in " +
                        "(select marketFbId from tb_fbCustomerShips where customerFbId='{0}' and shipType in ('好友','屏蔽'))", ship.customerFbId);
                    List<string> strList = (List<string>)db.GetStringList(sb.ToString(), "fbAccount");
                    string friendShips = "";
                    foreach (var str in strList)
                    {
                        friendShips += str + ";";
                    }
                    it.SubItems.Add(friendShips);

                    it.SubItems.Add(ship.shipType);
                    it.SubItems.Add(ship.customerType);

                    //Get OrdersNum
                    sb.Clear();
                    sb.AppendFormat("select count(*) from tb_fbOrders where customerFbId='{0}' and marketFbId='{1}'", 
                        ship.customerFbId, curMarketFbId);
                    it.SubItems.Add(db.GetCount(sb.ToString()).ToString());

                    it.SubItems.Add(ship.interestedGoods);
                    it.SubItems.Add(ship.note);
                    it.SubItems.Add(ship.trace == 1 ? ship.traceDate.Split(' ')[0] : "");
                    it.SubItems.Add(ship.lastEditTime);

                    //互动次数
                    sb.Clear();
                    sb.AppendFormat("select count(*) from tb_fbCustomerContacts where customerFbId='{0}' and marketFbId='{1}'",
                        ship.customerFbId, curMarketFbId);
                    it.SubItems.Add(db.GetCount(sb.ToString()).ToString());

                    //Get last contact
                    sb.Clear();
                    sb.AppendFormat("select top 1 * from tb_fbCustomerContacts where customerFbId='{0}' and marketFbId='{1}' order by id DESC",
                        ship.customerFbId, curMarketFbId);
                    FbCustomerContactInfo contact = (FbCustomerContactInfo)db.GetObject(sb.ToString(), "tb_fbCustomerContacts");
                    if (contact != null)
                        it.SubItems.Add(contact.content);

                    listViewCustomers.Items.Add(it);
                }
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
        //新增客户
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomerAdd frm = new FrmCustomerAdd();
            this.pFrmMain.AddPage(frm, "新增客户");

            frm.bAdd = true;
            frm.curMarketFbId = this.curMarketFbId;
            frm.curMarketFbAccount = curMarketFbAccount;
            frm.pFrmMain = this.pFrmMain;
            frm.bAdmin = this.bAdmin;

            frm.MyFrmInit();
            frm.Show();
        }

        //双击编辑
        private void listViewCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listViewCustomers.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                FrmCustomerAdd frm = new FrmCustomerAdd();
                this.pFrmMain.AddPage(frm, "编辑客户");

                frm.bAdd = false;
                frm.curCustomerFbId = info.Item.Text;
                frm.curMarketFbId = this.curMarketFbId;
                frm.curMarketFbAccount = curMarketFbAccount;
                frm.pFrmMain = this.pFrmMain;
                frm.bAdmin = this.bAdmin;

                frm.MyFrmInit();
                frm.Show();
            }
        }

        //删除客户
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (listViewCustomers.CheckedItems.Count < 1)
            {
                MessageBox.Show("没有选中的条目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choice == DialogResult.No)
                return;

            for (int i = 0; i < listViewCustomers.CheckedItems.Count; i++)
            {
                try
                {
                    //先删除聊天记录表
                    sb.Clear();
                    sb.AppendFormat("delete from tb_fbCustomerContacts where customerFbId='{0}' and marketFbId='{1}'",
                        listViewCustomers.CheckedItems[i].SubItems[0].Text, curMarketFbId);
                    db.DeleteData(sb.ToString());

                    //再删除客户关系表
                    sb.Clear();
                    sb.AppendFormat("delete from tb_fbCustomerShips where customerFbId='{0}' and marketFbId='{1}'",
                        listViewCustomers.CheckedItems[i].SubItems[0].Text, curMarketFbId);
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

        private void btnCopyUrl_Click(object sender, EventArgs e)
        {
            if (listViewCustomers.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要复制的客户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listViewCustomers.CheckedItems.Count > 1)
            {
                MessageBox.Show("只能选中一位客户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                sb.Clear();
                sb.AppendFormat("select * from tb_fbCustomers where fbId='{0}'", listViewCustomers.CheckedItems[0].SubItems[0].Text);
                FbCustomerInfo customer = (FbCustomerInfo)db.GetObject(sb.ToString(), "tb_fbCustomers");
                if (customer != null)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(customer.fbUrl);
                }
                
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadListViewDB();
        }
    }
}
